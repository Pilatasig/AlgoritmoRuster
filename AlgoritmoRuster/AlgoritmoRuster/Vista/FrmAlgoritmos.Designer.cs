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
            this.celdasDDAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenhamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.antialiasingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circunferenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puntoMedioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametricaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incrementalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rellenoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rellenoFlodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recortesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cohenSoutherlandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.recortesToolStripMenuItem});
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
            this.celdasDDAToolStripMenuItem,
            this.bresenhamToolStripMenuItem,
            this.antialiasingToolStripMenuItem});
            this.lineasToolStripMenuItem.Name = "lineasToolStripMenuItem";
            this.lineasToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.lineasToolStripMenuItem.Text = "Lineas";
            // 
            // DDAToolStripMenuItem
            // 
            this.DDAToolStripMenuItem.Name = "DDAToolStripMenuItem";
            this.DDAToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.DDAToolStripMenuItem.Text = "DDA";
            this.DDAToolStripMenuItem.Click += new System.EventHandler(this.dDAToolStripMenuItem_Click);
            // 
            // celdasDDAToolStripMenuItem
            // 
            this.celdasDDAToolStripMenuItem.Name = "celdasDDAToolStripMenuItem";
            this.celdasDDAToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.celdasDDAToolStripMenuItem.Text = "CeldasDDA";
            this.celdasDDAToolStripMenuItem.Click += new System.EventHandler(this.celdasDDAToolStripMenuItem_Click);
            // 
            // bresenhamToolStripMenuItem
            // 
            this.bresenhamToolStripMenuItem.Name = "bresenhamToolStripMenuItem";
            this.bresenhamToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.bresenhamToolStripMenuItem.Text = "Bresenham";
            this.bresenhamToolStripMenuItem.Click += new System.EventHandler(this.bresenhamToolStripMenuItem_Click);
            // 
            // antialiasingToolStripMenuItem
            // 
            this.antialiasingToolStripMenuItem.Name = "antialiasingToolStripMenuItem";
            this.antialiasingToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.antialiasingToolStripMenuItem.Text = "Antialiasing";
            this.antialiasingToolStripMenuItem.Click += new System.EventHandler(this.antialiasingToolStripMenuItem_Click);
            // 
            // circunferenciaToolStripMenuItem
            // 
            this.circunferenciaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.puntoMedioToolStripMenuItem,
            this.parametricaToolStripMenuItem,
            this.incrementalToolStripMenuItem});
            this.circunferenciaToolStripMenuItem.Name = "circunferenciaToolStripMenuItem";
            this.circunferenciaToolStripMenuItem.Size = new System.Drawing.Size(117, 24);
            this.circunferenciaToolStripMenuItem.Text = "Circunferencia";
            // 
            // puntoMedioToolStripMenuItem
            // 
            this.puntoMedioToolStripMenuItem.Name = "puntoMedioToolStripMenuItem";
            this.puntoMedioToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.puntoMedioToolStripMenuItem.Text = "PuntoMedio";
            this.puntoMedioToolStripMenuItem.Click += new System.EventHandler(this.puntoMedioToolStripMenuItem_Click);
            // 
            // parametricaToolStripMenuItem
            // 
            this.parametricaToolStripMenuItem.Name = "parametricaToolStripMenuItem";
            this.parametricaToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.parametricaToolStripMenuItem.Text = "Parametrica";
            this.parametricaToolStripMenuItem.Click += new System.EventHandler(this.parametricaToolStripMenuItem_Click);
            // 
            // incrementalToolStripMenuItem
            // 
            this.incrementalToolStripMenuItem.Name = "incrementalToolStripMenuItem";
            this.incrementalToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.incrementalToolStripMenuItem.Text = "Incremental";
            this.incrementalToolStripMenuItem.Click += new System.EventHandler(this.incrementalToolStripMenuItem_Click);
            // 
            // rellenoToolStripMenuItem
            // 
            this.rellenoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rellenoFlodToolStripMenuItem});
            this.rellenoToolStripMenuItem.Name = "rellenoToolStripMenuItem";
            this.rellenoToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.rellenoToolStripMenuItem.Text = "Relleno";
            // 
            // rellenoFlodToolStripMenuItem
            // 
            this.rellenoFlodToolStripMenuItem.Name = "rellenoFlodToolStripMenuItem";
            this.rellenoFlodToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.rellenoFlodToolStripMenuItem.Text = "Relleno";
            this.rellenoFlodToolStripMenuItem.Click += new System.EventHandler(this.rellenoFlodToolStripMenuItem_Click);
            // 
            // recortesToolStripMenuItem
            // 
            this.recortesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cohenSoutherlandToolStripMenuItem});
            this.recortesToolStripMenuItem.Name = "recortesToolStripMenuItem";
            this.recortesToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.recortesToolStripMenuItem.Text = "Recortes";
            // 
            // cohenSoutherlandToolStripMenuItem
            // 
            this.cohenSoutherlandToolStripMenuItem.Name = "cohenSoutherlandToolStripMenuItem";
            this.cohenSoutherlandToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cohenSoutherlandToolStripMenuItem.Text = "Cohen-Southerland";
            this.cohenSoutherlandToolStripMenuItem.Click += new System.EventHandler(this.cohenSoutherlandToolStripMenuItem_Click);
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
        private System.Windows.Forms.ToolStripMenuItem celdasDDAToolStripMenuItem;
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
    }
}