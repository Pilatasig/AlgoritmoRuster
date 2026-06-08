using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoRuster.Modelo.Figuras
{
    internal class Rectangulo : IFigura
    {
        public void dibujarFigura(Graphics g, Pen pen, Point puntoInicio, Point puntoFin)
        {
            int x = Math.Min(puntoInicio.X, puntoFin.X);
            int y = Math.Min(puntoInicio.Y, puntoFin.Y);
            int ancho = Math.Abs(puntoFin.X - puntoInicio.X);
            int alto = Math.Abs(puntoFin.Y - puntoInicio.Y);

            if (ancho == 0) ancho = 1;
            if (alto == 0) alto = 1;

            g.DrawRectangle(pen, x, y, ancho, alto);
        }
    }
}
