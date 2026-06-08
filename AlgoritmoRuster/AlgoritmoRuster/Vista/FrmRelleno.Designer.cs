namespace AlgoritmoRuster.Vista
{
    partial class FrmRelleno
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
            this.panelDibujo = new System.Windows.Forms.Panel();
            this.btnCirculo = new System.Windows.Forms.Button();
            this.btnRectangulo = new System.Windows.Forms.Button();
            this.btnBalde = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.panelColor = new System.Windows.Forms.Panel();
            this.cmbAlgoritmo = new System.Windows.Forms.ComboBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.lblAlgoritmo = new System.Windows.Forms.Label();
            this.btnEstrella = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelDibujo
            // 
            this.panelDibujo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDibujo.Location = new System.Drawing.Point(421, 10);
            this.panelDibujo.Name = "panelDibujo";
            this.panelDibujo.Size = new System.Drawing.Size(705, 573);
            this.panelDibujo.TabIndex = 0;
            this.panelDibujo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDibujo_Paint);
            this.panelDibujo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelDibujo_MouseDown);
            // 
            // btnCirculo
            // 
            this.btnCirculo.Location = new System.Drawing.Point(38, 38);
            this.btnCirculo.Name = "btnCirculo";
            this.btnCirculo.Size = new System.Drawing.Size(97, 23);
            this.btnCirculo.TabIndex = 0;
            this.btnCirculo.Text = "Circulo";
            this.btnCirculo.UseVisualStyleBackColor = true;
            this.btnCirculo.Click += new System.EventHandler(this.btnCirculo_Click);
            // 
            // btnRectangulo
            // 
            this.btnRectangulo.Location = new System.Drawing.Point(38, 83);
            this.btnRectangulo.Name = "btnRectangulo";
            this.btnRectangulo.Size = new System.Drawing.Size(97, 23);
            this.btnRectangulo.TabIndex = 1;
            this.btnRectangulo.Text = "Rectangulo";
            this.btnRectangulo.UseVisualStyleBackColor = true;
            this.btnRectangulo.Click += new System.EventHandler(this.btnRectangulo_Click);
            // 
            // btnBalde
            // 
            this.btnBalde.Location = new System.Drawing.Point(38, 134);
            this.btnBalde.Name = "btnBalde";
            this.btnBalde.Size = new System.Drawing.Size(85, 23);
            this.btnBalde.TabIndex = 2;
            this.btnBalde.Text = "Balde";
            this.btnBalde.UseVisualStyleBackColor = true;
            this.btnBalde.Click += new System.EventHandler(this.btnBalde_Click);
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(38, 200);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(85, 23);
            this.btnColor.TabIndex = 3;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // panelColor
            // 
            this.panelColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelColor.Location = new System.Drawing.Point(150, 192);
            this.panelColor.Name = "panelColor";
            this.panelColor.Size = new System.Drawing.Size(40, 40);
            this.panelColor.TabIndex = 4;
            // 
            // cmbAlgoritmo
            // 
            this.cmbAlgoritmo.FormattingEnabled = true;
            this.cmbAlgoritmo.Location = new System.Drawing.Point(38, 309);
            this.cmbAlgoritmo.Name = "cmbAlgoritmo";
            this.cmbAlgoritmo.Size = new System.Drawing.Size(152, 24);
            this.cmbAlgoritmo.TabIndex = 5;
            this.cmbAlgoritmo.SelectedIndexChanged += new System.EventHandler(this.cmbAlgoritmo_SelectedIndexChanged);
            // 
            // lblAlgoritmo
            // 
            this.lblAlgoritmo.AutoSize = true;
            this.lblAlgoritmo.Location = new System.Drawing.Point(48, 284);
            this.lblAlgoritmo.Name = "lblAlgoritmo";
            this.lblAlgoritmo.Size = new System.Drawing.Size(71, 16);
            this.lblAlgoritmo.TabIndex = 6;
            this.lblAlgoritmo.Text = "Algoritmos";
            // 
            // btnEstrella
            // 
            this.btnEstrella.Location = new System.Drawing.Point(179, 38);
            this.btnEstrella.Name = "btnEstrella";
            this.btnEstrella.Size = new System.Drawing.Size(97, 23);
            this.btnEstrella.TabIndex = 7;
            this.btnEstrella.Text = "Estrella";
            this.btnEstrella.UseVisualStyleBackColor = true;
            this.btnEstrella.Click += new System.EventHandler(this.btnEstrella_Click);
            // 
            // FrmRelleno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 589);
            this.Controls.Add(this.btnEstrella);
            this.Controls.Add(this.lblAlgoritmo);
            this.Controls.Add(this.cmbAlgoritmo);
            this.Controls.Add(this.panelColor);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnBalde);
            this.Controls.Add(this.btnRectangulo);
            this.Controls.Add(this.btnCirculo);
            this.Controls.Add(this.panelDibujo);
            this.Name = "FrmRelleno";
            this.Text = "FrmRelleno";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRelleno_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelDibujo;
        private System.Windows.Forms.Button btnCirculo;
        private System.Windows.Forms.Button btnRectangulo;
        private System.Windows.Forms.Button btnBalde;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Panel panelColor;
        private System.Windows.Forms.ComboBox cmbAlgoritmo;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label lblAlgoritmo;
        private System.Windows.Forms.Button btnEstrella;
    }
}