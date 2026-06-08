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
    internal class ControladorScanLine : IControladorRelleno
    {
        public int DelayMs { get; set; } = 1;

        public async Task rellenar(Point inicio, Canvas modelo, Panel panel)
        {
            Bitmap bitmap = modelo.bitmapCanvas;
            Color colorObjetivo = bitmap.GetPixel(inicio.X, inicio.Y);
            Color colorRelleno = modelo.currentColor;

            if (colorObjetivo.ToArgb() == colorRelleno.ToArgb()) return;
            
            Stack<Point> puntos = new Stack<Point>();
            puntos.Push(inicio);

            while (puntos.Count > 0)
            {
                Point puntoActual = puntos.Pop();
                int y = puntoActual.Y;
                int xLeft = puntoActual.X;
                int xRight = puntoActual.X + 1;

                while (xLeft >= 0 && bitmap.GetPixel(xLeft, y).ToArgb() == colorObjetivo.ToArgb())
                {
                    bitmap.SetPixel(xLeft, y, colorRelleno);
                    xLeft--;
                }

                while (xRight < bitmap.Width && bitmap.GetPixel(xRight, y).ToArgb() == colorObjetivo.ToArgb())
                {
                    bitmap.SetPixel(xRight, y, colorRelleno);
                    xRight++;
                }

                if (panel != null)
                {
                    panel.Refresh();
                    await Task.Delay(DelayMs);
                }

                escanearLinea(xLeft + 1, xRight - 1, y - 1, puntos, bitmap, colorObjetivo);
                escanearLinea(xLeft + 1, xRight - 1, y + 1, puntos, bitmap, colorObjetivo);
            }
        }

        private void escanearLinea(int xLeft, int xRight, int y, Stack<Point> puntos, Bitmap bitmap, Color colorObjetivo)
        {
            if (y < 0 || y >= bitmap.Height) return;

            bool agregado = false;
            for(int x= xLeft; x <= xRight; x++)
            {
                if (bitmap.GetPixel(x,y).ToArgb()== colorObjetivo.ToArgb())
                {
                    if (!agregado)
                    {
                        puntos.Push(new Point(x,y));
                        agregado = true;
                    }
                }
                else
                {
                    agregado = false;
                }
            }
        }


    }
}
