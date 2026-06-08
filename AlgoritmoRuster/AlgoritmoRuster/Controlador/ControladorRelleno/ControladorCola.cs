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
    internal class ControladorCola : IControladorRelleno
    {
        public int DelayMs { get; set; } = 1;

        public async Task rellenar(Point inicio, Canvas modelo, Panel panel)
        {
            Bitmap bitmap = modelo.bitmapCanvas;
            Color colorObjetivo = bitmap.GetPixel(inicio.X, inicio.Y);
            Color colorRelleno = modelo.currentColor;

            if (colorObjetivo.ToArgb() == colorRelleno.ToArgb()) return;
            
            Queue<Point> pixels = new Queue<Point>();
            pixels.Enqueue(inicio);

            while (pixels.Count > 0)
            {
                Point pixel = pixels.Dequeue();
                if (pixel.X < 0 || pixel.X >= bitmap.Width || pixel.Y < 0 || pixel.Y >= bitmap.Height)
                    continue;

                if (bitmap.GetPixel(pixel.X, pixel.Y).ToArgb() == colorObjetivo.ToArgb())
                {
                    bitmap.SetPixel(pixel.X, pixel.Y, colorRelleno);

                    if (panel != null)
                    {
                        panel.Refresh();
                        await Task.Delay(DelayMs);
                    }

                    pixels.Enqueue(new Point(pixel.X, pixel.Y - 1));
                    pixels.Enqueue(new Point(pixel.X + 1, pixel.Y - 1));
                    pixels.Enqueue(new Point(pixel.X + 1, pixel.Y));
                    pixels.Enqueue(new Point(pixel.X + 1, pixel.Y + 1));
                    pixels.Enqueue(new Point(pixel.X, pixel.Y + 1));
                    pixels.Enqueue(new Point(pixel.X - 1, pixel.Y + 1));
                    pixels.Enqueue(new Point(pixel.X - 1, pixel.Y));
                    pixels.Enqueue(new Point(pixel.X - 1, pixel.Y - 1));
                }
            }
        }
    }
}
