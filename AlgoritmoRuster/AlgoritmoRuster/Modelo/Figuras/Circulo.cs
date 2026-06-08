using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoRuster.Modelo.Figuras
{
    internal class Circulo : IFigura
    {
        public void dibujarFigura(Graphics g, Pen pen, Point puntoInicio, Point puntoFin)
        {
            int x = Math.Min(puntoInicio.X, puntoFin.X);
            int y = Math.Min(puntoInicio.Y, puntoFin.Y);

            int largo = Math.Abs(puntoFin.X - puntoInicio.X);
            int alto = Math.Abs(puntoFin.Y - puntoInicio.Y);

            if (puntoInicio == puntoFin)
                g.DrawEllipse(pen, puntoInicio.X - 5, puntoInicio.Y - 5, 10, 10);

            g.DrawEllipse(pen, x, y, largo, alto);
            
        }
    }
}
