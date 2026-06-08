using AlgoritmoRuster.Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoRuster.Controlador.ControladorRelleno
{
    internal class ControladorInundacion : IControladorRelleno
    {

        public async Task rellenar(Point inicio, Canvas modelo, Panel panel)
        {
            Bitmap bitmap = modelo.bitmapCanvas;
            Color colorObjetivo = bitmap.GetPixel(inicio.X, inicio.Y);
            Color colorRelleno = modelo.currentColor;

            if (colorObjetivo.ToArgb() == colorRelleno.ToArgb()) return;
            await aplicarRelleno(inicio.X, inicio.Y, bitmap, colorObjetivo, colorRelleno, panel);
        }

        private async Task aplicarRelleno(int x, int y, Bitmap bitmap, Color colorObjetivo, Color colorRelleno, Panel panel)
        {
            if (x < 0 || x >= bitmap.Width || y < 0 || y >= bitmap.Height) return;

            if (bitmap.GetPixel(x, y).ToArgb() != colorObjetivo.ToArgb()) return;

            bitmap.SetPixel(x, y, colorRelleno);

            panel.Refresh();
            await Task.Delay(1);

            aplicarRelleno(x, y - 1, bitmap, colorObjetivo, colorRelleno, panel);
            aplicarRelleno(x + 1, y, bitmap, colorObjetivo, colorRelleno, panel);
            aplicarRelleno(x, y + 1, bitmap, colorObjetivo, colorRelleno, panel);
            aplicarRelleno(x - 1, y, bitmap, colorObjetivo, colorRelleno, panel);
        }
    }
}
