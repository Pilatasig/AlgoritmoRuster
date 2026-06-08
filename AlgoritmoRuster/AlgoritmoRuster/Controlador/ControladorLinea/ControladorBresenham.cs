using AlgoritmoRuster.Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoRuster.Controlador.ControladorLinea
{
    internal class ControladorBresenham
    {
        public Linea linea { get; private set; }
        public List<Point> puntos { get; private set; }

        public ControladorBresenham(Linea linea)
        {
            this.linea = linea;
            puntos = new List<Point>();
        }

        public void generarPuntos()
        {
            int dxAbs = (int)Math.Abs(linea.deltaX());
            int dyAbs = (int)Math.Abs(linea.deltaY());

            int sx = (linea.deltaX() > 0) ? 1 : -1;
            int sy = (linea.deltaY() > 0) ? 1 : -1;

            int x = (int)linea.puntoInicial.X;
            int y = (int)linea.puntoInicial.Y;

            int x2 = (int)linea.puntoFinal.X;
            int y2 = (int)linea.puntoFinal.Y;

            int err = dxAbs - dyAbs;

            while (true)
            {
                Point punto = new Point(x, y);
                puntos.Add(punto);

                if (x == x2 && y == y2)
                    break;

                int err2 = err * 2;

                if (err2 > -dyAbs)
                {
                    err -= dyAbs;
                    x += sx;
                }

                if (err2 < dxAbs)
                {
                    err += dxAbs;
                    y += sy;
                }
            }

        }


        public void dibujarFigura(Graphics g)
        {
            int grosorLinea = 3;
            using (Brush b = new SolidBrush(Color.Aqua))
            {
                foreach (PointF punto in puntos)
                    g.FillRectangle(b, punto.X - grosorLinea / 2, punto.Y - grosorLinea / 2, grosorLinea, grosorLinea);
            }
        }
    }
}
