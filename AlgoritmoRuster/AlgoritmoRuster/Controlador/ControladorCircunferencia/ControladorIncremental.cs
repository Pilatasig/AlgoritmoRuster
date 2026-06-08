using AlgoritmoRuster.Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoRuster.Controlador.ControladorCircunferencia
{
    internal class ControladorIncremental
    {

        public Circunferencia circunferencia { get; private set; }
        public List<Point> puntos { get; private set; }

        public ControladorIncremental(Point centro, float radio)
        {
            circunferencia = new Circunferencia(centro, radio);
            puntos = new List<Point>();
        }

        public void generarPuntos()
        {
            double delta = 0.01;

            float cx = circunferencia.centro.X;
            float cy = circunferencia.centro.Y;

            double cosD = Math.Cos(delta);
            double sinD = Math.Sin(delta);

            double x = circunferencia.radio;
            double y = 0;

            int pasos = (int)(2 * Math.PI / delta);

            for(int i=0; i<pasos; i++)
            {
                Point punto = new Point((int)(cx + Math.Round(x)), (int)(cy + Math.Round(y)));
                puntos.Add(punto);

                double xn = x * cosD - y * sinD;
                double yn = x * sinD + y * cosD;

                x = xn;
                y = yn;
            }
        }

        public void dibujarFigura(Graphics g)
        {
            int grosorLinea = 3;

            using (Brush b = new SolidBrush(Color.Red))
            {
                foreach (Point p in puntos)
                    g.FillRectangle(b, p.X - grosorLinea / 2, p.Y - grosorLinea / 2, grosorLinea, grosorLinea);
            }    
        }
    }
}
