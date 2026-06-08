using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoRuster.Modelo
{
    internal class Celda
    {
        public PointF puntoSuperior { set; get; }
        public PointF puntoInferior { set; get; }

        public bool estado { set; get; }

        public Celda(PointF puntoSuperior, PointF puntoInferior, bool estado)
        {
            this.puntoSuperior = puntoSuperior;
            this.puntoInferior = puntoInferior;
            this.estado = estado;
        }

        public PointF getlimitesX() => new PointF(puntoSuperior.X, puntoInferior.X);
        public PointF getLimitesY() => new PointF(puntoSuperior.Y, puntoInferior.Y);

        public float getAncho() => puntoInferior.X - puntoSuperior.X;
        public float getLargo() => puntoInferior.Y - puntoSuperior.Y;
    }
}
