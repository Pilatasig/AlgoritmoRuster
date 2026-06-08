using AlgoritmoRuster.Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoRuster.Controlador
{
    internal class ControladorPuntoMedio
    {
        public List<PointF> puntos { get; private set; }
        public Circunferencia c { get; private set; }

        public ControladorPuntoMedio(Circunferencia circunferencia)
        {
            puntos = new List<PointF>();
            this.c = circunferencia;
        }

        public void generarPuntos()
        {
            float x = 0;
            float y = c.radio;
            float p = 1 - c.radio;
            puntos.Clear();
            crearPuntosSimetricos(c.centro.X, c.centro.Y, x, y);

            while (x < y)
            {
                x++;
                if (p < 0)
                    p += 2 * x + 3;
                else
                {
                    y--;
                    p += 2 * (x - y) + 5;
                }
                crearPuntosSimetricos(c.centro.X, c.centro.Y, x, y);
            }
        }

        private void crearPuntosSimetricos(float cx, float cy, float x, float y)
        {
            puntos.Add(new PointF(cx + x, cy + y));
            puntos.Add(new PointF(cx - x, cy + y));
            puntos.Add(new PointF(cx + x, cy - y));
            puntos.Add(new PointF(cx - x, cy - y));
            puntos.Add(new PointF(cx + y, cy + x));
            puntos.Add(new PointF(cx - y, cy + x));
            puntos.Add(new PointF(cx + y, cy - x));
            puntos.Add(new PointF(cx - y, cy - x));
        }

        public void dibujarFigura(Graphics g)
        {
            generarPuntos();

            using (Brush b = new SolidBrush(Color.Red))
                foreach (PointF p in puntos)
                {
                    g.FillEllipse(b, p.X - 1, p.Y - 1, 2, 2);
                }
        }
    }
}
