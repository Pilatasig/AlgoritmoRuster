using AlgoritmoRuster.Controlador.ControladorCircunferencia;
using AlgoritmoRuster.Modelo;
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
    public partial class FrmCircunferenciaParametrica : Form
    {
        private Point? centro = null;
        private ControladorParamétrica controlador;
        private List<Point> puntosGenerados = new List<Point>();

        public FrmCircunferenciaParametrica()
        {
            InitializeComponent();
            ConfigurarTabla();
        }

        private void ConfigurarTabla()
        {
            dvgCoordenadas.Columns.Clear();
            dvgCoordenadas.Columns.Add("Num", "N°");
            dvgCoordenadas.Columns.Add("X", "Coordenadas X");
            dvgCoordenadas.Columns.Add("Y", "Coordenadas Y");

            dvgCoordenadas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void limpiarFormulario()
        {
            txtRadio.Clear();
            controlador = null;
            centro = null;
            dvgCoordenadas.Rows.Clear();
            puntosGenerados.Clear();
            panelDibujo.Invalidate();
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
        }

        private void panelDibujo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (!float.TryParse(txtRadio.Text, out float radio))
            {
                MessageBox.Show("Ingrese un valor numérico válido para el radio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            centro = e.Location;
            dibujarYRefrescar(radio);

        }

        private void dibujarYRefrescar(float radio)
        {
            if (centro == null) return;
            Circunferencia circunferencia = new Circunferencia(centro.Value, radio);
            controlador = new ControladorParamétrica(circunferencia);
            controlador.generarPuntos();
            puntosGenerados = controlador.puntos;
            rellenarTabla();
            panelDibujo.Invalidate();
            panelDibujo.Update();
        }

        private void rellenarTabla()
        {
            dvgCoordenadas.Rows.Clear();

            if (controlador == null || puntosGenerados.Count == 0) return;

            int indice = 1;
            foreach (Point punto in puntosGenerados)
            {
                dvgCoordenadas.Rows.Add(indice, punto.X, punto.Y);
                indice++;
            }
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            if (controlador == null) return;

            controlador.dibujarFigura(e.Graphics);
        }

        private void FrmCircunferenciaParametrica_Load(object sender, EventArgs e)
        {
            DisenoUI.AplicarTema(this);
        }
    }
}
