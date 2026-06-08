using AlgoritmoRuster.Controlador;
using AlgoritmoRuster.Controlador.ControladorLinea;
using AlgoritmoRuster.Modelo;
using AlgoritmoRuster.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AlgoritmoRuster.Vista
{
    public partial class FrmLineaAntialiasing : Form
    {
        private ControladorAntialiasing controladorAntialiasing;
        private ControladorProgresivo controladorProgresivo;
        private DibujadorPlano dibujadorPlano;
        private Point? puntoInicial = null;
        private Point? puntoFinal = null;
        private Color colorLinea = Color.Aqua;

        public FrmLineaAntialiasing()
        {
            InitializeComponent();
            controladorProgresivo = new ControladorProgresivo();
            controladorProgresivo.ProgresoActualizado += () =>
            {
                if (panelDibujo.IsHandleCreated)
                    panelDibujo.Invalidate();
            };
            dibujadorPlano = new DibujadorPlano();
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
            if (controladorAntialiasing == null) return;
            int indice = 1;
            foreach (Point p in controladorAntialiasing.puntos)
            {
                dvgCoordenadas.Rows.Add(indice, p.X, p.Y);
                indice++;
            }
        }

        private void panelDibujo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (puntoInicial == null)
            {
                puntoInicial = e.Location;
                return;
            }
            if (puntoFinal == null)
            {
                puntoFinal = e.Location;
                Linea linea = new Linea(puntoInicial.Value, puntoFinal.Value);
                controladorAntialiasing = new ControladorAntialiasing(linea);
                controladorAntialiasing.generarPuntos();
                rellenarTabla();

                if (chkProgresivo.Checked)
                    controladorProgresivo.IniciarProgresivo(controladorAntialiasing.puntos);
                else
                {
                    controladorProgresivo.IniciarPasoAPaso(controladorAntialiasing.puntos);
                    controladorProgresivo.MostrarTodo();
                }

                panelDibujo.Invalidate();
                puntoInicial = puntoFinal = null;
            }
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            dibujadorPlano.Dibujar(e.Graphics, panelDibujo.Width, panelDibujo.Height);

            if (controladorAntialiasing == null) return;

            List<Point> puntosADibujar = controladorProgresivo.ObtenerPuntosActuales();
            int grosorLinea = 3;
            using (Brush b = new SolidBrush(colorLinea))
                foreach (Point p in puntosADibujar)
                    e.Graphics.FillRectangle(b, p.X - grosorLinea / 2, p.Y - grosorLinea / 2, grosorLinea, grosorLinea);
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
            puntoInicial = null;
            puntoFinal = null;
            controladorAntialiasing = null;
            controladorProgresivo.Limpiar();
            dvgCoordenadas.Rows.Clear();
            btnPaso.Enabled = false;
            panelDibujo.Invalidate();
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

        private void FrmLineaAntialiasing_Load(object sender, EventArgs e)
        {
            DisenoUI.AplicarTema(this);
            btnPaso.Enabled = false;
            btnColor.BackColor = colorLinea;
        }
    }
}
