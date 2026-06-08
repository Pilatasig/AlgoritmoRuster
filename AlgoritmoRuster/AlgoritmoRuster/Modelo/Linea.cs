using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoRuster.Modelo
{
    internal class Linea
    {
        public PointF puntoInicial { set; get; }
        public PointF puntoFinal { set; get; }

        public Linea(PointF puntoInicial, PointF puntoFinal)
        {
            this.puntoInicial = puntoInicial;
            this.puntoFinal = puntoFinal;
        }

        public float deltaX() =>puntoFinal.X - puntoInicial.X;
        public float deltaY() => puntoFinal.Y - puntoInicial.Y;

        public float pendiente() => deltaY() / deltaX();
    }
}
