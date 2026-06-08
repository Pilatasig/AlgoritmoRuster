using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlgoritmoRuster.Utils
{
    public static class DisenoUI
    {
        // PALETA DE COLORES (Estilo Dark/Moderno)
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

        // FUENTES
        public static readonly Font FuenteTexto = new Font("Segoe UI", 10F, FontStyle.Regular);
        public static readonly Font FuenteBotones = new Font("Segoe UI", 9.5F, FontStyle.Bold);

        private static bool _estiloMenuAplicado = false;

        public static void AplicarTema(Form formulario)
        {
            formulario.BackColor = FondoFormulario;
            formulario.ForeColor = TextoPrincipal;
            formulario.Font = FuenteTexto;

            EstilizarControlesRegresivos(formulario.Controls);

            if (!_estiloMenuAplicado)
            {
                ToolStripManager.Renderer = new RendererMenuOscuro();
                _estiloMenuAplicado = true;
            }

            if (formulario.MainMenuStrip != null)
                EstilizarMenuStrip(formulario.MainMenuStrip);
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
                else if (control is ComboBox cmb)
                {
                    cmb.BackColor = FondoPaneles;
                    cmb.ForeColor = TextoPrincipal;
                    cmb.FlatStyle = FlatStyle.Flat;
                }
                else if (control is TextBox txt)
                {
                    txt.BackColor = Color.FromArgb(50, 50, 50);
                    txt.ForeColor = TextoPrincipal;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (control is ListBox lst)
                {
                    lst.BackColor = FondoPaneles;
                    lst.ForeColor = TextoPrincipal;
                    lst.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (control is CheckBox chk)
                {
                    chk.ForeColor = TextoPrincipal;
                    chk.BackColor = Color.Transparent;
                }
                else if (control is RadioButton rb)
                {
                    rb.ForeColor = TextoPrincipal;
                    rb.BackColor = Color.Transparent;
                }
                else if (control is TrackBar tb)
                {
                    tb.BackColor = FondoPaneles;
                }
                else if (control is NumericUpDown nud)
                {
                    nud.BackColor = Color.FromArgb(50, 50, 50);
                    nud.ForeColor = TextoPrincipal;
                    nud.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (control is Label lbl && !(control is LinkLabel))
                {
                    lbl.ForeColor = TextoPrincipal;
                    lbl.BackColor = Color.Transparent;
                }
                else if (control is RichTextBox rtf)
                {
                    rtf.BackColor = Color.FromArgb(50, 50, 50);
                    rtf.ForeColor = TextoPrincipal;
                    rtf.BorderStyle = BorderStyle.FixedSingle;
                }

                if (control.Controls.Count > 0)
                    EstilizarControlesRegresivos(control.Controls);
            }
        }

        private static void EstilizarMenuStrip(MenuStrip menu)
        {
            menu.BackColor = MenuFondo;
            menu.ForeColor = MenuTexto;
            foreach (ToolStripMenuItem item in menu.Items)
                EstilizarItemsMenu(item);
        }

        private static void EstilizarItemsMenu(ToolStripMenuItem item)
        {
            item.BackColor = MenuFondo;
            item.ForeColor = MenuTexto;
            item.Font = FuenteTexto;
            item.DropDown.Font = FuenteTexto;
            foreach (ToolStripItem sub in item.DropDownItems)
            {
                if (sub is ToolStripMenuItem subItem)
                {
                    subItem.BackColor = MenuFondo;
                    subItem.ForeColor = MenuTexto;
                    subItem.Font = FuenteTexto;
                    subItem.DropDown.Font = FuenteTexto;
                    EstilizarItemsMenu(subItem);
                }
                else if (sub is ToolStripSeparator sep)
                {
                    sep.Paint += (s, e) =>
                    {
                        e.Graphics.FillRectangle(new SolidBrush(MenuBorde),
                            e.ClipRectangle.X, e.ClipRectangle.Y + 1,
                            e.ClipRectangle.Width, 1);
                    };
                }
            }
            item.DropDown.Font = FuenteTexto;
        }

        private class RendererMenuOscuro : ToolStripProfessionalRenderer
        {
            public RendererMenuOscuro() : base(new ColoresMenuOscuro()) { }

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (e.Item.Selected || (e.Item as ToolStripMenuItem)?.DropDown.Visible == true)
                {
                    using (Brush b = new SolidBrush(MenuHover))
                        e.Graphics.FillRectangle(b, 0, 0, e.Item.Width, e.Item.Height);
                }
                else
                {
                    using (Brush b = new SolidBrush(MenuFondo))
                        e.Graphics.FillRectangle(b, 0, 0, e.Item.Width, e.Item.Height);
                }
            }

            protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
            {
                using (Brush b = new SolidBrush(MenuFondo))
                    e.Graphics.FillRectangle(b, e.AffectedBounds);
            }

            protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
            {
                using (Brush b = new SolidBrush(MenuBorde))
                    e.Graphics.FillRectangle(b, e.Item.ContentRectangle.X, e.Item.ContentRectangle.Y + 2,
                        e.Item.ContentRectangle.Width, 1);
            }

            protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
            {
                using (Brush b = new SolidBrush(MenuFondo))
                    e.Graphics.FillRectangle(b, e.AffectedBounds);
            }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                e.TextColor = e.Item.Enabled ? MenuTexto : TextoSecundario;
                base.OnRenderItemText(e);
            }
        }

        private class ColoresMenuOscuro : ProfessionalColorTable
        {
            public override Color MenuItemBorder => MenuBorde;
            public override Color MenuItemSelected => MenuHover;
            public override Color MenuItemSelectedGradientBegin => MenuHover;
            public override Color MenuItemSelectedGradientEnd => MenuHover;
            public override Color MenuStripGradientBegin => MenuFondo;
            public override Color MenuStripGradientEnd => MenuFondo;
            public override Color ImageMarginGradientBegin => MenuFondo;
            public override Color ImageMarginGradientEnd => MenuFondo;
            public override Color ImageMarginGradientMiddle => MenuFondo;
            public override Color ToolStripDropDownBackground => MenuFondo;
            public override Color ToolStripBorder => MenuBorde;
            public override Color OverflowButtonGradientBegin => MenuFondo;
            public override Color OverflowButtonGradientEnd => MenuFondo;
            public override Color MenuBorder => MenuBorde;
        }
    }
}
