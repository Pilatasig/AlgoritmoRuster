using AlgoritmoRuster.Controlador.ControladorCircunferencia;
using AlgoritmoRuster.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoRuster.Vista
{
    public partial class FrmCircunferenciaIncremental : Form
    {

        private Point? centro = null;
        private ControladorIncremental controlador;
        private List<Point> puntosGenerados;

        public FrmCircunferenciaIncremental()
        {
            InitializeComponent();
            configurarTabla();
        }

        private void limpiarFormulario()
        {
            centro = null;
            txtRadio.Clear();
            controlador = null;
            puntosGenerados.Clear();
            dvgCoordenadas.Rows.Clear();

            panelDibujo.Invalidate();
        }

        private void configurarTabla()
        {
            dvgCoordenadas.Columns.Clear();
            dvgCoordenadas.Columns.Add("Num", "N°");
            dvgCoordenadas.Columns.Add("X", "Coordenadas X");
            dvgCoordenadas.Columns.Add("Y", "Coordenadas Y");

            dvgCoordenadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
        }

        private void rellenarTabla()
        {
            dvgCoordenadas.Rows.Clear();
            if (controlador == null || puntosGenerados.Count == 0) return;

            int indice = 1;

            foreach(Point p in puntosGenerados)
            {
                dvgCoordenadas.Rows.Add(indice, p.X, p.Y);
                indice++;
            }

        }
        private void panelDibujo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if(!float.TryParse(txtRadio.Text, out float radio))
            {
                MessageBox.Show("Ingrese un valor numérico válido para el radio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            centro = e.Location;
            controlador = new ControladorIncremental(centro.Value, radio);
            controlador.generarPuntos();
            puntosGenerados = controlador.puntos;
            rellenarTabla();
            panelDibujo.Invalidate();
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            if (controlador == null) return;

            controlador.dibujarFigura(e.Graphics);
        }

        private void FrmCircunferenciaIncremental_Load(object sender, EventArgs e)
        {
            DisenoUI.AplicarTema(this);
        }
    }
}
