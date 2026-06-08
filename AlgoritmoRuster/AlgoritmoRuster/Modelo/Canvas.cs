using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoRuster.Modelo
{
    internal class Canvas
    {

        public Bitmap bitmapCanvas { get; private set; }
        public Color currentColor { get; set; } = Color.Black;
        public String herramientaSeleccionada { get; set; }

        public Canvas(int width, int height)
        {
            bitmapCanvas = new Bitmap(width, height);
            using (Graphics g= Graphics.FromImage(bitmapCanvas))
            {
                g.Clear(Color.White);
            }
        }

        public void cambiarTamaño(int width, int height)
        {
            Bitmap oldWall = bitmapCanvas;
            bitmapCanvas= new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bitmapCanvas))
            {
                g.Clear(Color.White);
                if (oldWall != null) g.DrawImage(oldWall, 0, 0);
            }

        }

    }
}
