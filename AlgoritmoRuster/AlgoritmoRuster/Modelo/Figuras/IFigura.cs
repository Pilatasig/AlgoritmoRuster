using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoRuster.Modelo.Figuras
{
    internal interface IFigura
    {
        void dibujarFigura(Graphics g, Pen pen, Point puntoInicio, Point puntoFin);
    }
}
