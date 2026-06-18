using Bohorquez_Camila_2p.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bohorquez_Camila_2p.Vista
{
    public partial class Home : Form
    {
        private DibujadorFigura db;
        public Home()
        {
            InitializeComponent();
            db = new DibujadorFigura();
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            if (db == null) return;

            db.dibujar(e.Graphics, panelDibujo.Width + 1, panelDibujo.Height + 1);
        }
    }
}
