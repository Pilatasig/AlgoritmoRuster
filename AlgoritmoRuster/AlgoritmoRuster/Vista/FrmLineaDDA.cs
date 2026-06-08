using AlgoritmoRuster.Controlador;
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
    public partial class FrmLineaDDA : Form
    {
        private Point? puntoInicial = null;
        private Point? puntoFinal = null;

        public FrmLineaDDA()
        {
            InitializeComponent();
        }

        private void limpiarPanel()
        {
            panelDibujo.Invalidate();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (puntoInicial == null)
                {
                    puntoInicial = e.Location;
                    return;
                }
                else if (puntoFinal == null)
                {
                    puntoFinal = e.Location;

                    Linea nuevaLinea = new Linea(puntoInicial.Value, puntoFinal.Value);

                    ControladorDDA controladorDDA = new ControladorDDA(nuevaLinea);

                    using (Graphics g = panelDibujo.CreateGraphics())
                    {
                        controladorDDA.dibujarFigura(g);
                    }

                    puntoInicial = null;
                    puntoFinal = null;
                }
            }
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            limpiarPanel();
        }

        private void FrmLineaDDA_Load(object sender, EventArgs e)
        {
            DisenoUI.AplicarTema(this);
        }
    }
}