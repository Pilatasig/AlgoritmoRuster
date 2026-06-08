using AlgoritmoRuster.Controlador;
using AlgoritmoRuster.Modelo;
using AlgoritmoRuster.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AlgoritmoRuster.Vista
{
    public partial class FrmCeldasDDA : Form
    {
        private PointF? puntoInicial;
        private PointF? puntoFinal;
        private List<PointF> puntosDDA;
        private ControladorDDA controladorDDA;
        private ControladorCelda controladorCelda;

        private Bitmap lienzoFondo;

        public FrmCeldasDDA()
        {
            InitializeComponent();
            puntoInicial = null;
            puntoFinal = null;
            controladorCelda = new ControladorCelda();
            puntosDDA = new List<PointF>();

            InicializarLienzoNuevo();
        }

        private void InicializarLienzoNuevo()
        {
            lienzoFondo = new Bitmap(panelDibujo.Width, panelDibujo.Height);

            using (Graphics gImage = Graphics.FromImage(lienzoFondo))
            {
                gImage.Clear(Color.White);

                controladorCelda.generarCeldas(panelDibujo.Width, panelDibujo.Height);
                controladorCelda.DibujarCeldasBase(gImage);
            }
        }

        private void panelDibujo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (puntoInicial == null)
                {
                    puntoInicial = e.Location;
                }
                else if (puntoFinal == null)
                {
                    puntoFinal = e.Location;

                    Linea nuevaLinea = new Linea(puntoInicial.Value, puntoFinal.Value);
                    controladorDDA = new ControladorDDA(nuevaLinea);
                    puntosDDA = controladorDDA.generarPuntos();

                    controladorCelda.actualizarEstadoCeldas(puntosDDA);

                    using (Graphics gImage = Graphics.FromImage(lienzoFondo))
                    {
                        controladorCelda.colorearCeldas(gImage);
                        controladorDDA.dibujarFigura(gImage);
                    }

                    panelDibujo.Invalidate();

                    puntoInicial = null;
                    puntoFinal = null;
                }
            }
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            if (lienzoFondo != null)
            {
                e.Graphics.DrawImage(lienzoFondo, 0, 0);
            }
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            puntoInicial = null;
            puntoFinal = null;
            puntosDDA.Clear();

            lienzoFondo?.Dispose();
            InicializarLienzoNuevo();

            panelDibujo.Invalidate();
        }

        private void FrmCeldasDDA_Load(object sender, EventArgs e)
        {
            DisenoUI.AplicarTema(this);
        }
    }
}