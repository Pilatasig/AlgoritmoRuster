using AlgoritmoRuster.Controlador.ControladorRelleno;
using AlgoritmoRuster.Modelo;
using AlgoritmoRuster.Utils;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoRuster.Vista
{
    public partial class FrmRelleno : Form
    {
        private Canvas modelo;
        private ControladorCanvas controlador;
        private DibujadorPlano dibujadorPlano;
        private bool esPrimerClic = true;
        private Point primerClic;

        public FrmRelleno()
        {
            InitializeComponent();
            dibujadorPlano = new DibujadorPlano();
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

            if (herramienta == "Circulo" || herramienta == "Rectangulo" || herramienta == "Estrella")
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
                controlador.DelayMs = obtenerDelay();
                panelDibujo.Enabled = false;
                await controlador.aplicarRelleno(e.Location, panelDibujo);
                panelDibujo.Enabled = true;
            }
            panelDibujo.Invalidate();
        }

        private int obtenerDelay()
        {
            int valorInvertido = 101 - trackBarVelocidad.Value;
            return Math.Max(0, valorInvertido);
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            dibujadorPlano.Dibujar(e.Graphics, panelDibujo.Width, panelDibujo.Height);
            if (controlador != null)
            {
                Bitmap bmp = controlador.getBitMap();
                using (var attr = new System.Drawing.Imaging.ImageAttributes())
                {
                    attr.SetColorKey(Color.White, Color.White);
                    e.Graphics.DrawImage(bmp,
                        new Rectangle(0, 0, bmp.Width, bmp.Height),
                        0, 0, bmp.Width, bmp.Height,
                        GraphicsUnit.Pixel, attr);
                }
            }
        }

        private void trackBarVelocidad_Scroll(object sender, EventArgs e)
        {
            lblVelocidad.Text = $"Velocidad: {trackBarVelocidad.Value}";
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            controlador.setHerramienta("Circulo");
            resetearClics();
            modelo = new Canvas(panelDibujo.Width, panelDibujo.Height);
            controlador = new ControladorCanvas(modelo);
            controlador.setColor(Color.Black);
            panelDibujo.Enabled = true;
            cmbAlgoritmo_SelectedIndexChanged(null, null);
            panelDibujo.Invalidate();
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
                    lblTitulo.Text = "Inundacion Recursivo";
                    lblFormula.Text = "Formula: Comparacion recursiva 4-vecinos";
                    lblCriterio.Text = "Criterio: Llamada recursiva en N, S, E, O";
                    lblTipo.Text = "Tipo: Relleno por inundacion recursivo";
                    lblComplejidad.Text = "Complejidad: O(n) - riesgo de stack overflow";
                    lblDecision.Text = "Decision: Usa recursion (pila del sistema)";
                    break;

                case "Inundacion 8 vecinos":
                    controlador.controladorRelleno = new ControladorCola();
                    lblTitulo.Text = "Inundacion 8 vecinos";
                    lblFormula.Text = "Formula: Comparacion con cola de pixeles";
                    lblCriterio.Text = "Criterio: Procesa 8 direcciones por pixel";
                    lblTipo.Text = "Tipo: Relleno por inundacion con cola";
                    lblComplejidad.Text = "Complejidad: O(n) - evita stack overflow";
                    lblDecision.Text = "Decision: Usa cola (memoria heap)";
                    break;

                case "ScanLines":
                    controlador.controladorRelleno = new ControladorScanLine();
                    lblTitulo.Text = "ScanLines";
                    lblFormula.Text = "Formula: Relleno horizontal por scanline";
                    lblCriterio.Text = "Criterio: Escanea lineas horizontales continuas";
                    lblTipo.Text = "Tipo: Relleno por scanline + pila";
                    lblComplejidad.Text = "Complejidad: O(n) - optimo para areas grandes";
                    lblDecision.Text = "Decision: Agrupa pixeles en lineas continuas";
                    break;
            }
            resetearClics();
        }
    }
}
