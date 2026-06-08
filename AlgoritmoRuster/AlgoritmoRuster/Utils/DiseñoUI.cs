using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoRuster.Utils
{
    public static class DisenoUI
    {
        // 🌟 PALETA DE COLORES (Estilo Dark/Moderno)
        public static readonly Color FondoFormulario = Color.FromArgb(30, 30, 30);      // Gris muy oscuro
        public static readonly Color FondoPaneles = Color.FromArgb(43, 43, 43);         // Gris intermedio
        public static readonly Color FondoBotones = Color.FromArgb(55, 55, 57);         // Gris claro para botones
        public static readonly Color BotonPresionado = Color.FromArgb(0, 122, 204);     // Azul acento (Estilo VS)
        public static readonly Color TextoPrincipal = Color.FromArgb(240, 240, 240);    // Blanco suave
        public static readonly Color TextoSecundario = Color.FromArgb(150, 150, 150);   // Gris texto apagado

        // 🌟 FUENTES
        public static readonly Font FuenteTexto = new Font("Segoe UI", 10F, FontStyle.Regular);
        public static readonly Font FuenteBotones = new Font("Segoe UI", 9.5F, FontStyle.Bold);

        /// <summary>
        /// Aplica de forma automática el diseño moderno a cualquier formulario y a todos sus controles internos.
        /// </summary>
        public static void AplicarTema(Form formulario)
        {
            formulario.BackColor = FondoFormulario;
            formulario.ForeColor = TextoPrincipal;
            formulario.Font = FuenteTexto;

            // Recorrer recursivamente todos los controles del formulario
            EstilizarControlesRegresivos(formulario.Controls);
        }

        private static void EstilizarControlesRegresivos(Control.ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                // 1. Estilizar BOTONES
                if (control is Button btn)
                {
                    btn.BackColor = FondoBotones;
                    btn.ForeColor = TextoPrincipal;
                    btn.Font = FuenteBotones;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(85, 85, 85);
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 73);
                    btn.Cursor = Cursors.Hand;
                }
                // 2. Estilizar PANELES (Excepto tu lienzo de dibujo principal)
                else if (control is Panel pnl)
                {
                    // Evitamos pintar de oscuro el lienzo donde dibujas
                    if (pnl.Name != "panelDibujo")
                    {
                        pnl.BackColor = FondoPaneles;
                    }
                }
                // 3. Estilizar DATAGRIDVIEW (Tablas de datos)
                else if (control is DataGridView dgv)
                {
                    dgv.BackgroundColor = FondoPaneles;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.GridColor = Color.FromArgb(60, 60, 60);
                    dgv.EnableHeadersVisualStyles = false;

                    // Cabeceras
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = FondoBotones;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextoPrincipal;
                    dgv.ColumnHeadersDefaultCellStyle.Font = FuenteBotones;
                    dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = FondoBotones;

                    // Filas / Celdas
                    dgv.DefaultCellStyle.BackColor = FondoPaneles;
                    dgv.DefaultCellStyle.ForeColor = TextoPrincipal;
                    dgv.DefaultCellStyle.SelectionBackColor = BotonPresionado;
                    dgv.DefaultCellStyle.SelectionForeColor = Color.White;

                    dgv.RowHeadersDefaultCellStyle.BackColor = FondoPaneles;
                }
                // 4. Estilizar COMBOBOX, TEXTBOX o LISTBOX
                else if (control is ComboBox || control is TextBox || control is ListBox)
                {
                    control.BackColor = FondoPaneles;
                    control.ForeColor = TextoPrincipal;
                }
                // 5. Estilizar ETIQUETAS (Labels)
                else if (control is Label lbl)
                {
                    lbl.ForeColor = TextoPrincipal;
                }

                // 🔄 Si el control tiene sub-controles dentro (ej: un Panel que tiene botones dentro)
                if (control.Controls.Count > 0)
                {
                    EstilizarControlesRegresivos(control.Controls);
                }
            }
        }
    }
}
