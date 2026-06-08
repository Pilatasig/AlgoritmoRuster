using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoRuster.Modelo.Figuras
{
    internal class Estrella : IFigura
    {
        public void dibujarFigura(Graphics g, Pen pen, Point puntoInicio, Point puntoFin)
        {
            int radioExterior = (int)Math.Sqrt(Math.Pow(puntoFin.X - puntoInicio.X, 2) + Math.Pow(puntoFin.Y - puntoInicio.Y, 2));
            if (radioExterior == 0) radioExterior = 1;

            int radioInterior = radioExterior / 3;

            int cantidadPuntas = 5;
            int totalPuntos = cantidadPuntas * 2;

            List<PointF> puntosEstrella = new List<PointF>();
            double anguloInicial = -Math.PI / 2;
            double incrementoAngulo = Math.PI / cantidadPuntas;

            for (int i = 0; i < totalPuntos; i++)
            {
                double r = (i % 2 == 0) ? radioExterior : radioInterior;
                double anguloActual = anguloInicial + (i * incrementoAngulo);

                float x = puntoInicio.X + (float)(r * Math.Cos(anguloActual));
                float y = puntoInicio.Y + (float)(r * Math.Sin(anguloActual));

                puntosEstrella.Add(new PointF(x, y));
            }

            g.DrawPolygon(pen, puntosEstrella.ToArray());
        }
    }
}
