using AlgoritmoRuster.Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoRuster.Controlador.ControladorCircunferencia
{
    internal class ControladorParamétrica
    {

        public List<Point> puntos { get; private set; }
        public Circunferencia circunferencia { get; private set; }

        public ControladorParamétrica(Circunferencia circunferencia)
        {
            this.circunferencia = circunferencia;
            this.puntos = new List<Point>();
        }

        public void generarPuntos()
        {
            int x, y;
            float xc = circunferencia.centro.X;
            float yc = circunferencia.centro.Y;
            float radio = circunferencia.radio;

            for(double t=0; t<=2*Math.PI; t += 0.01)
            {
                x = (int)(xc + radio * Math.Cos(t));
                y = (int)(yc + radio * Math.Sin(t));
                Point punto = new Point(x, y);
                puntos.Add(punto);
            }
        }

        public void dibujarFigura(Graphics g)
        {
            int grosorLinea = 3;
            using (Brush b= new SolidBrush(Color.Red))
            {
                foreach (Point punto in puntos)
                    g.FillRectangle(b, punto.X - grosorLinea / 2, punto.Y - grosorLinea / 2, grosorLinea, grosorLinea);
            }
        }

    }
}
