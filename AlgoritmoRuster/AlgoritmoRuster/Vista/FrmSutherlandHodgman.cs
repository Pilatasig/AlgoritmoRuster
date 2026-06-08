using AlgoritmoRuster.Controlador.ControladorCortePoligono;
using AlgoritmoRuster.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AlgoritmoRuster.Vista
{
    public partial class FrmSutherlandHodgman : Form
    {
        private const float XMIN = -4f, XMAX = 4f, YMIN = -3f, YMAX = 3f;

        private DibujadorPlano dibujadorPlano;
        private ControladorSutherlandHodgman controlador;

        private List<PointF> _sujetoVertices = new List<PointF>();
        private List<PointF> _resultado = null;
        private bool _clipRealizado = false;

        private Color _colorSujeto = Color.FromArgb(200, 120, 0);
        private Color _colorResultado = Color.Red;
        private Color _colorClipBorde = Color.FromArgb(0, 80, 180);

        public FrmSutherlandHodgman()
        {
            InitializeComponent();
            dibujadorPlano = new DibujadorPlano();
            controlador = new ControladorSutherlandHodgman();
            configurarTabla();
            actualizarBoton();
        }

        private void configurarTabla()
        {
            dvgCoordenadas.Columns.Clear();
            dvgCoordenadas.Columns.Add("Vertice", "Vertice");
            dvgCoordenadas.Columns.Add("X", "X (cart)");
            dvgCoordenadas.Columns.Add("Y", "Y (cart)");
            dvgCoordenadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void rellenarTabla()
        {
            dvgCoordenadas.Rows.Clear();

            for (int i = 0; i < _sujetoVertices.Count; i++)
                dvgCoordenadas.Rows.Add($"S{i + 1}", _sujetoVertices[i].X.ToString("F2"), _sujetoVertices[i].Y.ToString("F2"));

            if (_resultado != null && _resultado.Count > 0)
            {
                for (int i = 0; i < _resultado.Count; i++)
                    dvgCoordenadas.Rows.Add($"R{i + 1}", _resultado[i].X.ToString("F2"), _resultado[i].Y.ToString("F2"));
            }
        }

        private void actualizarBoton()
        {
            if (_clipRealizado)
            {
                btnFinalizar.Enabled = false;
                btnFinalizar.Text = "Recortado";
            }
            else
            {
                btnFinalizar.Enabled = _sujetoVertices.Count >= 3;
                btnFinalizar.Text = "Finalizar";
            }
        }

        private void limpiarTodo()
        {
            _sujetoVertices.Clear();
            _resultado = null;
            _clipRealizado = false;
            dvgCoordenadas.Rows.Clear();
            actualizarBoton();
            panelDibujo.Invalidate();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (_clipRealizado) return;
            if (_sujetoVertices.Count < 3) return;

            controlador.ClipVertices = new List<PointF>
            {
                new PointF(XMIN, YMIN),
                new PointF(XMAX, YMIN),
                new PointF(XMAX, YMAX),
                new PointF(XMIN, YMAX)
            };

            _resultado = controlador.Recortar(new List<PointF>(_sujetoVertices));
            _clipRealizado = true;
            rellenarTabla();
            actualizarBoton();
            panelDibujo.Invalidate();
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            limpiarTodo();
        }

        private void panelDibujo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (_clipRealizado) return;

            PointF cart = dibujadorPlano.PantallaACartesiano(e.Location, panelDibujo.Width, panelDibujo.Height);
            _sujetoVertices.Add(cart);
            lblInstruccion.Text = $"Clic para definir poligono ({_sujetoVertices.Count} vertices) - Finalizar para recortar";
            actualizarBoton();
            panelDibujo.Invalidate();
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            dibujadorPlano.Dibujar(e.Graphics, panelDibujo.Width, panelDibujo.Height);

            dibujarVentanaRecorte(e.Graphics);

            if (_sujetoVertices.Count > 0)
                dibujarPoligonoSujeto(e.Graphics);

            if (_resultado != null && _resultado.Count > 0)
                dibujarResultado(e.Graphics);
        }

        private void dibujarVentanaRecorte(Graphics g)
        {
            PointF pMin = dibujadorPlano.CartesianoAPantalla(new PointF(XMIN, YMIN), panelDibujo.Width, panelDibujo.Height);
            PointF pMax = dibujadorPlano.CartesianoAPantalla(new PointF(XMAX, YMAX), panelDibujo.Width, panelDibujo.Height);

            float x = pMin.X, y = pMax.Y;
            float w = pMax.X - pMin.X, h = pMin.Y - pMax.Y;
            RectangleF rect = new RectangleF(x, y, w, h);

            using (Brush sombra = new SolidBrush(Color.FromArgb(30, _colorClipBorde)))
            {
                g.FillRectangle(sombra, 0, 0, panelDibujo.Width, y);
                g.FillRectangle(sombra, 0, y + h, panelDibujo.Width, panelDibujo.Height - y - h);
                g.FillRectangle(sombra, 0, y, x, h);
                g.FillRectangle(sombra, x + w, y, panelDibujo.Width - x - w, h);
            }

            using (Pen pen = new Pen(_colorClipBorde, 3))
                g.DrawRectangle(pen, x, y, w, h);
        }

        private PointF[] convertirAPantalla(List<PointF> vertices)
        {
            return vertices.ConvertAll(v => (PointF)dibujadorPlano.CartesianoAPantalla(v, panelDibujo.Width, panelDibujo.Height)).ToArray();
        }

        private void dibujarPoligonoSujeto(Graphics g)
        {
            int n = _sujetoVertices.Count;
            if (n == 0) return;
            PointF[] pts = convertirAPantalla(_sujetoVertices);

            if (n >= 3)
            {
                using (Pen pen = new Pen(_colorSujeto, 2))
                    g.DrawPolygon(pen, PointF2Point(pts));
                using (Brush fill = new SolidBrush(Color.FromArgb(40, _colorSujeto)))
                    g.FillPolygon(fill, PointF2Point(pts));
            }
            else
            {
                using (Pen pen = new Pen(_colorSujeto, 2) { DashStyle = DashStyle.Dash })
                    for (int i = 1; i < n; i++)
                        g.DrawLine(pen, pts[i - 1], pts[i]);
            }

            for (int i = 0; i < n; i++)
            {
                PointF p = pts[i];
                g.FillEllipse(Brushes.White, p.X - 4, p.Y - 4, 8, 8);
                g.DrawEllipse(new Pen(_colorSujeto, 2), p.X - 4, p.Y - 4, 8, 8);
                using (Font f = new Font("Consolas", 9, FontStyle.Bold))
                    g.DrawString($"S{i + 1}", f, Brushes.SaddleBrown, p.X + 6, p.Y - 8);
            }
        }

        private void dibujarResultado(Graphics g)
        {
            if (_resultado == null || _resultado.Count < 3) return;
            PointF[] pts = convertirAPantalla(_resultado);

            using (Brush fill = new SolidBrush(Color.FromArgb(60, _colorResultado)))
                g.FillPolygon(fill, PointF2Point(pts));

            using (Pen pen = new Pen(_colorResultado, 3))
                g.DrawPolygon(pen, PointF2Point(pts));

            for (int i = 0; i < _resultado.Count; i++)
            {
                PointF p = pts[i];
                g.FillEllipse(Brushes.White, p.X - 5, p.Y - 5, 10, 10);
                g.DrawEllipse(new Pen(_colorResultado, 2), p.X - 5, p.Y - 5, 10, 10);
                using (Font f = new Font("Consolas", 9, FontStyle.Bold))
                    g.DrawString($"R{i + 1}", f, Brushes.DarkRed, p.X + 6, p.Y - 8);
            }
        }

        private Point[] PointF2Point(PointF[] pts)
        {
            Point[] r = new Point[pts.Length];
            for (int i = 0; i < pts.Length; i++)
                r[i] = new Point((int)pts[i].X, (int)pts[i].Y);
            return r;
        }

        private void FrmSutherlandHodgman_Load(object sender, EventArgs e)
        {
            DisenoUI.AplicarTema(this);
        }
    }
}
