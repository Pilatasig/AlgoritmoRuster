namespace AlgoritmoRuster.Vista
{
    partial class FrmSutherlandHodgman
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFormula = new System.Windows.Forms.Label();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblComplejidad = new System.Windows.Forms.Label();
            this.lblDecision = new System.Windows.Forms.Label();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.lblInstruccion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dvgCoordenadas)).BeginInit();
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
            // dvgCoordenadas
            //
            this.dvgCoordenadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgCoordenadas.Location = new System.Drawing.Point(782, 330);
            this.dvgCoordenadas.Name = "dvgCoordenadas";
            this.dvgCoordenadas.RowHeadersWidth = 51;
            this.dvgCoordenadas.RowTemplate.Height = 24;
            this.dvgCoordenadas.Size = new System.Drawing.Size(388, 270);
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
            this.panelExplicativo.Size = new System.Drawing.Size(388, 180);
            this.panelExplicativo.TabIndex = 3;
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(277, 23);
            this.lblTitulo.Text = "Sutherland-Hodgman (Poligono)";
            //
            // lblFormula
            //
            this.lblFormula.AutoSize = true;
            this.lblFormula.Location = new System.Drawing.Point(10, 40);
            this.lblFormula.Name = "lblFormula";
            this.lblFormula.Size = new System.Drawing.Size(196, 20);
            this.lblFormula.Text = "Recorte poligonal por arista";
            //
            // lblCriterio
            //
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(10, 65);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(335, 20);
            this.lblCriterio.Text = "Criterio: Clasifica vertices dentro/fuera de arista";
            //
            // lblTipo
            //
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(10, 90);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(289, 20);
            this.lblTipo.Text = "Tipo: Recorte de poligonos (convexo)";
            //
            // lblComplejidad
            //
            this.lblComplejidad.AutoSize = true;
            this.lblComplejidad.Location = new System.Drawing.Point(10, 115);
            this.lblComplejidad.Name = "lblComplejidad";
            this.lblComplejidad.Size = new System.Drawing.Size(253, 20);
            this.lblComplejidad.Text = "Complejidad: O(n*m) aristas recorridas";
            //
            // lblDecision
            //
            this.lblDecision.AutoSize = true;
            this.lblDecision.Location = new System.Drawing.Point(10, 140);
            this.lblDecision.Name = "lblDecision";
            this.lblDecision.Size = new System.Drawing.Size(349, 20);
            this.lblDecision.Text = "Decision: Dentro/Fuera segun producto cruz";
            //
            // btnFinalizar
            //
            this.btnFinalizar.Location = new System.Drawing.Point(782, 225);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(100, 30);
            this.btnFinalizar.TabIndex = 0;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            //
            // lblInstruccion
            //
            this.lblInstruccion.AutoSize = true;
            this.lblInstruccion.Location = new System.Drawing.Point(782, 200);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(344, 20);
            this.lblInstruccion.Text = "Clic en el panel para definir el poligono";
            //
            // FrmSutherlandHodgman
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 654);
            this.Controls.Add(this.lblInstruccion);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.panelExplicativo);
            this.Controls.Add(this.dvgCoordenadas);
            this.Controls.Add(this.btnResetear);
            this.Controls.Add(this.panelDibujo);
            this.Name = "FrmSutherlandHodgman";
            this.Text = "Sutherland-Hodgman";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSutherlandHodgman_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgCoordenadas)).EndInit();
            this.panelExplicativo.ResumeLayout(false);
            this.panelExplicativo.PerformLayout();
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
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Label lblInstruccion;
    }
}
