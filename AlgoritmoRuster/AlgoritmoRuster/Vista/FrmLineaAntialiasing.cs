using AlgoritmoRuster.Controlador.ControladorLinea;
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
    public partial class FrmLineaAntialiasing : Form
    {

        private ControladorAntialiasing controladorAntialiasing;
        private Point? puntoInicial = null;
        private Point? puntoFinal = null;
        private List<Point> puntos;

        public FrmLineaAntialiasing()
        {
            InitializeComponent();
            configurarTabla();
            puntos = new List<Point>();
        }

        private void limpiarFormulario()
        {
            puntoInicial = null;
            puntoFinal = null;
            controladorAntialiasing = null;
            dvgCoordenadas.Columns.Clear();
            configurarTabla();

            panelDibujo.Invalidate();
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
            if (controladorAntialiasing == null || puntos.Count == 0) return;

            int indice = 1;
            foreach(Point p in puntos)
            {
                dvgCoordenadas.Rows.Add(indice, p.X, p.Y);
                indice++;
            }
        }

        private void panelDibujo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (puntoInicial == null) { puntoInicial = e.Location; return; }
            if (puntoFinal == null)
            {
                puntoFinal = e.Location;
                Linea linea = new Linea(puntoInicial.Value, puntoFinal.Value);

                controladorAntialiasing = new ControladorAntialiasing(linea);
                controladorAntialiasing.generarPuntos();
                puntos = controladorAntialiasing.puntos;
                rellenarTabla();
                panelDibujo.Invalidate();

                puntoInicial = puntoFinal = null;
            }
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            if (controladorAntialiasing == null) return;

            controladorAntialiasing.dibujarFigura(e.Graphics);
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
        }

        private void FrmLineaAntialiasing_Load(object sender, EventArgs e)
        {
            DisenoUI.AplicarTema(this);
        }
    }
}
