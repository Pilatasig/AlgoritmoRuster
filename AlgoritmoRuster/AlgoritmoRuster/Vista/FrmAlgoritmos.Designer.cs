namespace AlgoritmoRuster.Vista
{
    partial class FrmAlgoritmos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.lineasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DDAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenhamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.antialiasingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comparacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circunferenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puntoMedioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametricaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incrementalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comparacionCircToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rellenoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rellenoFlodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comparacionRellenoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recortesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cohenSoutherlandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cyrusBeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liangBarskyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comparacionRecorteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sutherlandHodgmanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weilerAthertonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greinerHormannToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comparacionPoligonoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recortePoligonosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineasToolStripMenuItem,
            this.circunferenciaToolStripMenuItem,
            this.rellenoToolStripMenuItem,
            this.recortesToolStripMenuItem,
            this.recortePoligonosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lineasToolStripMenuItem
            // 
            this.lineasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DDAToolStripMenuItem,
            this.bresenhamToolStripMenuItem,
            this.antialiasingToolStripMenuItem,
            this.comparacionToolStripMenuItem});
            this.lineasToolStripMenuItem.Name = "lineasToolStripMenuItem";
            this.lineasToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.lineasToolStripMenuItem.Text = "Lineas";
            // 
            // DDAToolStripMenuItem
            // 
            this.DDAToolStripMenuItem.Name = "DDAToolStripMenuItem";
            this.DDAToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.DDAToolStripMenuItem.Text = "DDA";
            this.DDAToolStripMenuItem.Click += new System.EventHandler(this.dDAToolStripMenuItem_Click);
            // 
            // bresenhamToolStripMenuItem
            // 
            this.bresenhamToolStripMenuItem.Name = "bresenhamToolStripMenuItem";
            this.bresenhamToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.bresenhamToolStripMenuItem.Text = "Bresenham";
            this.bresenhamToolStripMenuItem.Click += new System.EventHandler(this.bresenhamToolStripMenuItem_Click);
            // 
            // antialiasingToolStripMenuItem
            // 
            this.antialiasingToolStripMenuItem.Name = "antialiasingToolStripMenuItem";
            this.antialiasingToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.antialiasingToolStripMenuItem.Text = "Antialiasing";
            this.antialiasingToolStripMenuItem.Click += new System.EventHandler(this.antialiasingToolStripMenuItem_Click);
            // 
            // comparacionToolStripMenuItem
            // 
            this.comparacionToolStripMenuItem.Name = "comparacionToolStripMenuItem";
            this.comparacionToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.comparacionToolStripMenuItem.Text = "Comparacion";
            this.comparacionToolStripMenuItem.Click += new System.EventHandler(this.comparacionToolStripMenuItem_Click);
            // 
            // circunferenciaToolStripMenuItem
            // 
            this.circunferenciaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.puntoMedioToolStripMenuItem,
            this.parametricaToolStripMenuItem,
            this.incrementalToolStripMenuItem,
            this.comparacionCircToolStripMenuItem});
            this.circunferenciaToolStripMenuItem.Name = "circunferenciaToolStripMenuItem";
            this.circunferenciaToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.circunferenciaToolStripMenuItem.Text = "Circunferencia";
            // 
            // puntoMedioToolStripMenuItem
            // 
            this.puntoMedioToolStripMenuItem.Name = "puntoMedioToolStripMenuItem";
            this.puntoMedioToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.puntoMedioToolStripMenuItem.Text = "PuntoMedio";
            this.puntoMedioToolStripMenuItem.Click += new System.EventHandler(this.puntoMedioToolStripMenuItem_Click);
            // 
            // parametricaToolStripMenuItem
            // 
            this.parametricaToolStripMenuItem.Name = "parametricaToolStripMenuItem";
            this.parametricaToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.parametricaToolStripMenuItem.Text = "Parametrica";
            this.parametricaToolStripMenuItem.Click += new System.EventHandler(this.parametricaToolStripMenuItem_Click);
            // 
            // incrementalToolStripMenuItem
            // 
            this.incrementalToolStripMenuItem.Name = "incrementalToolStripMenuItem";
            this.incrementalToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.incrementalToolStripMenuItem.Text = "Incremental";
            this.incrementalToolStripMenuItem.Click += new System.EventHandler(this.incrementalToolStripMenuItem_Click);
            // 
            // comparacionCircToolStripMenuItem
            // 
            this.comparacionCircToolStripMenuItem.Name = "comparacionCircToolStripMenuItem";
            this.comparacionCircToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.comparacionCircToolStripMenuItem.Text = "Comparacion";
            this.comparacionCircToolStripMenuItem.Click += new System.EventHandler(this.comparacionCircToolStripMenuItem_Click);
            // 
            // rellenoToolStripMenuItem
            // 
            this.rellenoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rellenoFlodToolStripMenuItem,
            this.comparacionRellenoToolStripMenuItem});
            this.rellenoToolStripMenuItem.Name = "rellenoToolStripMenuItem";
            this.rellenoToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.rellenoToolStripMenuItem.Text = "Relleno";
            // 
            // rellenoFlodToolStripMenuItem
            // 
            this.rellenoFlodToolStripMenuItem.Name = "rellenoFlodToolStripMenuItem";
            this.rellenoFlodToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.rellenoFlodToolStripMenuItem.Text = "Relleno";
            this.rellenoFlodToolStripMenuItem.Click += new System.EventHandler(this.rellenoFlodToolStripMenuItem_Click);
            // 
            // comparacionRellenoToolStripMenuItem
            // 
            this.comparacionRellenoToolStripMenuItem.Name = "comparacionRellenoToolStripMenuItem";
            this.comparacionRellenoToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.comparacionRellenoToolStripMenuItem.Text = "Comparacion";
            this.comparacionRellenoToolStripMenuItem.Click += new System.EventHandler(this.comparacionRellenoToolStripMenuItem_Click);
            // 
            // comparacionRecorteToolStripMenuItem
            // 
            this.comparacionRecorteToolStripMenuItem.Name = "comparacionRecorteToolStripMenuItem";
            this.comparacionRecorteToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.comparacionRecorteToolStripMenuItem.Text = "Comparacion";
            this.comparacionRecorteToolStripMenuItem.Click += new System.EventHandler(this.comparacionRecorteToolStripMenuItem_Click);
            // 
            // recortesToolStripMenuItem
            // 
            this.recortesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cohenSoutherlandToolStripMenuItem,
            this.cyrusBeckToolStripMenuItem,
            this.liangBarskyToolStripMenuItem,
            this.comparacionRecorteToolStripMenuItem});
            this.recortesToolStripMenuItem.Name = "recortesToolStripMenuItem";
            this.recortesToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.recortesToolStripMenuItem.Text = "Recortes";
            // 
            // recortePoligonosToolStripMenuItem
            // 
            this.recortePoligonosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sutherlandHodgmanToolStripMenuItem,
            this.weilerAthertonToolStripMenuItem,
            this.greinerHormannToolStripMenuItem,
            this.comparacionPoligonoToolStripMenuItem});
            this.recortePoligonosToolStripMenuItem.Name = "recortePoligonosToolStripMenuItem";
            this.recortePoligonosToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.recortePoligonosToolStripMenuItem.Text = "Recorte Poligonos";
            // 
            // cohenSoutherlandToolStripMenuItem
            // 
            this.cohenSoutherlandToolStripMenuItem.Name = "cohenSoutherlandToolStripMenuItem";
            this.cohenSoutherlandToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cohenSoutherlandToolStripMenuItem.Text = "Cohen-Southerland";
            this.cohenSoutherlandToolStripMenuItem.Click += new System.EventHandler(this.cohenSoutherlandToolStripMenuItem_Click);
            // 
            // cyrusBeckToolStripMenuItem
            // 
            this.cyrusBeckToolStripMenuItem.Name = "cyrusBeckToolStripMenuItem";
            this.cyrusBeckToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cyrusBeckToolStripMenuItem.Text = "Cyrus-Beck";
            this.cyrusBeckToolStripMenuItem.Click += new System.EventHandler(this.cyrusBeckToolStripMenuItem_Click);
            // 
            // liangBarskyToolStripMenuItem
            // 
            this.liangBarskyToolStripMenuItem.Name = "liangBarskyToolStripMenuItem";
            this.liangBarskyToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.liangBarskyToolStripMenuItem.Text = "Liang-Barsky";
            this.liangBarskyToolStripMenuItem.Click += new System.EventHandler(this.liangBarskyToolStripMenuItem_Click);
            // 
            // sutherlandHodgmanToolStripMenuItem
            // 
            this.sutherlandHodgmanToolStripMenuItem.Name = "sutherlandHodgmanToolStripMenuItem";
            this.sutherlandHodgmanToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sutherlandHodgmanToolStripMenuItem.Text = "Sutherland-Hodgman";
            this.sutherlandHodgmanToolStripMenuItem.Click += new System.EventHandler(this.sutherlandHodgmanToolStripMenuItem_Click);
            // 
            // weilerAthertonToolStripMenuItem
            // 
            this.weilerAthertonToolStripMenuItem.Name = "weilerAthertonToolStripMenuItem";
            this.weilerAthertonToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.weilerAthertonToolStripMenuItem.Text = "Weiler-Atherton";
            this.weilerAthertonToolStripMenuItem.Click += new System.EventHandler(this.weilerAthertonToolStripMenuItem_Click);
            // 
            // greinerHormannToolStripMenuItem
            // 
            this.greinerHormannToolStripMenuItem.Name = "greinerHormannToolStripMenuItem";
            this.greinerHormannToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.greinerHormannToolStripMenuItem.Text = "Greiner-Hormann";
            this.greinerHormannToolStripMenuItem.Click += new System.EventHandler(this.greinerHormannToolStripMenuItem_Click);
            // 
            // comparacionPoligonoToolStripMenuItem
            // 
            this.comparacionPoligonoToolStripMenuItem.Name = "comparacionPoligonoToolStripMenuItem";
            this.comparacionPoligonoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.comparacionPoligonoToolStripMenuItem.Text = "Comparacion";
            this.comparacionPoligonoToolStripMenuItem.Click += new System.EventHandler(this.comparacionPoligonoToolStripMenuItem_Click);
            // 
            // FrmAlgoritmos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmAlgoritmos";
            this.Text = "FrmDDA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem lineasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DDAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circunferenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puntoMedioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rellenoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rellenoFlodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bresenhamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem antialiasingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametricaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incrementalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recortesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cohenSoutherlandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comparacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comparacionCircToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comparacionRellenoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cyrusBeckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liangBarskyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comparacionRecorteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sutherlandHodgmanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recortePoligonosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weilerAthertonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greinerHormannToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comparacionPoligonoToolStripMenuItem;
    }
}