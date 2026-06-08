using AlgoritmoRuster.Controlador.ControladorCortePoligono;
using AlgoritmoRuster.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AlgoritmoRuster.Vista
{
    public partial class FrmComparacionPoligono : Form
    {
        private const float XMIN = -4f, XMAX = 4f, YMIN = -3f, YMAX = 3f;

        private DibujadorPlano dibujadorPlano;
        private ControladorSutherlandHodgman _sh = new ControladorSutherlandHodgman();
        private ControladorWeilerAtherton _wa = new ControladorWeilerAtherton();
        private ControladorGreinerHormann _gh = new ControladorGreinerHormann();

        private List<PointF> _sujeto = new List<PointF>();
        private List<PointF> _resSH = null;
        private List<PointF> _resWA = null;
        private List<PointF> _resGH = null;
        private bool _comparado = false;

        private string[] _nombres = { "Sutherland-Hodgman", "Weiler-Atherton", "Greiner-Hormann" };
        private Color[] _colores = { Color.Red, Color.FromArgb(0, 160, 0), Color.Blue };

        public FrmComparacionPoligono()
        {
            InitializeComponent();
            dibujadorPlano = new DibujadorPlano();
            configurarTabla();
            cboVista.SelectedIndex = 0;
            actualizarBoton();
        }

        private void configurarTabla()
        {
            dvgComparacion.Columns.Clear();
            dvgComparacion.Columns.Add("Algoritmo", "Algoritmo");
            dvgComparacion.Columns.Add("Vertices", "Vertices");
            dvgComparacion.Columns.Add("Estado", "Estado");
            dvgComparacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void rellenarTabla()
        {
            dvgComparacion.Rows.Clear();
            if (!_comparado) return;

            var res = new[] { _resSH, _resWA, _resGH };
            for (int i = 0; i < 3; i++)
            {
                string estado = res[i] != null ? "Recortado" : "Fuera del area";
                string verts = res[i] != null ? res[i].Count.ToString() : "-";
                dvgComparacion.Rows.Add(_nombres[i], verts, estado);
            }
        }

        private void actualizarBoton()
        {
            if (_comparado)
            {
                btnComparar.Enabled = false;
                btnComparar.Text = "Comparado";
            }
            else
            {
                btnComparar.Enabled = _sujeto.Count >= 3;
                btnComparar.Text = "Comparar";
            }
        }

        private void limpiarTodo()
        {
            _sujeto.Clear();
            _resSH = null;
            _resWA = null;
            _resGH = null;
            _comparado = false;
            dvgComparacion.Rows.Clear();
            actualizarBoton();
            lblInfo.Text = "Clic para definir el poligono (3+ vertices)";
            panelDibujo.Invalidate();
        }

        private void btnComparar_Click(object sender, EventArgs e)
        {
            if (_comparado) return;
            if (_sujeto.Count < 3) return;

            var copia = new List<PointF>(_sujeto);

            var rect = new List<PointF>
            {
                new PointF(XMIN, YMIN),
                new PointF(XMAX, YMIN),
                new PointF(XMAX, YMAX),
                new PointF(XMIN, YMAX)
            };
            _sh.ClipVertices = rect;
            _resSH = _sh.Recortar(copia);
            _resWA = _wa.Recortar(copia);
            _resGH = _gh.Recortar(copia);

            _comparado = true;
            rellenarTabla();
            actualizarBoton();
            lblInfo.Text = $"Poligono de {_sujeto.Count} vertices comparado";
            panelDibujo.Invalidate();
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            limpiarTodo();
        }

        private void panelDibujo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (_comparado) return;

            PointF cart = dibujadorPlano.PantallaACartesiano(e.Location, panelDibujo.Width, panelDibujo.Height);
            _sujeto.Add(cart);
            lblInfo.Text = $"Clic para definir poligono ({_sujeto.Count} vertices) - Comparar para recortar";
            actualizarBoton();
            panelDibujo.Invalidate();
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            dibujadorPlano.Dibujar(e.Graphics, panelDibujo.Width, panelDibujo.Height);
            dibujarVentanaRecorte(e.Graphics);

            if (_sujeto.Count > 0)
                dibujarPoligonoSujeto(e.Graphics);

            if (!_comparado) return;

            string seleccion = cboVista.SelectedItem?.ToString() ?? "Todos";
            var res = new[] { _resSH, _resWA, _resGH };

            if (seleccion == "Todos" || seleccion == _nombres[0])
                dibujarResultado(e.Graphics, res[0], _colores[0], 0);
            if (seleccion == "Todos" || seleccion == _nombres[1])
                dibujarResultado(e.Graphics, res[1], _colores[1], 1);
            if (seleccion == "Todos" || seleccion == _nombres[2])
                dibujarResultado(e.Graphics, res[2], _colores[2], 2);
        }

        private void dibujarVentanaRecorte(Graphics g)
        {
            PointF pMin = dibujadorPlano.CartesianoAPantalla(new PointF(XMIN, YMIN), panelDibujo.Width, panelDibujo.Height);
            PointF pMax = dibujadorPlano.CartesianoAPantalla(new PointF(XMAX, YMAX), panelDibujo.Width, panelDibujo.Height);

            float x = pMin.X, y = pMax.Y;
            float w = pMax.X - pMin.X, h = pMin.Y - pMax.Y;

            using (Brush sombra = new SolidBrush(Color.FromArgb(20, 0, 80, 180)))
            {
                g.FillRectangle(sombra, 0, 0, panelDibujo.Width, y);
                g.FillRectangle(sombra, 0, y + h, panelDibujo.Width, panelDibujo.Height - y - h);
                g.FillRectangle(sombra, 0, y, x, h);
                g.FillRectangle(sombra, x + w, y, panelDibujo.Width - x - w, h);
            }

            using (Pen pen = new Pen(Color.FromArgb(0, 80, 180), 3))
                g.DrawRectangle(pen, x, y, w, h);
        }

        private PointF[] convertirAPantalla(List<PointF> vertices)
        {
            return vertices.ConvertAll(v => (PointF)dibujadorPlano.CartesianoAPantalla(v, panelDibujo.Width, panelDibujo.Height)).ToArray();
        }

        private void dibujarPoligonoSujeto(Graphics g)
        {
            int n = _sujeto.Count;
            if (n == 0) return;
            PointF[] pts = convertirAPantalla(_sujeto);

            if (n >= 3)
            {
                using (Pen pen = new Pen(Color.FromArgb(200, 120, 0), 2))
                    g.DrawPolygon(pen, PointF2Point(pts));
                using (Brush fill = new SolidBrush(Color.FromArgb(30, 200, 120, 0)))
                    g.FillPolygon(fill, PointF2Point(pts));
            }
            else
            {
                using (Pen pen = new Pen(Color.FromArgb(200, 120, 0), 2) { DashStyle = DashStyle.Dash })
                    for (int i = 1; i < n; i++)
                        g.DrawLine(pen, pts[i - 1], pts[i]);
            }

            for (int i = 0; i < n; i++)
            {
                PointF p = pts[i];
                g.FillEllipse(Brushes.White, p.X - 4, p.Y - 4, 8, 8);
                g.DrawEllipse(new Pen(Color.FromArgb(200, 120, 0), 2), p.X - 4, p.Y - 4, 8, 8);
                using (Font f = new Font("Consolas", 9, FontStyle.Bold))
                    g.DrawString($"S{i + 1}", f, Brushes.SaddleBrown, p.X + 6, p.Y - 8);
            }
        }

        private void dibujarResultado(Graphics g, List<PointF> resultado, Color color, int algoIdx)
        {
            if (resultado == null || resultado.Count < 3) return;
            PointF[] pts = convertirAPantalla(resultado);

            using (Brush fill = new SolidBrush(Color.FromArgb(45, color)))
                g.FillPolygon(fill, PointF2Point(pts));

            using (Pen pen = new Pen(color, 3))
                g.DrawPolygon(pen, PointF2Point(pts));

            for (int i = 0; i < resultado.Count; i++)
            {
                PointF p = pts[i];
                g.FillEllipse(Brushes.White, p.X - 5, p.Y - 5, 10, 10);
                g.DrawEllipse(new Pen(color, 2), p.X - 5, p.Y - 5, 10, 10);
                using (Font f = new Font("Consolas", 8, FontStyle.Bold))
                    g.DrawString($"{_nombres[algoIdx][0]}{i + 1}", f, Brushes.Black, p.X + 6, p.Y - 8);
            }
        }

        private Point[] PointF2Point(PointF[] pts)
        {
            Point[] r = new Point[pts.Length];
            for (int i = 0; i < pts.Length; i++)
                r[i] = new Point((int)pts[i].X, (int)pts[i].Y);
            return r;
        }

        private void cboVista_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDibujo.Invalidate();
        }

        private void FrmComparacionPoligono_Load(object sender, EventArgs e)
        {
            DisenoUI.AplicarTema(this);
        }
    }
}
