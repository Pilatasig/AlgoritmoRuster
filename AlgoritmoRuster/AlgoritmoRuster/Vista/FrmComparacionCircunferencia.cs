using AlgoritmoRuster.Controlador;
using AlgoritmoRuster.Controlador.ControladorCircunferencia;
using AlgoritmoRuster.Modelo;
using AlgoritmoRuster.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlgoritmoRuster.Vista
{
    public partial class FrmComparacionCircunferencia : Form
    {
        private DibujadorPlano dibujadorPlano;
        private Point? centro = null;

        private ControladorPuntoMedio controladorPuntoMedio;
        private ControladorIncremental controladorIncremental;
        private ControladorParamétrica controladorParametrica;

        public FrmComparacionCircunferencia()
        {
            InitializeComponent();
            dibujadorPlano = new DibujadorPlano();
            configurarTabla();
            cboAlgoritmo.SelectedIndex = 0;
        }

        private void configurarTabla()
        {
            dvgComparacion.Columns.Clear();
            dvgComparacion.Columns.Add("Algoritmo", "Algoritmo");
            dvgComparacion.Columns.Add("Pixeles", "Pixeles");
            dvgComparacion.Columns.Add("Tipo", "Tipo");
            dvgComparacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void rellenarTabla()
        {
            dvgComparacion.Rows.Clear();
            if (controladorPuntoMedio == null) return;

            dvgComparacion.Rows.Add("Punto Medio", controladorPuntoMedio.puntos.Count, "Enteros (simetria 8)");
            dvgComparacion.Rows.Add("Incremental", controladorIncremental.puntos.Count, "Trigonometrico (float)");
            dvgComparacion.Rows.Add("Parametrica", controladorParametrica.puntos.Count, "Parametrico (t)");
        }

        private void actualizarInfoAlgoritmo()
        {
            switch (cboAlgoritmo.SelectedItem?.ToString())
            {
                case "PuntoMedio":
                    lblAlgoritmoInfo.Text = "Incremental con enteros y simetria";
                    break;
                case "Incremental":
                    lblAlgoritmoInfo.Text = "Rotacion vectorial acumulativa";
                    break;
                case "Parametrica":
                    lblAlgoritmoInfo.Text = "Evaluacion directa seno/coseno";
                    break;
                default:
                    lblAlgoritmoInfo.Text = "";
                    break;
            }
        }

        private void generarCircunferencias()
        {
            if (centro == null) return;

            float radio;
            if (!float.TryParse(txtRadio.Text, out radio)) return;

            Circunferencia circ = new Circunferencia(new PointF(centro.Value.X, centro.Value.Y), radio);

            controladorPuntoMedio = new ControladorPuntoMedio(circ);
            controladorPuntoMedio.generarPuntos();

            controladorIncremental = new ControladorIncremental(centro.Value, radio);
            controladorIncremental.generarPuntos();

            controladorParametrica = new ControladorParamétrica(circ);
            controladorParametrica.generarPuntos();

            rellenarTabla();
            panelDibujo.Invalidate();
            lblInfoPuntos.Text = $"Centro: ({centro.Value.X},{centro.Value.Y})  Radio: {radio}";
        }

        private void panelDibujo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (cboAlgoritmo.SelectedItem == null) return;
            if (!float.TryParse(txtRadio.Text, out _))
            {
                MessageBox.Show("Ingrese un valor numerico valido para el radio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            centro = e.Location;
            generarCircunferencias();
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            dibujadorPlano.Dibujar(e.Graphics, panelDibujo.Width, panelDibujo.Height);

            if (controladorPuntoMedio == null) return;

            int grosorLinea = 3;
            string seleccion = cboAlgoritmo.SelectedItem?.ToString();
            Color color = Color.Red;

            object puntosADibujar = null;

            switch (seleccion)
            {
                case "PuntoMedio":
                    puntosADibujar = controladorPuntoMedio.puntos;
                    color = Color.Red;
                    break;
                case "Incremental":
                    puntosADibujar = controladorIncremental.puntos;
                    color = Color.Blue;
                    break;
                case "Parametrica":
                    puntosADibujar = controladorParametrica.puntos;
                    color = Color.Green;
                    break;
            }

            if (puntosADibujar != null)
            {
                using (Brush b = new SolidBrush(color))
                {
                    if (puntosADibujar is System.Collections.Generic.List<Point> pts)
                        foreach (Point p in pts)
                            e.Graphics.FillRectangle(b, p.X - grosorLinea / 2, p.Y - grosorLinea / 2, grosorLinea, grosorLinea);
                }
            }
        }

        private void cboAlgoritmo_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarInfoAlgoritmo();
            panelDibujo.Invalidate();
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            centro = null;
            txtRadio.Clear();
            controladorPuntoMedio = null;
            controladorIncremental = null;
            controladorParametrica = null;
            dvgComparacion.Rows.Clear();
            lblInfoPuntos.Text = "Ingrese radio y haga clic en el plano para definir centro";
            lblAlgoritmoInfo.Text = "";
            panelDibujo.Invalidate();
        }

        private void FrmComparacionCircunferencia_Load(object sender, EventArgs e)
        {
            DisenoUI.AplicarTema(this);
        }
    }
}
