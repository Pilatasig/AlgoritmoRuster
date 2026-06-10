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

        private void comparacionCircToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmComparacionCircunferencia frm = new FrmComparacionCircunferencia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cohenSoutherlandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCohenSoutherland frmCohen = new FrmCohenSoutherland();
            frmCohen.MdiParent = this;
            frmCohen.Show();
        }

        private void comparacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmComparacionLineas frmComparacion = new FrmComparacionLineas();
            frmComparacion.MdiParent = this;
            frmComparacion.Show();
        }

        private void comparacionRellenoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmComparacionRelleno frm = new FrmComparacionRelleno();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cyrusBeckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCyrusBeck frmCyrus = new FrmCyrusBeck();
            frmCyrus.MdiParent = this;
            frmCyrus.Show();
        }

        private void liangBarskyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLiangBarsky frm = new FrmLiangBarsky();
            frm.MdiParent = this;
            frm.Show();
        }

        private void comparacionRecorteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmComparacionRecorte frm = new FrmComparacionRecorte();
            frm.MdiParent = this;
            frm.Show();
        }

        private void sutherlandHodgmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSutherlandHodgman frm = new FrmSutherlandHodgman();
            frm.MdiParent = this;
            frm.Show();
        }

        private void weilerAthertonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmWeilerAtherton frm = new FrmWeilerAtherton();
            frm.MdiParent = this;
            frm.Show();
        }

        private void greinerHormannToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGreinerHormann frm = new FrmGreinerHormann();
            frm.MdiParent = this;
            frm.Show();
        }

        private void comparacionPoligonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmComparacionPoligono frm = new FrmComparacionPoligono();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bezierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBezier frm = new FrmBezier();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
