using System;
using System.Drawing;
using System.Windows.Forms;

namespace PilatasigDavidBezier.Utils
{
    public static class DisenoUI
    {
        public static readonly Color FondoFormulario = Color.FromArgb(28, 28, 28);
        public static readonly Color FondoPaneles = Color.FromArgb(40, 40, 40);
        public static readonly Color FondoBotones = Color.FromArgb(55, 55, 57);
        public static readonly Color FondoBotonesHover = Color.FromArgb(70, 70, 73);
        public static readonly Color BotonPresionado = Color.FromArgb(0, 122, 204);
        public static readonly Color BordeControl = Color.FromArgb(80, 80, 80);
        public static readonly Color TextoPrincipal = Color.FromArgb(235, 235, 235);
        public static readonly Color TextoSecundario = Color.FromArgb(140, 140, 140);
        public static readonly Color FilaAlterna = Color.FromArgb(48, 48, 48);
        public static readonly Color MenuFondo = Color.FromArgb(32, 32, 32);
        public static readonly Color MenuTexto = Color.FromArgb(220, 220, 220);
        public static readonly Color MenuHover = Color.FromArgb(50, 50, 52);
        public static readonly Color MenuBorde = Color.FromArgb(60, 60, 60);

        public static readonly Font FuenteTexto = new Font("Segoe UI", 10F, FontStyle.Regular);
        public static readonly Font FuenteBotones = new Font("Segoe UI", 9.5F, FontStyle.Bold);

        public static void AplicarTema(Form formulario)
        {
            formulario.BackColor = FondoFormulario;
            formulario.ForeColor = TextoPrincipal;
            formulario.Font = FuenteTexto;
            EstilizarControlesRegresivos(formulario.Controls);
        }

        private static void EstilizarControlesRegresivos(Control.ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is Button btn)
                {
                    btn.BackColor = FondoBotones;
                    btn.ForeColor = TextoPrincipal;
                    btn.Font = FuenteBotones;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = BordeControl;
                    btn.FlatAppearance.MouseOverBackColor = FondoBotonesHover;
                    btn.FlatAppearance.MouseDownBackColor = BotonPresionado;
                    btn.Cursor = Cursors.Hand;
                }
                else if (control is Panel pnl)
                {
                    if (pnl.Name != "panelDibujo")
                        pnl.BackColor = FondoPaneles;
                }
                else if (control is GroupBox gb)
                {
                    gb.ForeColor = TextoPrincipal;
                    gb.BackColor = FondoPaneles;
                }
                else if (control is DataGridView dgv)
                {
                    dgv.BackgroundColor = FondoPaneles;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.GridColor = Color.FromArgb(55, 55, 55);
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = FondoBotones;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextoPrincipal;
                    dgv.ColumnHeadersDefaultCellStyle.Font = FuenteBotones;
                    dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = FondoBotones;
                    dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgv.DefaultCellStyle.BackColor = FondoPaneles;
                    dgv.DefaultCellStyle.ForeColor = TextoPrincipal;
                    dgv.DefaultCellStyle.SelectionBackColor = BotonPresionado;
                    dgv.DefaultCellStyle.SelectionForeColor = Color.White;
                    dgv.DefaultCellStyle.Font = new Font("Consolas", 9.5F, FontStyle.Regular);
                    dgv.RowHeadersDefaultCellStyle.BackColor = FondoPaneles;
                    dgv.AlternatingRowsDefaultCellStyle.BackColor = FilaAlterna;
                    dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                    dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                    dgv.ColumnHeadersHeight = 30;
                    dgv.RowTemplate.Height = 26;
                    dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                    dgv.RowHeadersVisible = false;
                }
                else if (control is CheckBox chk)
                {
                    chk.ForeColor = TextoPrincipal;
                    chk.BackColor = Color.Transparent;
                }
                else if (control is TrackBar tb)
                {
                    tb.BackColor = FondoPaneles;
                }
                else if (control is Label lbl)
                {
                    lbl.ForeColor = TextoPrincipal;
                    lbl.BackColor = Color.Transparent;
                }

                if (control.Controls.Count > 0)
                    EstilizarControlesRegresivos(control.Controls);
            }
        }
    }
}
