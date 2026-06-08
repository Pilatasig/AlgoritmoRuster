namespace AlgoritmoRuster.Vista
{
    partial class FrmRelleno
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
            this.btnCirculo = new System.Windows.Forms.Button();
            this.btnRectangulo = new System.Windows.Forms.Button();
            this.btnEstrella = new System.Windows.Forms.Button();
            this.btnBalde = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.panelColor = new System.Windows.Forms.Panel();
            this.cmbAlgoritmo = new System.Windows.Forms.ComboBox();
            this.lblAlgoritmo = new System.Windows.Forms.Label();
            this.btnResetear = new System.Windows.Forms.Button();
            this.panelExplicativo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFormula = new System.Windows.Forms.Label();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblComplejidad = new System.Windows.Forms.Label();
            this.lblDecision = new System.Windows.Forms.Label();
            this.trackBarVelocidad = new System.Windows.Forms.TrackBar();
            this.lblVelocidad = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.lblTool = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVelocidad)).BeginInit();
            this.panelExplicativo.SuspendLayout();
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
            // btnCirculo
            //
            this.btnCirculo.Location = new System.Drawing.Point(790, 35);
            this.btnCirculo.Name = "btnCirculo";
            this.btnCirculo.Size = new System.Drawing.Size(85, 27);
            this.btnCirculo.TabIndex = 0;
            this.btnCirculo.Text = "Circulo";
            this.btnCirculo.UseVisualStyleBackColor = true;
            this.btnCirculo.Click += new System.EventHandler(this.btnCirculo_Click);
            //
            // btnRectangulo
            //
            this.btnRectangulo.Location = new System.Drawing.Point(881, 35);
            this.btnRectangulo.Name = "btnRectangulo";
            this.btnRectangulo.Size = new System.Drawing.Size(97, 27);
            this.btnRectangulo.TabIndex = 1;
            this.btnRectangulo.Text = "Rectangulo";
            this.btnRectangulo.UseVisualStyleBackColor = true;
            this.btnRectangulo.Click += new System.EventHandler(this.btnRectangulo_Click);
            //
            // btnEstrella
            //
            this.btnEstrella.Location = new System.Drawing.Point(984, 35);
            this.btnEstrella.Name = "btnEstrella";
            this.btnEstrella.Size = new System.Drawing.Size(85, 27);
            this.btnEstrella.TabIndex = 7;
            this.btnEstrella.Text = "Estrella";
            this.btnEstrella.UseVisualStyleBackColor = true;
            this.btnEstrella.Click += new System.EventHandler(this.btnEstrella_Click);
            //
            // btnBalde
            //
            this.btnBalde.Location = new System.Drawing.Point(790, 68);
            this.btnBalde.Name = "btnBalde";
            this.btnBalde.Size = new System.Drawing.Size(85, 27);
            this.btnBalde.TabIndex = 2;
            this.btnBalde.Text = "Balde";
            this.btnBalde.UseVisualStyleBackColor = true;
            this.btnBalde.Click += new System.EventHandler(this.btnBalde_Click);
            //
            // btnColor
            //
            this.btnColor.Location = new System.Drawing.Point(790, 110);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(85, 27);
            this.btnColor.TabIndex = 3;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            //
            // panelColor
            //
            this.panelColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColor.Location = new System.Drawing.Point(881, 104);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(40, 40);
            this.panelColor.TabIndex = 4;
            //
            // cmbAlgoritmo
            //
            this.cmbAlgoritmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlgoritmo.FormattingEnabled = true;
            this.cmbAlgoritmo.Location = new System.Drawing.Point(790, 175);
            this.cmbAlgoritmo.Name = "cmbAlgoritmo";
            this.cmbAlgoritmo.Size = new System.Drawing.Size(188, 24);
            this.cmbAlgoritmo.TabIndex = 5;
            this.cmbAlgoritmo.SelectedIndexChanged += new System.EventHandler(this.cmbAlgoritmo_SelectedIndexChanged);
            //
            // lblAlgoritmo
            //
            this.lblAlgoritmo.AutoSize = true;
            this.lblAlgoritmo.Location = new System.Drawing.Point(790, 152);
            this.lblAlgoritmo.Name = "lblAlgoritmo";
            this.lblAlgoritmo.Size = new System.Drawing.Size(79, 20);
            this.lblAlgoritmo.Text = "Algoritmo:";
            //
            // btnResetear
            //
            this.btnResetear.Location = new System.Drawing.Point(1085, 615);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(85, 27);
            this.btnResetear.TabIndex = 8;
            this.btnResetear.Text = "Resetear";
            this.btnResetear.UseVisualStyleBackColor = true;
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            //
            // panelExplicativo
            //
            this.panelExplicativo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExplicativo.Controls.Add(this.lblDecision);
            this.panelExplicativo.Controls.Add(this.lblComplejidad);
            this.panelExplicativo.Controls.Add(this.lblTipo);
            this.panelExplicativo.Controls.Add(this.lblCriterio);
            this.panelExplicativo.Controls.Add(this.lblFormula);
            this.panelExplicativo.Controls.Add(this.lblTitulo);
            this.panelExplicativo.Location = new System.Drawing.Point(782, 210);
            this.panelExplicativo.Name = "panelExplicativo";
            this.panelExplicativo.Size = new System.Drawing.Size(388, 180);
            this.panelExplicativo.TabIndex = 9;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(181, 23);
            this.lblTitulo.Text = "Algoritmo de Relleno";
            //
            // lblFormula
            //
            this.lblFormula.AutoSize = true;
            this.lblFormula.Location = new System.Drawing.Point(10, 40);
            this.lblFormula.Name = "lblFormula";
            this.lblFormula.Size = new System.Drawing.Size(283, 20);
            this.lblFormula.TabIndex = 0;
            this.lblFormula.Text = "Formula: Comparacion de color por pixel";
            //
            // lblCriterio
            //
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(10, 65);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(283, 20);
            this.lblCriterio.Text = "Criterio: Rellenar hasta encontrar borde";
            //
            // lblTipo
            //
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(10, 90);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(316, 20);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Tipo: Algoritmo de relleno por inundacion";
            //
            // lblComplejidad
            //
            this.lblComplejidad.AutoSize = true;
            this.lblComplejidad.Location = new System.Drawing.Point(10, 115);
            this.lblComplejidad.Name = "lblComplejidad";
            this.lblComplejidad.Size = new System.Drawing.Size(375, 20);
            this.lblComplejidad.TabIndex = 0;
            this.lblComplejidad.Text = "Complejidad: O(n) donde n = pixeles a rellenar";
            //
            // lblDecision
            //
            this.lblDecision.AutoSize = true;
            this.lblDecision.Location = new System.Drawing.Point(10, 140);
            this.lblDecision.Name = "lblDecision";
            this.lblDecision.Size = new System.Drawing.Size(335, 20);
            this.lblDecision.TabIndex = 0;
            this.lblDecision.Text = "Decision: Procesa pixeles vecinos recursivamente";
            //
            // trackBarVelocidad
            //
            this.trackBarVelocidad.Location = new System.Drawing.Point(790, 400);
            this.trackBarVelocidad.Maximum = 100;
            this.trackBarVelocidad.Minimum = 1;
            this.trackBarVelocidad.Name = "trackBarVelocidad";
            this.trackBarVelocidad.Size = new System.Drawing.Size(120, 56);
            this.trackBarVelocidad.TabIndex = 7;
            this.trackBarVelocidad.Value = 50;
            this.trackBarVelocidad.Scroll += new System.EventHandler(this.trackBarVelocidad_Scroll);
            //
            // lblVelocidad
            //
            this.lblVelocidad.AutoSize = true;
            this.lblVelocidad.Location = new System.Drawing.Point(915, 402);
            this.lblVelocidad.Name = "lblVelocidad";
            this.lblVelocidad.Size = new System.Drawing.Size(83, 20);
            this.lblVelocidad.Text = "Velocidad: 50";
            //
            // lblTool
            //
            this.lblTool.AutoSize = true;
            this.lblTool.Location = new System.Drawing.Point(790, 12);
            this.lblTool.Name = "lblTool";
            this.lblTool.Size = new System.Drawing.Size(66, 20);
            this.lblTool.Text = "Herramientas:";
            //
            // FrmRelleno
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 654);
            this.Controls.Add(this.lblVelocidad);
            this.Controls.Add(this.trackBarVelocidad);
            this.Controls.Add(this.panelExplicativo);
            this.Controls.Add(this.btnResetear);
            this.Controls.Add(this.lblTool);
            this.Controls.Add(this.lblAlgoritmo);
            this.Controls.Add(this.cmbAlgoritmo);
            this.Controls.Add(this.panelColor);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnBalde);
            this.Controls.Add(this.btnEstrella);
            this.Controls.Add(this.btnRectangulo);
            this.Controls.Add(this.btnCirculo);
            this.Controls.Add(this.panelDibujo);
            this.Name = "FrmRelleno";
            this.Text = "Relleno";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRelleno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVelocidad)).EndInit();
            this.panelExplicativo.ResumeLayout(false);
            this.panelExplicativo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel panelDibujo;
        private System.Windows.Forms.Button btnCirculo;
        private System.Windows.Forms.Button btnRectangulo;
        private System.Windows.Forms.Button btnEstrella;
        private System.Windows.Forms.Button btnBalde;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Panel panelColor;
        private System.Windows.Forms.ComboBox cmbAlgoritmo;
        private System.Windows.Forms.Label lblAlgoritmo;
        private System.Windows.Forms.Button btnResetear;
        private System.Windows.Forms.Panel panelExplicativo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFormula;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblComplejidad;
        private System.Windows.Forms.Label lblDecision;
        private System.Windows.Forms.TrackBar trackBarVelocidad;
        private System.Windows.Forms.Label lblVelocidad;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label lblTool;
    }
}
