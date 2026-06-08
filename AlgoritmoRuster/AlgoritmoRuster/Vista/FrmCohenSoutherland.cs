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
    public partial class FrmCohenSoutherland : Form
    {
        private DibujadorPlano dibujadorPlano;
        private ControladorCohen controladorCohen;
        private ControladorProgresivo controladorProgresivo;
        private Color colorLinea = Color.Red;

        private Point? puntoInicial = null;
        private Point? puntoFinal = null;
        private List<Point> puntosClip = null;
        private Linea lineaOriginal = null;

        private PointF p1CartOriginal, p2CartOriginal;
        private PointF p1CartClip, p2CartClip;
        private Point p1ClipScreen, p2ClipScreen;
        private bool lineaAceptada = false;

        public FrmCohenSoutherland()
        {
            InitializeComponent();
            dibujadorPlano = new DibujadorPlano();
            controladorCohen = new ControladorCohen();
            controladorProgresivo = new ControladorProgresivo();
            controladorProgresivo.ProgresoActualizado += () =>
            {
                if (panelDibujo.IsHandleCreated)
                    panelDibujo.Invalidate();
            };
            configurarTabla();
        }

        private void configurarTabla()
        {
            dvgCoordenadas.Columns.Clear();
            dvgCoordenadas.Columns.Add("Tipo", "Tipo");
            dvgCoordenadas.Columns.Add("X", "X (cart)");
            dvgCoordenadas.Columns.Add("Y", "Y (cart)");
            dvgCoordenadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void rellenarTabla()
        {
            dvgCoordenadas.Rows.Clear();
            dvgCoordenadas.Rows.Add("Original P1", p1CartOriginal.X, p1CartOriginal.Y);
            dvgCoordenadas.Rows.Add("Original P2", p2CartOriginal.X, p2CartOriginal.Y);
            if (lineaAceptada)
            {
                dvgCoordenadas.Rows.Add("Clip P1", p1CartClip.X, p1CartClip.Y);
                dvgCoordenadas.Rows.Add("Clip P2", p2CartClip.X, p2CartClip.Y);
            }
            else
            {
                dvgCoordenadas.Rows.Add("Resultado", "RECHAZADA", "");
            }
        }

        private void panelDibujo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            if (puntoInicial == null)
            {
                puntoInicial = e.Location;
                panelDibujo.Invalidate();
                return;
            }
            if (puntoFinal == null)
            {
                puntoFinal = e.Location;

                p1CartOriginal = dibujadorPlano.PantallaACartesiano(puntoInicial.Value, panelDibujo.Width, panelDibujo.Height);
                p2CartOriginal = dibujadorPlano.PantallaACartesiano(puntoFinal.Value, panelDibujo.Width, panelDibujo.Height);

                p1CartClip = p1CartOriginal;
                p2CartClip = p2CartOriginal;
                lineaAceptada = controladorCohen.RecortarLinea(ref p1CartClip, ref p2CartClip);

                if (lineaAceptada)
                {
                    p1ClipScreen = dibujadorPlano.CartesianoAPantalla(p1CartClip, panelDibujo.Width, panelDibujo.Height);
                    p2ClipScreen = dibujadorPlano.CartesianoAPantalla(p2CartClip, panelDibujo.Width, panelDibujo.Height);

                    lineaOriginal = new Linea(puntoInicial.Value, puntoFinal.Value);

                    puntosClip = generarPuntosLinea(new Linea(p1ClipScreen, p2ClipScreen));

                    if (chkProgresivo.Checked)
                        controladorProgresivo.IniciarProgresivo(puntosClip);
                    else
                    {
                        controladorProgresivo.IniciarPasoAPaso(puntosClip);
                        controladorProgresivo.MostrarTodo();
                    }

                    lblClipInfo.Text = $"Linea ACEPTADA: ({p1CartClip.X:F2},{p1CartClip.Y:F2}) -> ({p2CartClip.X:F2},{p2CartClip.Y:F2})";
                }
                else
                {
                    puntosClip = null;
                    lineaOriginal = new Linea(puntoInicial.Value, puntoFinal.Value);
                    controladorProgresivo.Limpiar();
                    lblClipInfo.Text = $"Linea RECHAZADA: fuera de la ventana de corte";
                }

                rellenarTabla();
                panelDibujo.Invalidate();
                puntoInicial = puntoFinal = null;
            }
        }

        private List<Point> generarPuntosLinea(Linea linea)
        {
            switch (cboAlgoritmoLinea.SelectedItem?.ToString())
            {
                case "Bresenham":
                    var bres = new ControladorBresenham(linea);
                    bres.generarPuntos();
                    return bres.puntos;
                case "Antialiasing":
                    var anti = new ControladorAntialiasing(linea);
                    anti.generarPuntos();
                    return anti.puntos;
                default:
                    var dda = new ControladorDDA(linea);
                    dda.generarPuntos();
                    return dda.puntos;
            }
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            dibujadorPlano.Dibujar(e.Graphics, panelDibujo.Width, panelDibujo.Height);

            dibujarVentanaCorte(e.Graphics);

            if (puntoInicial != null)
                dibujarEtiquetaPunto(e.Graphics, puntoInicial.Value, "P1", Color.Blue);

            if (lineaOriginal != null)
            {
                dibujarLineaOriginal(e.Graphics);

                if (lineaAceptada && puntosClip != null)
                    dibujarLineaClip(e.Graphics);
                else if (!lineaAceptada)
                    dibujarEtiquetaRechazada(e.Graphics);
            }
        }

        private void dibujarVentanaCorte(Graphics g)
        {
            Point esq1 = dibujadorPlano.CartesianoAPantalla(
                new PointF(controladorCohen.XMin, controladorCohen.YMin),
                panelDibujo.Width, panelDibujo.Height);
            Point esq2 = dibujadorPlano.CartesianoAPantalla(
                new PointF(controladorCohen.XMax, controladorCohen.YMax),
                panelDibujo.Width, panelDibujo.Height);

            int rx = Math.Min(esq1.X, esq2.X);
            int ry = Math.Min(esq1.Y, esq2.Y);
            int rw = Math.Abs(esq2.X - esq1.X);
            int rh = Math.Abs(esq2.Y - esq1.Y);

            using (Pen pen = new Pen(Color.FromArgb(0, 80, 180), 3))
            {
                g.DrawRectangle(pen, rx, ry, rw, rh);
            }

            using (Brush sombra = new SolidBrush(Color.FromArgb(18, 0, 80, 180)))
            {
                g.FillRectangle(sombra, 0, 0, panelDibujo.Width, ry);
                g.FillRectangle(sombra, 0, ry + rh, panelDibujo.Width, panelDibujo.Height - ry - rh);
                g.FillRectangle(sombra, 0, ry, rx, rh);
                g.FillRectangle(sombra, rx + rw, ry, panelDibujo.Width - rx - rw, rh);
            }

            using (Pen semi = new Pen(Color.FromArgb(80, 0, 80, 180)))
            {
                for (int x = rx; x <= rx + rw; x += 8)
                {
                    g.DrawLine(semi, x, ry, x + 4, ry);
                    g.DrawLine(semi, x, ry + rh, x + 4, ry + rh);
                }
                for (int y = ry; y <= ry + rh; y += 8)
                {
                    g.DrawLine(semi, rx, y, rx, y + 4);
                    g.DrawLine(semi, rx + rw, y, rx + rw, y + 4);
                }
            }
        }

        private void dibujarLineaOriginal(Graphics g)
        {
            if (lineaOriginal == null) return;
            List<Point> pts = generarPuntosLinea(lineaOriginal);
            int grosor = 2;
            using (Brush b = new SolidBrush(Color.FromArgb(80, 100, 100, 100)))
                foreach (Point p in pts)
                    g.FillRectangle(b, p.X - grosor / 2, p.Y - grosor / 2, grosor, grosor);

            dibujarEtiquetaPunto(g, new Point((int)lineaOriginal.puntoInicial.X, (int)lineaOriginal.puntoInicial.Y),
                $"P1 ({p1CartOriginal.X:F1},{p1CartOriginal.Y:F1})", Color.Gray);
            dibujarEtiquetaPunto(g, new Point((int)lineaOriginal.puntoFinal.X, (int)lineaOriginal.puntoFinal.Y),
                $"P2 ({p2CartOriginal.X:F1},{p2CartOriginal.Y:F1})", Color.Gray);
        }

        private void dibujarLineaClip(Graphics g)
        {
            if (puntosClip == null) return;
            List<Point> puntosADibujar = controladorProgresivo.ObtenerPuntosActuales();
            int grosor = 3;
            using (Brush b = new SolidBrush(colorLinea))
                foreach (Point p in puntosADibujar)
                    g.FillRectangle(b, p.X - grosor / 2, p.Y - grosor / 2, grosor, grosor);

            dibujarEtiquetaPunto(g, p1ClipScreen,
                $"P1' ({p1CartClip.X:F1},{p1CartClip.Y:F1})", colorLinea);
            dibujarEtiquetaPunto(g, p2ClipScreen,
                $"P2' ({p2CartClip.X:F1},{p2CartClip.Y:F1})", colorLinea);
        }

        private void dibujarEtiquetaPunto(Graphics g, Point p, string texto, Color color)
        {
            using (Brush fill = new SolidBrush(Color.White))
            using (Pen borde = new Pen(color, 2))
            {
                g.FillEllipse(fill, p.X - 5, p.Y - 5, 10, 10);
                g.DrawEllipse(borde, p.X - 5, p.Y - 5, 10, 10);
            }

            using (Font fuente = new Font("Consolas", 9, FontStyle.Bold))
            using (Brush brush = new SolidBrush(color))
            {
                SizeF tam = g.MeasureString(texto, fuente);
                float labelX = p.X + 8;
                float labelY = p.Y - tam.Height / 2;
                if (labelX + tam.Width > panelDibujo.Width)
                    labelX = p.X - tam.Width - 8;
                if (labelY < 0) labelY = 0;
                if (labelY + tam.Height > panelDibujo.Height)
                    labelY = panelDibujo.Height - tam.Height;

                using (Brush fondo = new SolidBrush(Color.FromArgb(200, 255, 255, 255)))
                    g.FillRectangle(fondo, labelX - 2, labelY - 1, tam.Width + 4, tam.Height + 2);
                g.DrawString(texto, fuente, brush, labelX, labelY);
            }
        }

        private void dibujarEtiquetaRechazada(Graphics g)
        {
            if (lineaOriginal == null) return;
            int mx = ((int)lineaOriginal.puntoInicial.X + (int)lineaOriginal.puntoFinal.X) / 2;
            int my = ((int)lineaOriginal.puntoInicial.Y + (int)lineaOriginal.puntoFinal.Y) / 2;

            using (Font fuente = new Font("Consolas", 11, FontStyle.Bold))
            using (Brush brush = new SolidBrush(Color.FromArgb(200, 200, 0, 0)))
            {
                string texto = "RECHAZADA";
                SizeF tam = g.MeasureString(texto, fuente);
                float lx = mx - tam.Width / 2;
                float ly = my - tam.Height / 2;
                using (Brush fondo = new SolidBrush(Color.FromArgb(200, 255, 255, 255)))
                    g.FillRectangle(fondo, lx - 4, ly - 2, tam.Width + 8, tam.Height + 4);
                g.DrawString(texto, fuente, brush, lx, ly);
            }
        }

        private void btnPaso_Click(object sender, EventArgs e)
        {
            controladorProgresivo.AvanzarUnPaso();
            if (controladorProgresivo.EstaCompleto)
                btnPaso.Enabled = false;
        }

        private void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            controladorProgresivo.MostrarTodo();
            btnPaso.Enabled = false;
        }

        private void chkProgresivo_CheckedChanged(object sender, EventArgs e)
        {
            btnPaso.Enabled = !chkProgresivo.Checked;
            if (chkProgresivo.Checked && controladorProgresivo.HayPuntos && !controladorProgresivo.EstaCompleto)
                controladorProgresivo.Reanudar();
            else if (!chkProgresivo.Checked)
                controladorProgresivo.Pausar();
        }

        private void trackBarVelocidad_Scroll(object sender, EventArgs e)
        {
            int valorInvertido = 101 - trackBarVelocidad.Value;
            controladorProgresivo.Interval = valorInvertido * 5;
            lblVelocidad.Text = $"Velocidad: {trackBarVelocidad.Value}";
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = colorLinea;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorLinea = colorDialog.Color;
                btnColor.BackColor = colorLinea;
                panelDibujo.Invalidate();
            }
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            puntoInicial = null;
            puntoFinal = null;
            puntosClip = null;
            lineaOriginal = null;
            lineaAceptada = false;
            controladorProgresivo.Limpiar();
            dvgCoordenadas.Rows.Clear();
            btnPaso.Enabled = false;
            lblClipInfo.Text = "Haga clic en dos puntos para trazar";
            panelDibujo.Invalidate();
        }

        private void FrmCohenSoutherland_Load(object sender, EventArgs e)
        {
            DisenoUI.AplicarTema(this);
            btnPaso.Enabled = false;
            btnColor.BackColor = colorLinea;
        }
    }
}
