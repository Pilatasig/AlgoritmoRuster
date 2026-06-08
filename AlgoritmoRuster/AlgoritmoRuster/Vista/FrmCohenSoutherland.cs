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

    public partial class FrmCohenSoutherland : Form
    {

        private DibujadorPlano planoCartesiano = new DibujadorPlano();

        public FrmCohenSoutherland()
        {
            InitializeComponent();
        }

        private void FrmCohenSoutherland_Load(object sender, EventArgs e)
        {
            DisenoUI.AplicarTema(this);
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

        }
    }
}
