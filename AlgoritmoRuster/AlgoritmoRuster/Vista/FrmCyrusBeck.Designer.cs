namespace AlgoritmoRuster.Vista
{
    partial class FrmCyrusBeck
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
            this.lblAlgoritmoLinea = new System.Windows.Forms.Label();
            this.cboAlgoritmoLinea = new System.Windows.Forms.ComboBox();
            this.lblClipInfo = new System.Windows.Forms.Label();
            this.lblModo = new System.Windows.Forms.Label();
            this.btnPoligono = new System.Windows.Forms.Button();
            this.btnFinalizarPoligono = new System.Windows.Forms.Button();
            this.btnRectangulo = new System.Windows.Forms.Button();
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
            this.btnResetear.Location = new System.Drawing.Point(1079, 636);
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
            this.dvgCoordenadas.Location = new System.Drawing.Point(782, 312);
            this.dvgCoordenadas.Name = "dvgCoordenadas";
            this.dvgCoordenadas.RowHeadersWidth = 51;
            this.dvgCoordenadas.RowTemplate.Height = 24;
            this.dvgCoordenadas.Size = new System.Drawing.Size(435, 220);
            this.dvgCoordenadas.TabIndex = 2;
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
            this.panelExplicativo.Location = new System.Drawing.Point(782, 12);
            this.panelExplicativo.Name = "panelExplicativo";
            this.panelExplicativo.Size = new System.Drawing.Size(435, 180);
            this.panelExplicativo.TabIndex = 3;
            // 
            // lblDecision
            // 
            this.lblDecision.AutoSize = true;
            this.lblDecision.Location = new System.Drawing.Point(10, 140);
            this.lblDecision.Name = "lblDecision";
            this.lblDecision.Size = new System.Drawing.Size(323, 16);
            this.lblDecision.TabIndex = 0;
            this.lblDecision.Text = "Decision: t_enter > t_leave ? RECHAZAR : ACEPTAR";
            // 
            // lblComplejidad
            // 
            this.lblComplejidad.AutoSize = true;
            this.lblComplejidad.Location = new System.Drawing.Point(10, 115);
            this.lblComplejidad.Name = "lblComplejidad";
            this.lblComplejidad.Size = new System.Drawing.Size(184, 16);
            this.lblComplejidad.TabIndex = 1;
            this.lblComplejidad.Text = "Complejidad: O(n)  n = bordes";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(10, 90);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(297, 16);
            this.lblTipo.TabIndex = 2;
            this.lblTipo.Text = "Tipo: Recorte de lineas contra poligono convexo";
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(10, 65);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(284, 16);
            this.lblCriterio.TabIndex = 3;
            this.lblCriterio.Text = "Criterio: clasificar t como enter/leave por borde";
            // 
            // lblFormula
            // 
            this.lblFormula.AutoSize = true;
            this.lblFormula.Location = new System.Drawing.Point(10, 40);
            this.lblFormula.Name = "lblFormula";
            this.lblFormula.Size = new System.Drawing.Size(232, 16);
            this.lblFormula.TabIndex = 4;
            this.lblFormula.Text = "t = (Borde - P0) / (P1 - P0)  parametrico";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(177, 23);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Cyrus-Beck (Recorte)";
            // 
            // chkProgresivo
            // 
            this.chkProgresivo.AutoSize = true;
            this.chkProgresivo.Location = new System.Drawing.Point(792, 560);
            this.chkProgresivo.Name = "chkProgresivo";
            this.chkProgresivo.Size = new System.Drawing.Size(132, 20);
            this.chkProgresivo.TabIndex = 5;
            this.chkProgresivo.Text = "Modo progresivo";
            this.chkProgresivo.UseVisualStyleBackColor = true;
            this.chkProgresivo.CheckedChanged += new System.EventHandler(this.chkProgresivo_CheckedChanged);
            // 
            // btnPaso
            // 
            this.btnPaso.Location = new System.Drawing.Point(786, 611);
            this.btnPaso.Name = "btnPaso";
            this.btnPaso.Size = new System.Drawing.Size(85, 27);
            this.btnPaso.TabIndex = 0;
            this.btnPaso.Text = "Paso";
            this.btnPaso.UseVisualStyleBackColor = true;
            this.btnPaso.Click += new System.EventHandler(this.btnPaso_Click);
            // 
            // btnMostrarTodo
            // 
            this.btnMostrarTodo.Location = new System.Drawing.Point(877, 611);
            this.btnMostrarTodo.Name = "btnMostrarTodo";
            this.btnMostrarTodo.Size = new System.Drawing.Size(85, 27);
            this.btnMostrarTodo.TabIndex = 4;
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
            this.trackBarVelocidad.TabIndex = 1;
            this.trackBarVelocidad.Value = 50;
            this.trackBarVelocidad.Scroll += new System.EventHandler(this.trackBarVelocidad_Scroll);
            // 
            // lblVelocidad
            // 
            this.lblVelocidad.AutoSize = true;
            this.lblVelocidad.Location = new System.Drawing.Point(1085, 560);
            this.lblVelocidad.Name = "lblVelocidad";
            this.lblVelocidad.Size = new System.Drawing.Size(89, 16);
            this.lblVelocidad.TabIndex = 3;
            this.lblVelocidad.Text = "Velocidad: 50";
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(990, 590);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(85, 27);
            this.btnColor.TabIndex = 0;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.FullOpen = true;
            // 
            // lblAlgoritmoLinea
            // 
            this.lblAlgoritmoLinea.AutoSize = true;
            this.lblAlgoritmoLinea.Location = new System.Drawing.Point(782, 200);
            this.lblAlgoritmoLinea.Name = "lblAlgoritmoLinea";
            this.lblAlgoritmoLinea.Size = new System.Drawing.Size(112, 16);
            this.lblAlgoritmoLinea.TabIndex = 2;
            this.lblAlgoritmoLinea.Text = "Trazado de linea:";
            // 
            // cboAlgoritmoLinea
            // 
            this.cboAlgoritmoLinea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAlgoritmoLinea.Items.AddRange(new object[] {
            "DDA",
            "Bresenham",
            "Antialiasing"});
            this.cboAlgoritmoLinea.Location = new System.Drawing.Point(905, 197);
            this.cboAlgoritmoLinea.Name = "cboAlgoritmoLinea";
            this.cboAlgoritmoLinea.Size = new System.Drawing.Size(140, 24);
            this.cboAlgoritmoLinea.TabIndex = 0;
            // 
            // lblClipInfo
            // 
            this.lblClipInfo.AutoSize = true;
            this.lblClipInfo.Location = new System.Drawing.Point(782, 230);
            this.lblClipInfo.Name = "lblClipInfo";
            this.lblClipInfo.Size = new System.Drawing.Size(218, 16);
            this.lblClipInfo.TabIndex = 1;
            this.lblClipInfo.Text = "Haga clic en dos puntos para trazar";
            // 
            // lblModo
            // 
            this.lblModo.AutoSize = true;
            this.lblModo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblModo.Location = new System.Drawing.Point(782, 260);
            this.lblModo.Name = "lblModo";
            this.lblModo.Size = new System.Drawing.Size(137, 20);
            this.lblModo.TabIndex = 0;
            this.lblModo.Text = "Modo: Rectangulo";
            // 
            // btnPoligono
            // 
            this.btnPoligono.Location = new System.Drawing.Point(782, 280);
            this.btnPoligono.Name = "btnPoligono";
            this.btnPoligono.Size = new System.Drawing.Size(112, 27);
            this.btnPoligono.TabIndex = 0;
            this.btnPoligono.Text = "Poligono";
            this.btnPoligono.UseVisualStyleBackColor = true;
            this.btnPoligono.Click += new System.EventHandler(this.btnPoligono_Click);
            // 
            // btnFinalizarPoligono
            // 
            this.btnFinalizarPoligono.Location = new System.Drawing.Point(782, 280);
            this.btnFinalizarPoligono.Name = "btnFinalizarPoligono";
            this.btnFinalizarPoligono.Size = new System.Drawing.Size(85, 27);
            this.btnFinalizarPoligono.TabIndex = 0;
            this.btnFinalizarPoligono.Text = "Finalizar";
            this.btnFinalizarPoligono.UseVisualStyleBackColor = true;
            this.btnFinalizarPoligono.Visible = false;
            this.btnFinalizarPoligono.Click += new System.EventHandler(this.btnFinalizarPoligono_Click);
            // 
            // btnRectangulo
            // 
            this.btnRectangulo.Location = new System.Drawing.Point(782, 280);
            this.btnRectangulo.Name = "btnRectangulo";
            this.btnRectangulo.Size = new System.Drawing.Size(85, 27);
            this.btnRectangulo.TabIndex = 0;
            this.btnRectangulo.Text = "Rectangulo";
            this.btnRectangulo.UseVisualStyleBackColor = true;
            this.btnRectangulo.Visible = false;
            this.btnRectangulo.Click += new System.EventHandler(this.btnRectangulo_Click);
            // 
            // FrmCyrusBeck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 675);
            this.Controls.Add(this.lblModo);
            this.Controls.Add(this.btnPoligono);
            this.Controls.Add(this.btnFinalizarPoligono);
            this.Controls.Add(this.btnRectangulo);
            this.Controls.Add(this.lblClipInfo);
            this.Controls.Add(this.cboAlgoritmoLinea);
            this.Controls.Add(this.lblAlgoritmoLinea);
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
            this.Name = "FrmCyrusBeck";
            this.Text = "Cyrus-Beck";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCyrusBeck_Load);
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
        private System.Windows.Forms.Label lblDecision;
        private System.Windows.Forms.CheckBox chkProgresivo;
        private System.Windows.Forms.Button btnPaso;
        private System.Windows.Forms.Button btnMostrarTodo;
        private System.Windows.Forms.TrackBar trackBarVelocidad;
        private System.Windows.Forms.Label lblVelocidad;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label lblAlgoritmoLinea;
        private System.Windows.Forms.ComboBox cboAlgoritmoLinea;
        private System.Windows.Forms.Label lblClipInfo;
        private System.Windows.Forms.Label lblModo;
        private System.Windows.Forms.Button btnPoligono;
        private System.Windows.Forms.Button btnFinalizarPoligono;
        private System.Windows.Forms.Button btnRectangulo;
    }
}
