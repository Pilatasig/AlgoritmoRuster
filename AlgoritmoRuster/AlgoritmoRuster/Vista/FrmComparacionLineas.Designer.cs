namespace AlgoritmoRuster.Vista
{
    partial class FrmComparacionLineas
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
            this.lblLeyendaTitulo = new System.Windows.Forms.Label();
            this.lblAlgoritmo = new System.Windows.Forms.Label();
            this.cboAlgoritmo = new System.Windows.Forms.ComboBox();
            this.lblInfoPuntos = new System.Windows.Forms.Label();
            this.lblAlgoritmoInfo = new System.Windows.Forms.Label();
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
            this.panelLeyenda.Controls.Add(this.lblAlgoritmoInfo);
            this.panelLeyenda.Controls.Add(this.lblInfoPuntos);
            this.panelLeyenda.Controls.Add(this.cboAlgoritmo);
            this.panelLeyenda.Controls.Add(this.lblAlgoritmo);
            this.panelLeyenda.Controls.Add(this.lblLeyendaTitulo);
            this.panelLeyenda.Location = new System.Drawing.Point(782, 12);
            this.panelLeyenda.Name = "panelLeyenda";
            this.panelLeyenda.Size = new System.Drawing.Size(388, 200);
            this.panelLeyenda.TabIndex = 3;
            //
            // lblLeyendaTitulo
            //
            this.lblLeyendaTitulo.AutoSize = true;
            this.lblLeyendaTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLeyendaTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblLeyendaTitulo.Name = "lblLeyendaTitulo";
            this.lblLeyendaTitulo.Size = new System.Drawing.Size(202, 23);
            this.lblLeyendaTitulo.Text = "Comparacion de Algoritmos";
            //
            // lblAlgoritmo
            //
            this.lblAlgoritmo.AutoSize = true;
            this.lblAlgoritmo.Location = new System.Drawing.Point(10, 40);
            this.lblAlgoritmo.Name = "lblAlgoritmo";
            this.lblAlgoritmo.Size = new System.Drawing.Size(79, 20);
            this.lblAlgoritmo.Text = "Algoritmo:";
            //
            // cboAlgoritmo
            //
            this.cboAlgoritmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlgoritmo.Items.AddRange(new object[] { "DDA", "Bresenham", "Antialiasing" });
            this.cboAlgoritmo.Location = new System.Drawing.Point(95, 37);
            this.cboAlgoritmo.Name = "cboAlgoritmo";
            this.cboAlgoritmo.Size = new System.Drawing.Size(150, 24);
            this.cboAlgoritmo.TabIndex = 4;
            this.cboAlgoritmo.SelectedIndexChanged += new System.EventHandler(this.cboAlgoritmo_SelectedIndexChanged);
            //
            // lblInfoPuntos
            //
            this.lblInfoPuntos.AutoSize = true;
            this.lblInfoPuntos.Location = new System.Drawing.Point(10, 75);
            this.lblInfoPuntos.Name = "lblInfoPuntos";
            this.lblInfoPuntos.Size = new System.Drawing.Size(361, 20);
            this.lblInfoPuntos.Text = "Haga clic en dos puntos del plano para trazar";
            //
            // lblAlgoritmoInfo
            //
            this.lblAlgoritmoInfo.AutoSize = true;
            this.lblAlgoritmoInfo.Location = new System.Drawing.Point(10, 105);
            this.lblAlgoritmoInfo.Name = "lblAlgoritmoInfo";
            this.lblAlgoritmoInfo.Size = new System.Drawing.Size(0, 20);
            this.lblAlgoritmoInfo.Text = "";
            //
            // FrmComparacionLineas
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 654);
            this.Controls.Add(this.panelLeyenda);
            this.Controls.Add(this.dvgComparacion);
            this.Controls.Add(this.btnResetear);
            this.Controls.Add(this.panelDibujo);
            this.Name = "FrmComparacionLineas";
            this.Text = "Comparacion de Algoritmos de Lineas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmComparacionLineas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgComparacion)).EndInit();
            this.panelLeyenda.ResumeLayout(false);
            this.panelLeyenda.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelDibujo;
        private System.Windows.Forms.Button btnResetear;
        private System.Windows.Forms.DataGridView dvgComparacion;
        private System.Windows.Forms.Panel panelLeyenda;
        private System.Windows.Forms.Label lblLeyendaTitulo;
        private System.Windows.Forms.Label lblAlgoritmo;
        private System.Windows.Forms.ComboBox cboAlgoritmo;
        private System.Windows.Forms.Label lblInfoPuntos;
        private System.Windows.Forms.Label lblAlgoritmoInfo;
    }
}
