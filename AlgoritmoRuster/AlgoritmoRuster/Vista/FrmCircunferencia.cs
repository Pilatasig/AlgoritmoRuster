using AlgoritmoRuster.Controlador;
using AlgoritmoRuster.Modelo;
using AlgoritmoRuster.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AlgoritmoRuster.Vista
{
    public partial class FrmCircunferencia : Form
    {
        private ControladorPuntoMedio controladorPuntoMedio;
        private ControladorProgresivo controladorProgresivo;
        private DibujadorPlano dibujadorPlano;
        private float cx;
        private float cy;
        private bool centroDefinido = false;
        private Color colorLinea = Color.Red;

        public FrmCircunferencia()
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
            dgvCoordenadas.Columns.Clear();
            dgvCoordenadas.Columns.Add("Num", "N°");
            dgvCoordenadas.Columns.Add("X", "Coordenada X");
            dgvCoordenadas.Columns.Add("Y", "Coordenada Y");
            dgvCoordenadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void rellenarTabla()
        {
            dgvCoordenadas.Rows.Clear();
            if (controladorPuntoMedio == null) return;
            int indice = 1;
            foreach (Point p in controladorPuntoMedio.puntos)
            {
                dgvCoordenadas.Rows.Add(indice, p.X, p.Y);
                indice++;
            }
        }

        private void dibujarYRefrescar(float radio)
        {
            PointF centro = new PointF(cx, cy);
            Circunferencia circunferencia = new Circunferencia(centro, radio);
            controladorPuntoMedio = new ControladorPuntoMedio(circunferencia);
            controladorPuntoMedio.generarPuntos();
            rellenarTabla();

            if (chkProgresivo.Checked)
                controladorProgresivo.IniciarProgresivo(controladorPuntoMedio.puntos);
            else
            {
                controladorProgresivo.IniciarPasoAPaso(controladorPuntoMedio.puntos);
                controladorProgresivo.MostrarTodo();
            }
            panelDibujo.Invalidate();
        }

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(txtRadio.Text, out float radio))
            {
                MessageBox.Show("Por favor, ingresa un número válido para el radio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!centroDefinido)
            {
                cx = panelDibujo.Width / 2f;
                cy = panelDibujo.Height / 2f;
                centroDefinido = true;
            }
            dibujarYRefrescar(radio);
        }

        private void panelDibujo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (!float.TryParse(txtRadio.Text, out float radio))
            {
                MessageBox.Show("Por favor, primero ingresa un número válido para el radio.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cx = e.X;
            cy = e.Y;
            centroDefinido = true;
            dibujarYRefrescar(radio);
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            dibujadorPlano.Dibujar(e.Graphics, panelDibujo.Width, panelDibujo.Height);

            if (controladorPuntoMedio == null) return;

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
            cx = 0;
            cy = 0;
            centroDefinido = false;
            controladorPuntoMedio = null;
            controladorProgresivo.Limpiar();
            txtRadio.Clear();
            dgvCoordenadas.Rows.Clear();
            btnPaso.Enabled = false;
            panelDibujo.Invalidate();
            txtRadio.Focus();
        }

        private void FrmCircunferencia_Load(object sender, EventArgs e)
        {
            DisenoUI.AplicarTema(this);
            btnPaso.Enabled = false;
            btnColor.BackColor = colorLinea;
        }
    }
}