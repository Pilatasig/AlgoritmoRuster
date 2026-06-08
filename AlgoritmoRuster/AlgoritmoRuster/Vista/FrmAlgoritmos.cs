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
    public partial class FrmAlgoritmos : Form
    {
        public FrmAlgoritmos()
        {
            InitializeComponent();
        }

        private void dDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLineaDDA frmLineaDDA = new FrmLineaDDA();
            frmLineaDDA.MdiParent = this;
            frmLineaDDA.Show();
        }

        private void celdasDDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCeldasDDA frmCeldasDDA = new FrmCeldasDDA();
            frmCeldasDDA.MdiParent = this;
            frmCeldasDDA.Show();
        }

        private void puntoMedioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCircunferencia frmCircunferencia = new FrmCircunferencia();
            frmCircunferencia.MdiParent = this;
            frmCircunferencia.Show();
        }

        private void rellenoFlodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRelleno frmRelleno = new FrmRelleno();
            frmRelleno.MdiParent = this;
            frmRelleno.Show();
        }

        private void bresenhamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLineaBresenham frmLineaBresenham = new FrmLineaBresenham();
            frmLineaBresenham.MdiParent = this;
            frmLineaBresenham.Show();
        }

        private void antialiasingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLineaAntialiasing frmLineaAntialiasing = new FrmLineaAntialiasing();
            frmLineaAntialiasing.MdiParent = this;
            frmLineaAntialiasing.Show();
        }

        private void parametricaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCircunferenciaParametrica frmCircunferencia = new FrmCircunferenciaParametrica();
            frmCircunferencia.MdiParent = this;
            frmCircunferencia.Show();
        }

        private void incrementalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCircunferenciaIncremental frmCircunferencia = new FrmCircunferenciaIncremental();
            frmCircunferencia.MdiParent = this;
            frmCircunferencia.Show();
        }

        private void cohenSoutherlandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCohenSoutherland frmCohen = new FrmCohenSoutherland();
            frmCohen.MdiParent = this;
            frmCohen.Show();
        }

    }
}
