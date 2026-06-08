using AlgoritmoRuster.Controlador;
using AlgoritmoRuster.Controlador.ControladorCorteLinea;
using AlgoritmoRuster.Controlador.ControladorLinea;
using AlgoritmoRuster.Modelo;
using AlgoritmoRuster.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AlgoritmoRuster.Vista
{
    public partial class FrmComparacionRecorte : Form
    {
        private DibujadorPlano dibujadorPlano;

        private ControladorCohen _cohen = new ControladorCohen();
        private ControladorCyrusBeck _cyrus = new ControladorCyrusBeck();
        private ControladorLiangBarsky _liang = new ControladorLiangBarsky();

        private Point? _p1Screen;
        private List<Linea> _lineasOrg = new List<Linea>();
        private List<ResultadoRecorte> _resCohen = new List<ResultadoRecorte>();
        private List<ResultadoRecorte> _resCyrus = new List<ResultadoRecorte>();
        private List<ResultadoRecorte> _resLiang = new List<ResultadoRecorte>();

        private string[] _nombres = { "Cohen-Sutherland", "Cyrus-Beck", "Liang-Barsky" };
        private Color[] _colores = { Color.Red, Color.Green, Color.Blue };

        private class ResultadoRecorte
        {
            public bool Aceptada;
            public PointF P1, P2;
        }

        public FrmComparacionRecorte()
        {
            InitializeComponent();
            dibujadorPlano = new DibujadorPlano();
            configurarTabla();
            cboVista.SelectedIndex = 0;
        }

        private void configurarTabla()
        {
            dvgComparacion.Columns.Clear();
            dvgComparacion.Columns.Add("Algoritmo", "Algoritmo");
            dvgComparacion.Columns.Add("Estado", "Estado");
            dvgComparacion.Columns.Add("P1X", "P1' X");
            dvgComparacion.Columns.Add("P1Y", "P1' Y");
            dvgComparacion.Columns.Add("P2X", "P2' X");
            dvgComparacion.Columns.Add("P2Y", "P2' Y");
            dvgComparacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void rellenarTabla()
        {
            dvgComparacion.Rows.Clear();
            if (_lineasOrg.Count == 0) return;

            for (int i = 0; i < _lineasOrg.Count; i++)
            {
                string lineaNum = $"Linea {i + 1}";
                var rC = _resCohen[i];
                var rCy = _resCyrus[i];
                var rL = _resLiang[i];

                dvgComparacion.Rows.Add(lineaNum + " - Cohen", rC.Aceptada ? "Aceptada" : "Rechazada",
                    rC.Aceptada ? rC.P1.X.ToString("F2") : "-",
                    rC.Aceptada ? rC.P1.Y.ToString("F2") : "-",
                    rC.Aceptada ? rC.P2.X.ToString("F2") : "-",
                    rC.Aceptada ? rC.P2.Y.ToString("F2") : "-");
                dvgComparacion.Rows.Add(lineaNum + " - CyrusBeck", rCy.Aceptada ? "Aceptada" : "Rechazada",
                    rCy.Aceptada ? rCy.P1.X.ToString("F2") : "-",
                    rCy.Aceptada ? rCy.P1.Y.ToString("F2") : "-",
                    rCy.Aceptada ? rCy.P2.X.ToString("F2") : "-",
                    rCy.Aceptada ? rCy.P2.Y.ToString("F2") : "-");
                dvgComparacion.Rows.Add(lineaNum + " - LiangBarsky", rL.Aceptada ? "Aceptada" : "Rechazada",
                    rL.Aceptada ? rL.P1.X.ToString("F2") : "-",
                    rL.Aceptada ? rL.P1.Y.ToString("F2") : "-",
                    rL.Aceptada ? rL.P2.X.ToString("F2") : "-",
                    rL.Aceptada ? rL.P2.Y.ToString("F2") : "-");
            }
        }

        private void procesarLinea()
        {
            PointF p1Cart = dibujadorPlano.PantallaACartesiano(_p1Screen.Value, panelDibujo.Width, panelDibujo.Height);
            PointF p2Cart = dibujadorPlano.PantallaACartesiano(_puntoActual, panelDibujo.Width, panelDibujo.Height);

            _lineasOrg.Add(new Linea(_p1Screen.Value, _puntoActual));

            PointF cp1, cp2;
            bool ok;

            cp1 = p1Cart; cp2 = p2Cart;
            ok = _cohen.RecortarLinea(ref cp1, ref cp2);
            _resCohen.Add(new ResultadoRecorte { Aceptada = ok, P1 = cp1, P2 = cp2 });

            cp1 = p1Cart; cp2 = p2Cart;
            _cyrus.UsarPoligono = false;
            ok = _cyrus.RecortarLinea(ref cp1, ref cp2);
            _resCyrus.Add(new ResultadoRecorte { Aceptada = ok, P1 = cp1, P2 = cp2 });

            cp1 = p1Cart; cp2 = p2Cart;
            ok = _liang.RecortarLinea(ref cp1, ref cp2);
            _resLiang.Add(new ResultadoRecorte { Aceptada = ok, P1 = cp1, P2 = cp2 });

            rellenarTabla();
            lblInfo.Text = $"Linea {_lineasOrg.Count}: ({p1Cart.X:F1},{p1Cart.Y:F1}) -> ({p2Cart.X:F1},{p2Cart.Y:F1})";
        }

        private Point _puntoActual;

        private void panelDibujo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            if (_p1Screen == null)
            {
                _p1Screen = e.Location;
                panelDibujo.Invalidate();
                return;
            }

            _puntoActual = e.Location;
            procesarLinea();
            _p1Screen = null;
            panelDibujo.Invalidate();
        }

        private List<Point> rasterizarLinea(Point p1, Point p2)
        {
            var dda = new ControladorDDA(new Linea(p1, p2));
            dda.generarPuntos();
            return dda.puntos;
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            dibujadorPlano.Dibujar(e.Graphics, panelDibujo.Width, panelDibujo.Height);

            dibujarVentanaCorte(e.Graphics);
            dibujarLineas(e.Graphics);
        }

        private void dibujarVentanaCorte(Graphics g)
        {
            Point esq1 = dibujadorPlano.CartesianoAPantalla(
                new PointF(_cohen.XMin, _cohen.YMin), panelDibujo.Width, panelDibujo.Height);
            Point esq2 = dibujadorPlano.CartesianoAPantalla(
                new PointF(_cohen.XMax, _cohen.YMax), panelDibujo.Width, panelDibujo.Height);

            int rx = Math.Min(esq1.X, esq2.X);
            int ry = Math.Min(esq1.Y, esq2.Y);
            int rw = Math.Abs(esq2.X - esq1.X);
            int rh = Math.Abs(esq2.Y - esq1.Y);

            using (Pen pen = new Pen(Color.FromArgb(0, 80, 180), 3))
                g.DrawRectangle(pen, rx, ry, rw, rh);

            using (Brush sombra = new SolidBrush(Color.FromArgb(18, 0, 80, 180)))
            {
                g.FillRectangle(sombra, 0, 0, panelDibujo.Width, ry);
                g.FillRectangle(sombra, 0, ry + rh, panelDibujo.Width, panelDibujo.Height - ry - rh);
                g.FillRectangle(sombra, 0, ry, rx, rh);
                g.FillRectangle(sombra, rx + rw, ry, panelDibujo.Width - rx - rw, rh);
            }
        }

        private void dibujarLineas(Graphics g)
        {
            if (_lineasOrg.Count == 0) return;

            string seleccion = cboVista.SelectedItem?.ToString() ?? "Todos";

            for (int i = 0; i < _lineasOrg.Count; i++)
            {
                Linea original = _lineasOrg[i];

                Color colorLinea = Color.FromArgb(80, 100, 100, 100);
                int grosorOrg = 2;
                List<Point> ptsOrg = rasterizarLinea(
                    new Point((int)original.puntoInicial.X, (int)original.puntoInicial.Y),
                    new Point((int)original.puntoFinal.X, (int)original.puntoFinal.Y));
                using (Brush b = new SolidBrush(colorLinea))
                    foreach (Point p in ptsOrg)
                        g.FillRectangle(b, p.X - grosorOrg / 2, p.Y - grosorOrg / 2, grosorOrg, grosorOrg);

                if (seleccion == "Todos" || seleccion == _nombres[0])
                    dibujarResultado(g, i, _resCohen, _colores[0]);
                if (seleccion == "Todos" || seleccion == _nombres[1])
                    dibujarResultado(g, i, _resCyrus, _colores[1]);
                if (seleccion == "Todos" || seleccion == _nombres[2])
                    dibujarResultado(g, i, _resLiang, _colores[2]);
            }
        }

        private void dibujarResultado(Graphics g, int idx, List<ResultadoRecorte> resultados, Color color)
        {
            if (idx >= resultados.Count) return;
            var res = resultados[idx];
            if (!res.Aceptada) return;

            Point p1 = dibujadorPlano.CartesianoAPantalla(res.P1, panelDibujo.Width, panelDibujo.Height);
            Point p2 = dibujadorPlano.CartesianoAPantalla(res.P2, panelDibujo.Width, panelDibujo.Height);

            int grosor = 3;
            List<Point> pts = rasterizarLinea(p1, p2);
            using (Brush b = new SolidBrush(color))
                foreach (Point p in pts)
                    g.FillRectangle(b, p.X - grosor / 2, p.Y - grosor / 2, grosor, grosor);
        }

        private void cboVista_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDibujo.Invalidate();
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            _p1Screen = null;
            _lineasOrg.Clear();
            _resCohen.Clear();
            _resCyrus.Clear();
            _resLiang.Clear();
            dvgComparacion.Rows.Clear();
            lblInfo.Text = "Haga clic en dos puntos del plano para trazar";
            panelDibujo.Invalidate();
        }

        private void FrmComparacionRecorte_Load(object sender, EventArgs e)
        {
            DisenoUI.AplicarTema(this);
        }
    }
}
