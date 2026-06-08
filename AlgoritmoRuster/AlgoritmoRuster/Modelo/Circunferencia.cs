using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoRuster.Modelo
{
    internal class Circunferencia
    {

        public PointF centro { get; set; }
        public float radio { get; set; }

        public Circunferencia(PointF centro, float radio)
        {
            this.centro = centro;
            this.radio = radio;
        }

    }
}
