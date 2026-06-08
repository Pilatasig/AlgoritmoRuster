namespace AlgoritmoRuster.Vista
{
    partial class FrmLineaAntialiasing
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
            this.dvgCoordenadas = new System.Windows.Forms.DataGridView();
            this.panelExplicativo = new System.Windows.Forms.Panel();
            this.lblDecision = new System.Windows.Forms.Label();
            this.lblAlgoritmo = new System.Windows.Forms.Label();
            this.lblComplejidad = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.lblFormula = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.chkProgresivo = new System.Windows.Forms.CheckBox();
            this.btnPaso = new System.Windows.Forms.Button();
            this.btnMostrarTodo = new System.Windows.Forms.Button();
            this.trackBarVelocidad = new System.Windows.Forms.TrackBar();
            this.lblVelocidad = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCoordenadas)).BeginInit();
            this.panelExplicativo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVelocidad)).BeginInit();
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
            this.btnResetear.Location = new System.Drawing.Point(1078, 642);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(85, 27);
            this.btnResetear.TabIndex = 1;
            this.btnResetear.Text = "Resetear";
            this.btnResetear.UseVisualStyleBackColor = true;
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            // 
            // dvgCoordenadas
            // 
            this.dvgCoordenadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgCoordenadas.Location = new System.Drawing.Point(782, 200);
            this.dvgCoordenadas.Name = "dvgCoordenadas";
            this.dvgCoordenadas.RowHeadersWidth = 51;
            this.dvgCoordenadas.RowTemplate.Height = 24;
            this.dvgCoordenadas.Size = new System.Drawing.Size(431, 340);
            this.dvgCoordenadas.TabIndex = 2;
            // 
            // panelExplicativo
            // 
            this.panelExplicativo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExplicativo.Controls.Add(this.lblDecision);
            this.panelExplicativo.Controls.Add(this.lblAlgoritmo);
            this.panelExplicativo.Controls.Add(this.lblComplejidad);
            this.panelExplicativo.Controls.Add(this.lblTipo);
            this.panelExplicativo.Controls.Add(this.lblCriterio);
            this.panelExplicativo.Controls.Add(this.lblFormula);
            this.panelExplicativo.Controls.Add(this.lblTitulo);
            this.panelExplicativo.Location = new System.Drawing.Point(782, 12);
            this.panelExplicativo.Name = "panelExplicativo";
            this.panelExplicativo.Size = new System.Drawing.Size(431, 180);
            this.panelExplicativo.TabIndex = 3;
            // 
            // lblDecision
            // 
            this.lblDecision.AutoSize = true;
            this.lblDecision.Location = new System.Drawing.Point(10, 155);
            this.lblDecision.Name = "lblDecision";
            this.lblDecision.Size = new System.Drawing.Size(233, 16);
            this.lblDecision.TabIndex = 0;
            this.lblDecision.Text = "Genera mas puntos (linea mas suave)";
            // 
            // lblAlgoritmo
            // 
            this.lblAlgoritmo.AutoSize = true;
            this.lblAlgoritmo.Location = new System.Drawing.Point(10, 140);
            this.lblAlgoritmo.Name = "lblAlgoritmo";
            this.lblAlgoritmo.Size = new System.Drawing.Size(247, 16);
            this.lblAlgoritmo.TabIndex = 1;
            this.lblAlgoritmo.Text = "Decisión: t se incrementa uniformemente";
            // 
            // lblComplejidad
            // 
            this.lblComplejidad.AutoSize = true;
            this.lblComplejidad.Location = new System.Drawing.Point(10, 115);
            this.lblComplejidad.Name = "lblComplejidad";
            this.lblComplejidad.Size = new System.Drawing.Size(235, 16);
            this.lblComplejidad.TabIndex = 2;
            this.lblComplejidad.Text = "Complejidad: O(100) ~ 100 puntos fijos";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(10, 90);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(264, 16);
            this.lblTipo.TabIndex = 3;
            this.lblTipo.Text = "Tipo: Interpolacion lineal parametrica (float)";
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(10, 65);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(261, 16);
            this.lblCriterio.TabIndex = 4;
            this.lblCriterio.Text = "Criterio: Muestreo parametrico con t += 0.01";
            // 
            // lblFormula
            // 
            this.lblFormula.AutoSize = true;
            this.lblFormula.Location = new System.Drawing.Point(10, 40);
            this.lblFormula.Name = "lblFormula";
            this.lblFormula.Size = new System.Drawing.Size(207, 16);
            this.lblFormula.TabIndex = 5;
            this.lblFormula.Text = "Formula: x(t)=x0+t*Dx, y(t)=y0+t*Dy";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(193, 23);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Algoritmo Antialiasing";
            // 
            // chkProgresivo
            // 
            this.chkProgresivo.AutoSize = true;
            this.chkProgresivo.Location = new System.Drawing.Point(792, 560);
            this.chkProgresivo.Name = "chkProgresivo";
            this.chkProgresivo.Size = new System.Drawing.Size(132, 20);
            this.chkProgresivo.TabIndex = 10;
            this.chkProgresivo.Text = "Modo progresivo";
            this.chkProgresivo.UseVisualStyleBackColor = true;
            this.chkProgresivo.CheckedChanged += new System.EventHandler(this.chkProgresivo_CheckedChanged);
            // 
            // btnPaso
            // 
            this.btnPaso.Location = new System.Drawing.Point(785, 617);
            this.btnPaso.Name = "btnPaso";
            this.btnPaso.Size = new System.Drawing.Size(85, 27);
            this.btnPaso.TabIndex = 9;
            this.btnPaso.Text = "Paso";
            this.btnPaso.UseVisualStyleBackColor = true;
            this.btnPaso.Click += new System.EventHandler(this.btnPaso_Click);
            // 
            // btnMostrarTodo
            // 
            this.btnMostrarTodo.Location = new System.Drawing.Point(876, 617);
            this.btnMostrarTodo.Name = "btnMostrarTodo";
            this.btnMostrarTodo.Size = new System.Drawing.Size(85, 27);
            this.btnMostrarTodo.TabIndex = 8;
            this.btnMostrarTodo.Text = "Mostrar todo";
            this.btnMostrarTodo.UseVisualStyleBackColor = true;
            this.btnMostrarTodo.Click += new System.EventHandler(this.btnMostrarTodo_Click);
            // 
            // trackBarVelocidad
            // 
            this.trackBarVelocidad.Location = new System.Drawing.Point(960, 558);
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
            this.lblVelocidad.Location = new System.Drawing.Point(1085, 560);
            this.lblVelocidad.Name = "lblVelocidad";
            this.lblVelocidad.Size = new System.Drawing.Size(89, 16);
            this.lblVelocidad.TabIndex = 0;
            this.lblVelocidad.Text = "Velocidad: 50";
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(990, 590);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(85, 27);
            this.btnColor.TabIndex = 8;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.FullOpen = true;
            // 
            // FrmLineaAntialiasing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 681);
            this.Controls.Add(this.lblVelocidad);
            this.Controls.Add(this.trackBarVelocidad);
            this.Controls.Add(this.btnMostrarTodo);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnPaso);
            this.Controls.Add(this.chkProgresivo);
            this.Controls.Add(this.panelExplicativo);
            this.Controls.Add(this.dvgCoordenadas);
            this.Controls.Add(this.btnResetear);
            this.Controls.Add(this.panelDibujo);
            this.Name = "FrmLineaAntialiasing";
            this.Text = "Linea Antialiasing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmLineaAntialiasing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgCoordenadas)).EndInit();
            this.panelExplicativo.ResumeLayout(false);
            this.panelExplicativo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVelocidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Panel panelDibujo;
        private System.Windows.Forms.Button btnResetear;
        private System.Windows.Forms.DataGridView dvgCoordenadas;
        private System.Windows.Forms.Panel panelExplicativo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFormula;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblComplejidad;
        private System.Windows.Forms.Label lblAlgoritmo;
        private System.Windows.Forms.Label lblDecision;
        private System.Windows.Forms.CheckBox chkProgresivo;
        private System.Windows.Forms.Button btnPaso;
        private System.Windows.Forms.Button btnMostrarTodo;
        private System.Windows.Forms.TrackBar trackBarVelocidad;
        private System.Windows.Forms.Label lblVelocidad;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}
