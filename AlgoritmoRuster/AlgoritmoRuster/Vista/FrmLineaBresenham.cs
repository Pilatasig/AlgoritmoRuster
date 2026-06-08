using AlgoritmoRuster.Controlador.ControladorLinea;
using AlgoritmoRuster.Modelo;
using AlgoritmoRuster.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoRuster.Vista
{
    public partial class FrmLineaBresenham : Form
    {
        private ControladorBresenham controladorBresenham;
        private Point? puntoInicial = null;
        private Point? puntoFinal = null;
        private List<Point> puntos;
        public FrmLineaBresenham()
        {
            InitializeComponent();
            puntos= new List<Point>();
            configurarTabla();
        }

        private void limpiarFormulario()
        {
            puntoInicial = null;
            puntoFinal = null;
            controladorBresenham = null;
            dvgCoordenadas.Columns.Clear();
            configurarTabla();

            panelDibujo.Invalidate();
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
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
            if (controladorBresenham == null || puntos.Count == 0) return;

            int indice = 1;
            foreach(PointF punto in puntos)
            {
                dvgCoordenadas.Rows.Add(indice, punto.X, punto.Y);
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
                controladorBresenham = new ControladorBresenham(linea);
                controladorBresenham.generarPuntos();
                puntos = controladorBresenham.puntos;
                panelDibujo.Invalidate();
                rellenarTabla();
                puntoFinal = puntoInicial = null;
            }
        }



        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            if (controladorBresenham == null) return;

            controladorBresenham.dibujarFigura(e.Graphics);
        }

        private void FrmLineaBresenham_Load(object sender, EventArgs e)
        {
            DisenoUI.AplicarTema(this);
        }
    }
}
