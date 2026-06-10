using AlgoritmoRuster.Controlador;
using AlgoritmoRuster.Controlador.ControladorCurva;
using AlgoritmoRuster.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AlgoritmoRuster.Vista
{
    public partial class FrmBezier : Form
    {
        private ControladorBezier controladorBezier;
        private ControladorProgresivo controladorProgresivo;
        private DibujadorPlano dibujadorPlano;
        private List<PointF> puntosControl;
        private Color colorCurva = Color.Red;
        private const int RadioPunto = 5;

        public FrmBezier()
        {
            InitializeComponent();
            controladorProgresivo = new ControladorProgresivo();
            controladorProgresivo.ProgresoActualizado += () =>
            {
                if (panelDibujo.IsHandleCreated)
                    panelDibujo.Invalidate();
            };
            dibujadorPlano = new DibujadorPlano();
            puntosControl = new List<PointF>();
            configurarTabla();
        }

        private void configurarTabla()
        {
            dvgCoordenadas.Columns.Clear();
            dvgCoordenadas.Columns.Add("Num", "N°");
            dvgCoordenadas.Columns.Add("X", "Coordenada X");
            dvgCoordenadas.Columns.Add("Y", "Coordenada Y");
            dvgCoordenadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void rellenarTabla()
        {
            dvgCoordenadas.Rows.Clear();
            if (puntosControl.Count == 0) return;
            for (int i = 0; i < puntosControl.Count; i++)
            {
                PointF cart = dibujadorPlano.PantallaACartesiano(
                    new Point((int)puntosControl[i].X, (int)puntosControl[i].Y),
                    panelDibujo.Width, panelDibujo.Height);
                dvgCoordenadas.Rows.Add(i + 1, cart.X, cart.Y);
            }
        }

        private void panelDibujo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            puntosControl.Add(e.Location);
            controladorBezier = new ControladorBezier(puntosControl);
            controladorBezier.GenerarCurva();
            lblInfo.Text = $"Grado: {puntosControl.Count - 1} | Puntos: {puntosControl.Count}";

            List<Point> curvaInt = controladorBezier.Curva.ConvertAll(p =>
                new Point((int)Math.Round(p.X), (int)Math.Round(p.Y)));

            if (chkProgresivo.Checked)
                controladorProgresivo.IniciarProgresivo(curvaInt);
            else
            {
                controladorProgresivo.IniciarPasoAPaso(curvaInt);
                controladorProgresivo.MostrarTodo();
            }

            rellenarTabla();
            panelDibujo.Invalidate();
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            dibujadorPlano.Dibujar(e.Graphics, panelDibujo.Width, panelDibujo.Height);

            if (puntosControl.Count < 2)
            {
                if (puntosControl.Count == 1)
                    DibujarPuntoControl(e.Graphics, puntosControl[0], 1);
                return;
            }

            List<Point> puntosADibujar = controladorProgresivo.ObtenerPuntosActuales();

            if (chkMostrarPoligono.Checked)
            {
                using (Pen penPoligono = new Pen(Color.FromArgb(100, 100, 100), 1.5f) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
                {
                    for (int i = 0; i < puntosControl.Count - 1; i++)
                        e.Graphics.DrawLine(penPoligono, puntosControl[i], puntosControl[i + 1]);
                }
            }

            using (Pen penCurva = new Pen(colorCurva, 2.5f))
            {
                if (puntosADibujar.Count > 1)
                    e.Graphics.DrawLines(penCurva, puntosADibujar.ToArray());
            }

            for (int i = 0; i < puntosControl.Count; i++)
                DibujarPuntoControl(e.Graphics, puntosControl[i], i + 1);
        }

        private void DibujarPuntoControl(Graphics g, PointF pt, int numero)
        {
            using (Brush b = new SolidBrush(Color.FromArgb(0, 122, 204)))
                g.FillEllipse(b, pt.X - RadioPunto, pt.Y - RadioPunto, RadioPunto * 2, RadioPunto * 2);
            using (Pen p = new Pen(Color.White, 2))
                g.DrawEllipse(p, pt.X - RadioPunto, pt.Y - RadioPunto, RadioPunto * 2, RadioPunto * 2);
            using (Brush b = new SolidBrush(Color.White))
            using (Font f = new Font("Consolas", 8, FontStyle.Bold))
            {
                string txt = numero.ToString();
                SizeF sz = g.MeasureString(txt, f);
                g.DrawString(txt, f, b, pt.X - sz.Width / 2, pt.Y - sz.Height / 2);
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

        private void btnResetear_Click(object sender, EventArgs e)
        {
            puntosControl.Clear();
            controladorBezier = null;
            controladorProgresivo.Limpiar();
            dvgCoordenadas.Rows.Clear();
            lblInfo.Text = "Grado: -- | Puntos: 0";
            btnPaso.Enabled = false;
            panelDibujo.Invalidate();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = colorCurva;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorCurva = colorDialog.Color;
                btnColor.BackColor = colorCurva;
                panelDibujo.Invalidate();
            }
        }

        private void chkMostrarPoligono_CheckedChanged(object sender, EventArgs e)
        {
            panelDibujo.Invalidate();
        }

        private void FrmBezier_Load(object sender, EventArgs e)
        {
            DisenoUI.AplicarTema(this);
            btnPaso.Enabled = false;
            btnColor.BackColor = colorCurva;
            lblInfo.Text = "Grado: -- | Puntos: 0";
        }
    }
}
