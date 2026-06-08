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
    internal class ControladorAntialiasing
    {
        public List<Point> puntos { get; private set; }
        public Linea linea { get; private set; }

        public ControladorAntialiasing(Linea linea)
        {
            this.linea = linea;
            puntos = new List<Point>();
        }

        public void generarPuntos()
        {
            float x0 = linea.puntoInicial.X;
            float y0 = linea.puntoInicial.Y;
            float x1 = linea.puntoFinal.X;
            float y1 = linea.puntoFinal.Y;

            for (double t=0; t<=1; t += 0.01)
            {
                int x = (int)(Math.Round(x0 + t * (linea.deltaX())));
                int y = (int)(Math.Round(y0 + t * (linea.deltaY())));

                Point punto = new Point(x, y);
                puntos.Add(punto);
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
