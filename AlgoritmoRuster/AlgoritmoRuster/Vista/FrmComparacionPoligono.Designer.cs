namespace AlgoritmoRuster.Vista
{
    partial class FrmComparacionPoligono
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelDibujo = new System.Windows.Forms.Panel();
            this.btnResetear = new System.Windows.Forms.Button();
            this.dvgComparacion = new System.Windows.Forms.DataGridView();
            this.panelLeyenda = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblVista = new System.Windows.Forms.Label();
            this.cboVista = new System.Windows.Forms.ComboBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnComparar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgComparacion)).BeginInit();
            this.panelLeyenda.SuspendLayout();
            this.SuspendLayout();
            //
            // panelDibujo
            //
            this.panelDibujo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDibujo.Location = new System.Drawing.Point(12, 12);
            this.panelDibujo.Name = "panelDibujo";
            this.panelDibujo.Size = new System.Drawing.Size(760, 630);
            this.panelDibujo.TabIndex = 0;
            this.panelDibujo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDibujo_Paint);
            this.panelDibujo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelDibujo_MouseDown);
            //
            // btnResetear
            //
            this.btnResetear.Location = new System.Drawing.Point(1085, 615);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(85, 27);
            this.btnResetear.TabIndex = 1;
            this.btnResetear.Text = "Resetear";
            this.btnResetear.UseVisualStyleBackColor = true;
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            //
            // dvgComparacion
            //
            this.dvgComparacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgComparacion.Location = new System.Drawing.Point(782, 220);
            this.dvgComparacion.Name = "dvgComparacion";
            this.dvgComparacion.RowHeadersWidth = 51;
            this.dvgComparacion.RowTemplate.Height = 24;
            this.dvgComparacion.Size = new System.Drawing.Size(388, 380);
            this.dvgComparacion.TabIndex = 2;
            //
            // panelLeyenda
            //
            this.panelLeyenda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeyenda.Controls.Add(this.btnComparar);
            this.panelLeyenda.Controls.Add(this.lblInfo);
            this.panelLeyenda.Controls.Add(this.cboVista);
            this.panelLeyenda.Controls.Add(this.lblVista);
            this.panelLeyenda.Controls.Add(this.lblTitulo);
            this.panelLeyenda.Location = new System.Drawing.Point(782, 12);
            this.panelLeyenda.Name = "panelLeyenda";
            this.panelLeyenda.Size = new System.Drawing.Size(388, 200);
            this.panelLeyenda.TabIndex = 3;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(258, 23);
            this.lblTitulo.Text = "Comparacion Recorte Poligonal";
            //
            // lblVista
            //
            this.lblVista.AutoSize = true;
            this.lblVista.Location = new System.Drawing.Point(10, 40);
            this.lblVista.Name = "lblVista";
            this.lblVista.Size = new System.Drawing.Size(45, 20);
            this.lblVista.Text = "Vista:";
            //
            // cboVista
            //
            this.cboVista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVista.Items.AddRange(new object[] { "Todos", "Sutherland-Hodgman", "Weiler-Atherton", "Greiner-Hormann" });
            this.cboVista.Location = new System.Drawing.Point(61, 37);
            this.cboVista.Name = "cboVista";
            this.cboVista.Size = new System.Drawing.Size(180, 24);
            this.cboVista.TabIndex = 4;
            this.cboVista.SelectedIndexChanged += new System.EventHandler(this.cboVista_SelectedIndexChanged);
            //
            // lblInfo
            //
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(10, 75);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(336, 20);
            this.lblInfo.Text = "Clic para definir el poligono (3+ vertices)";
            //
            // btnComparar
            //
            this.btnComparar.Location = new System.Drawing.Point(10, 105);
            this.btnComparar.Name = "btnComparar";
            this.btnComparar.Size = new System.Drawing.Size(100, 30);
            this.btnComparar.TabIndex = 5;
            this.btnComparar.Text = "Comparar";
            this.btnComparar.UseVisualStyleBackColor = true;
            this.btnComparar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnComparar.Click += new System.EventHandler(this.btnComparar_Click);
            //
            // FrmComparacionPoligono
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 654);
            this.Controls.Add(this.panelLeyenda);
            this.Controls.Add(this.dvgComparacion);
            this.Controls.Add(this.btnResetear);
            this.Controls.Add(this.panelDibujo);
            this.Name = "FrmComparacionPoligono";
            this.Text = "Comparacion de Algoritmos de Recorte Poligonal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmComparacionPoligono_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgComparacion)).EndInit();
            this.panelLeyenda.ResumeLayout(false);
            this.panelLeyenda.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelDibujo;
        private System.Windows.Forms.Button btnResetear;
        private System.Windows.Forms.DataGridView dvgComparacion;
        private System.Windows.Forms.Panel panelLeyenda;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblVista;
        private System.Windows.Forms.ComboBox cboVista;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnComparar;
    }
}
