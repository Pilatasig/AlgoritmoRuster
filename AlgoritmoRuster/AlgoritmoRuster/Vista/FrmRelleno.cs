using AlgoritmoRuster.Controlador.ControladorRelleno;
using AlgoritmoRuster.Modelo;
using AlgoritmoRuster.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoRuster.Vista
{
    public partial class FrmRelleno : Form
    {

        private Canvas modelo;
        private ControladorCanvas controlador;

        private bool esPrimerClic = true;
        private Point primerClic;
        public FrmRelleno()
        {
            InitializeComponent();
        }

        private void btnCirculo_Click(object sender, EventArgs e)
        {
            controlador.setHerramienta("Circulo");
            resetearClics();
        }

        private void btnRectangulo_Click(object sender, EventArgs e)
        {
            controlador.setHerramienta("Rectangulo");
            resetearClics();
        }

        private void btnEstrella_Click(object sender, EventArgs e)
        {
            controlador.setHerramienta("Estrella");
            resetearClics();
        }

        private void btnBalde_Click(object sender, EventArgs e)
        {
            controlador.setHerramienta("Balde");
            resetearClics();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                controlador.setColor(colorDialog.Color);
                panelColor.BackColor = colorDialog.Color;
            }
        }

        private void resetearClics()
        {
            esPrimerClic = true;
            primerClic = Point.Empty;
        }

        private async void panelDibujo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            string herramienta = modelo.herramientaSeleccionada;

            if (herramienta == "Circulo" || herramienta == "Rectangulo" ||herramienta=="Estrella")
            {
                if (esPrimerClic)
                {
                    primerClic = e.Location;
                    esPrimerClic = false;
                }
                else
                {
                    controlador.dibujarFigura(herramienta, primerClic, e.Location);
                    esPrimerClic = true;
                }
            }
            else if (herramienta == "Balde")
            {
                panelDibujo.Enabled = false;
                await controlador.aplicarRelleno(e.Location, panelDibujo);
                panelDibujo.Enabled = true;
            }

            panelDibujo.Invalidate();
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            if (controlador == null) return;
            e.Graphics.DrawImage(controlador.getBitMap(), 0, 0);
        }

        private void FrmRelleno_Load(object sender, EventArgs e)
        {
            DisenoUI.AplicarTema(this);

            modelo = new Canvas(panelDibujo.Width, panelDibujo.Height);
            controlador = new ControladorCanvas(modelo);

            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, panelDibujo, new object[] { true });

            cmbAlgoritmo.Items.Clear();

            cmbAlgoritmo.Items.Add("Inundacion Recursivo");
            cmbAlgoritmo.Items.Add("Inundacion 8 vecinos");
            cmbAlgoritmo.Items.Add("ScanLines");

            cmbAlgoritmo.SelectedIndex = 0;

            panelColor.BackColor = colorDialog.Color;

            
        }

        private void cmbAlgoritmo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (controlador == null) return;

            switch (cmbAlgoritmo.SelectedItem.ToString())
            {
                case "Inundacion Recursivo":
                    controlador.controladorRelleno = new ControladorInundacion();
                    break;

                case "Inundacion 8 vecinos":
                    controlador.controladorRelleno = new ControladorCola();
                    break;

                case "ScanLines":
                    controlador.controladorRelleno = new ControladorScanLine();
                    break;
            }

            resetearClics();
        }

    }
}
