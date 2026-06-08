namespace AlgoritmoRuster.Vista
{
    partial class FrmComparacionRelleno
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
            this.btnCirculo = new System.Windows.Forms.Button();
            this.lblAlgoritmoInfo = new System.Windows.Forms.Label();
            this.btnRectangulo = new System.Windows.Forms.Button();
            this.btnRellenar = new System.Windows.Forms.Button();
            this.lblInfoPuntos = new System.Windows.Forms.Label();
            this.btnEstrella = new System.Windows.Forms.Button();
            this.cboAlgoritmo = new System.Windows.Forms.ComboBox();
            this.lblAlgoritmo = new System.Windows.Forms.Label();
            this.lblLeyendaTitulo = new System.Windows.Forms.Label();
            this.lblTool = new System.Windows.Forms.Label();
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
            this.dvgComparacion.Location = new System.Drawing.Point(782, 270);
            this.dvgComparacion.Name = "dvgComparacion";
            this.dvgComparacion.RowHeadersWidth = 51;
            this.dvgComparacion.RowTemplate.Height = 24;
            this.dvgComparacion.Size = new System.Drawing.Size(388, 330);
            this.dvgComparacion.TabIndex = 2;
            // 
            // panelLeyenda
            // 
            this.panelLeyenda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeyenda.Controls.Add(this.btnCirculo);
            this.panelLeyenda.Controls.Add(this.lblAlgoritmoInfo);
            this.panelLeyenda.Controls.Add(this.btnRectangulo);
            this.panelLeyenda.Controls.Add(this.btnRellenar);
            this.panelLeyenda.Controls.Add(this.lblInfoPuntos);
            this.panelLeyenda.Controls.Add(this.btnEstrella);
            this.panelLeyenda.Controls.Add(this.cboAlgoritmo);
            this.panelLeyenda.Controls.Add(this.lblAlgoritmo);
            this.panelLeyenda.Controls.Add(this.lblLeyendaTitulo);
            this.panelLeyenda.Location = new System.Drawing.Point(782, 12);
            this.panelLeyenda.Name = "panelLeyenda";
            this.panelLeyenda.Size = new System.Drawing.Size(388, 250);
            this.panelLeyenda.TabIndex = 3;
            // 
            // btnCirculo
            // 
            this.btnCirculo.Location = new System.Drawing.Point(58, 56);
            this.btnCirculo.Name = "btnCirculo";
            this.btnCirculo.Size = new System.Drawing.Size(85, 27);
            this.btnCirculo.TabIndex = 4;
            this.btnCirculo.Text = "Circulo";
            this.btnCirculo.UseVisualStyleBackColor = true;
            this.btnCirculo.Click += new System.EventHandler(this.btnCirculo_Click);
            // 
            // lblAlgoritmoInfo
            // 
            this.lblAlgoritmoInfo.AutoSize = true;
            this.lblAlgoritmoInfo.Location = new System.Drawing.Point(12, 202);
            this.lblAlgoritmoInfo.Name = "lblAlgoritmoInfo";
            this.lblAlgoritmoInfo.Size = new System.Drawing.Size(0, 16);
            this.lblAlgoritmoInfo.TabIndex = 0;
            // 
            // btnRectangulo
            // 
            this.btnRectangulo.Location = new System.Drawing.Point(149, 56);
            this.btnRectangulo.Name = "btnRectangulo";
            this.btnRectangulo.Size = new System.Drawing.Size(97, 27);
            this.btnRectangulo.TabIndex = 5;
            this.btnRectangulo.Text = "Rectangulo";
            this.btnRectangulo.UseVisualStyleBackColor = true;
            this.btnRectangulo.Click += new System.EventHandler(this.btnRectangulo_Click);
            // 
            // btnRellenar
            // 
            this.btnRellenar.Location = new System.Drawing.Point(58, 89);
            this.btnRellenar.Name = "btnRellenar";
            this.btnRellenar.Size = new System.Drawing.Size(279, 27);
            this.btnRellenar.TabIndex = 7;
            this.btnRellenar.Text = "Rellenar (sin animacion)";
            this.btnRellenar.UseVisualStyleBackColor = true;
            this.btnRellenar.Click += new System.EventHandler(this.btnRellenar_Click);
            // 
            // lblInfoPuntos
            // 
            this.lblInfoPuntos.AutoSize = true;
            this.lblInfoPuntos.Location = new System.Drawing.Point(11, 171);
            this.lblInfoPuntos.Name = "lblInfoPuntos";
            this.lblInfoPuntos.Size = new System.Drawing.Size(336, 16);
            this.lblInfoPuntos.TabIndex = 1;
            this.lblInfoPuntos.Text = "Seleccione herramienta, dibuje figura y haga clic dentro";
            // 
            // btnEstrella
            // 
            this.btnEstrella.Location = new System.Drawing.Point(252, 56);
            this.btnEstrella.Name = "btnEstrella";
            this.btnEstrella.Size = new System.Drawing.Size(85, 27);
            this.btnEstrella.TabIndex = 6;
            this.btnEstrella.Text = "Estrella";
            this.btnEstrella.UseVisualStyleBackColor = true;
            this.btnEstrella.Click += new System.EventHandler(this.btnEstrella_Click);
            // 
            // cboAlgoritmo
            // 
            this.cboAlgoritmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlgoritmo.Items.AddRange(new object[] {
            "Inundacion",
            "Cola",
            "ScanLine"});
            this.cboAlgoritmo.Location = new System.Drawing.Point(96, 133);
            this.cboAlgoritmo.Name = "cboAlgoritmo";
            this.cboAlgoritmo.Size = new System.Drawing.Size(150, 24);
            this.cboAlgoritmo.TabIndex = 4;
            this.cboAlgoritmo.SelectedIndexChanged += new System.EventHandler(this.cboAlgoritmo_SelectedIndexChanged);
            // 
            // lblAlgoritmo
            // 
            this.lblAlgoritmo.AutoSize = true;
            this.lblAlgoritmo.Location = new System.Drawing.Point(11, 136);
            this.lblAlgoritmo.Name = "lblAlgoritmo";
            this.lblAlgoritmo.Size = new System.Drawing.Size(67, 16);
            this.lblAlgoritmo.TabIndex = 5;
            this.lblAlgoritmo.Text = "Algoritmo:";
            // 
            // lblLeyendaTitulo
            // 
            this.lblLeyendaTitulo.AutoSize = true;
            this.lblLeyendaTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLeyendaTitulo.Location = new System.Drawing.Point(11, 20);
            this.lblLeyendaTitulo.Name = "lblLeyendaTitulo";
            this.lblLeyendaTitulo.Size = new System.Drawing.Size(205, 23);
            this.lblLeyendaTitulo.TabIndex = 6;
            this.lblLeyendaTitulo.Text = "Comparacion de Relleno";
            // 
            // lblTool
            // 
            this.lblTool.AutoSize = true;
            this.lblTool.Location = new System.Drawing.Point(790, 12);
            this.lblTool.Name = "lblTool";
            this.lblTool.Size = new System.Drawing.Size(91, 16);
            this.lblTool.TabIndex = 8;
            this.lblTool.Text = "Herramientas:";
            // 
            // FrmComparacionRelleno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 654);
            this.Controls.Add(this.lblTool);
            this.Controls.Add(this.panelLeyenda);
            this.Controls.Add(this.dvgComparacion);
            this.Controls.Add(this.btnResetear);
            this.Controls.Add(this.panelDibujo);
            this.Name = "FrmComparacionRelleno";
            this.Text = "Comparacion de Algoritmos de Relleno";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmComparacionRelleno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgComparacion)).EndInit();
            this.panelLeyenda.ResumeLayout(false);
            this.panelLeyenda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button btnCirculo;
        private System.Windows.Forms.Button btnRectangulo;
        private System.Windows.Forms.Button btnEstrella;
        private System.Windows.Forms.Button btnRellenar;
        private System.Windows.Forms.Label lblTool;
    }
}
