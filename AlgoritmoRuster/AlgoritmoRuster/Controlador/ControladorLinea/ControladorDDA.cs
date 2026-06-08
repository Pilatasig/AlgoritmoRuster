using AlgoritmoRuster.Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoRuster.Controlador
{
    internal class ControladorDDA
    {
        public Linea linea { get; private set; }
        public List<Point> puntos { get; private set; }

        public ControladorDDA(Linea linea)
        {
            this.linea = linea;
            puntos = new List<Point>();
        }

        public void generarPuntos()
        {
            float x = linea.puntoInicial.X;
            float y = linea.puntoInicial.Y;

            float deltaX = linea.deltaX();
            float deltaY = linea.deltaY();

            float k = (Math.Abs(deltaX) > Math.Abs(deltaY)) ? Math.Abs(deltaX) : Math.Abs(deltaY);
            float xIncremento = deltaX / k;
            float yIncremento = deltaY / k;

            puntos.Add(new Point((int)Math.Round(linea.puntoInicial.X), (int)Math.Round(linea.puntoInicial.Y)));

            for (int i = 0; i < k; i++)
            {
                x += xIncremento;
                y += yIncremento;
                Point punto = new Point((int)Math.Round(x), (int)Math.Round(y));
                puntos.Add(punto);
            }
        }

        public void dibujarFigura(Graphics g)
        {
            int grosorLinea = 3;
            using (Brush b = new SolidBrush(Color.Red))
                foreach (Point p in puntos)
                    g.FillRectangle(b, p.X - grosorLinea / 2, p.Y - grosorLinea / 2, grosorLinea, grosorLinea);
        }
    }
}
