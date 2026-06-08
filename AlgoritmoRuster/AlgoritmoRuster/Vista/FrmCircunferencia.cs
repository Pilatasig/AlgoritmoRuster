using AlgoritmoRuster.Controlador;
using AlgoritmoRuster.Modelo;
using AlgoritmoRuster.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlgoritmoRuster.Vista
{
    public partial class FrmCircunferencia : Form
    {
        private ControladorPuntoMedio controladorPuntoMedio;
        private float cx;
        private float cy;
        private bool centroDefinido = false;

        public FrmCircunferencia()
        {
            InitializeComponent();
            ConfigurarTabla();
        }

        private void ConfigurarTabla()
        {
            dgvCoordenadas.Columns.Clear();
            dgvCoordenadas.Columns.Add("Num", "N°");
            dgvCoordenadas.Columns.Add("X", "Coordenada X");
            dgvCoordenadas.Columns.Add("Y", "Coordenada Y");

            dgvCoordenadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

            DibujarYRefrescar(radio);
        }

        private void DibujarYRefrescar(float radio)
        {
            PointF centro = new PointF(cx, cy);
            Circunferencia circunferencia = new Circunferencia(centro, radio);

            controladorPuntoMedio = new ControladorPuntoMedio(circunferencia);
            controladorPuntoMedio.generarPuntos();

            panelDibujo.Invalidate();
            panelDibujo.Update();

            LlenarTablaCoordenadas();
        }

        private void LlenarTablaCoordenadas()
        {
            dgvCoordenadas.Rows.Clear();

            if (controladorPuntoMedio == null || controladorPuntoMedio.puntos == null || controladorPuntoMedio.puntos.Count == 0)
                return;

            int indice = 1;
            foreach (PointF p in controladorPuntoMedio.puntos)
            {
                dgvCoordenadas.Rows.Add(indice, p.X, p.Y);
                indice++;
            }
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            if (controladorPuntoMedio == null || !centroDefinido) return;

            controladorPuntoMedio.dibujarFigura(e.Graphics);
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            cx = 0;
            cy = 0;
            centroDefinido = false;

            controladorPuntoMedio = null;


            txtRadio.Clear();
            dgvCoordenadas.Rows.Clear();

            panelDibujo.Invalidate();
            panelDibujo.Update();

            txtRadio.Focus();
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

            DibujarYRefrescar(radio);
        }

        private void FrmCircunferencia_Load(object sender, EventArgs e)
        {
            DisenoUI.AplicarTema(this);
        }
    }
}