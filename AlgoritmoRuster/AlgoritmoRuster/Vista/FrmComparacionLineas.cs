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
    public partial class FrmComparacionLineas : Form
    {
        private DibujadorPlano dibujadorPlano;
        private Point? puntoInicial = null;
        private Point? puntoFinal = null;

        private List<ControladorDDA> controladoresDDA = new List<ControladorDDA>();
        private List<ControladorBresenham> controladoresBresenham = new List<ControladorBresenham>();
        private List<ControladorAntialiasing> controladoresAntialiasing = new List<ControladorAntialiasing>();

        public FrmComparacionLineas()
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
            if (controladoresDDA.Count == 0) return;

            int totalDDA = 0, totalBres = 0, totalAnti = 0;
            foreach (var c in controladoresDDA) totalDDA += c.puntos.Count;
            foreach (var c in controladoresBresenham) totalBres += c.puntos.Count;
            foreach (var c in controladoresAntialiasing) totalAnti += c.puntos.Count;

            dvgComparacion.Rows.Add("DDA", totalDDA, "Punto flotante");
            dvgComparacion.Rows.Add("Bresenham", totalBres, "Enteros");
            dvgComparacion.Rows.Add("Antialiasing", totalAnti, "Parametrico (t)");
            dvgComparacion.Rows.Add("Lineas trazadas", controladoresDDA.Count, "");
        }

        private void actualizarInfoAlgoritmo()
        {
            switch (cboAlgoritmo.SelectedItem?.ToString())
            {
                case "DDA":
                    lblAlgoritmoInfo.Text = "Incremental con punto flotante";
                    break;
                case "Bresenham":
                    lblAlgoritmoInfo.Text = "Incremental con enteros";
                    break;
                case "Antialiasing":
                    lblAlgoritmoInfo.Text = "Interpolacion parametrica (t)";
                    break;
                default:
                    lblAlgoritmoInfo.Text = "";
                    break;
            }
        }

        private void generarLineas(Linea linea)
        {
            var dda = new ControladorDDA(linea);
            dda.generarPuntos();
            controladoresDDA.Add(dda);

            var bres = new ControladorBresenham(linea);
            bres.generarPuntos();
            controladoresBresenham.Add(bres);

            var anti = new ControladorAntialiasing(linea);
            anti.generarPuntos();
            controladoresAntialiasing.Add(anti);

            rellenarTabla();
            panelDibujo.Invalidate();
        }

        private void panelDibujo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (cboAlgoritmo.SelectedItem == null) return;

            if (puntoInicial == null)
            {
                puntoInicial = e.Location;
                lblInfoPuntos.Text = $"Primer punto: ({e.X}, {e.Y}) — haga clic en el segundo punto";
                return;
            }
            if (puntoFinal == null)
            {
                puntoFinal = e.Location;
                lblInfoPuntos.Text = $"Linea {controladoresDDA.Count + 1}: ({puntoInicial.Value.X},{puntoInicial.Value.Y}) -> ({puntoFinal.Value.X},{puntoFinal.Value.Y})";
                generarLineas(new Linea(puntoInicial.Value, puntoFinal.Value));
                puntoInicial = null;
                puntoFinal = null;
            }
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            dibujadorPlano.Dibujar(e.Graphics, panelDibujo.Width, panelDibujo.Height);

            if (controladoresDDA.Count == 0) return;

            int grosorLinea = 3;
            string seleccion = cboAlgoritmo.SelectedItem?.ToString();
            Color[] colores = { Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Purple, Color.Brown };

            for (int i = 0; i < controladoresDDA.Count; i++)
            {
                List<Point> pts = null;
                switch (seleccion)
                {
                    case "DDA":         pts = controladoresDDA[i].puntos; break;
                    case "Bresenham":   pts = controladoresBresenham[i].puntos; break;
                    case "Antialiasing": pts = controladoresAntialiasing[i].puntos; break;
                }
                if (pts == null) continue;
                using (Brush b = new SolidBrush(colores[i % colores.Length]))
                    foreach (Point p in pts)
                        e.Graphics.FillRectangle(b, p.X - grosorLinea / 2, p.Y - grosorLinea / 2, grosorLinea, grosorLinea);
            }
        }

        private void cboAlgoritmo_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarInfoAlgoritmo();
            panelDibujo.Invalidate();
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            puntoInicial = null;
            puntoFinal = null;
            controladoresDDA.Clear();
            controladoresBresenham.Clear();
            controladoresAntialiasing.Clear();
            dvgComparacion.Rows.Clear();
            lblInfoPuntos.Text = "Haga clic en dos puntos del plano para trazar";
            lblAlgoritmoInfo.Text = "";
            panelDibujo.Invalidate();
        }

        private void FrmComparacionLineas_Load(object sender, EventArgs e)
        {
            DisenoUI.AplicarTema(this);
        }
    }
}
