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
        private Linea linea;

        public ControladorDDA(Linea linea)
        {
            this.linea = linea;
        }

        public List<PointF> generarPuntos()
        {
            List<PointF> puntos = new List<PointF>();
            float x = linea.puntoInicial.X;
            float y = linea.puntoInicial.Y;

            float deltaX = linea.deltaX();
            float deltaY = linea.deltaY();

            float k = (Math.Abs(deltaX) > Math.Abs(deltaY)) ? Math.Abs(deltaX) : Math.Abs(deltaY);
            float xIncremento = deltaX / k;
            float yIncremento = deltaY / k;

            puntos.Add(linea.puntoInicial);

            for (int i = 0; i < k; i++)
            {
                x += xIncremento;
                y += yIncremento;
                PointF punto = new PointF((float)Math.Round(x), (float)Math.Round(y));
                puntos.Add(punto);
            }

            return puntos;
        }

        public void dibujarFigura(Graphics g)
        {
            int grosorLinea = 3;
            List<PointF> puntos = new List<PointF>();

            puntos = generarPuntos();

            using (Brush b = new SolidBrush(Color.Red))
                foreach (PointF p in puntos)
                    g.FillRectangle(b, p.X-grosorLinea/2, p.Y-grosorLinea/2, grosorLinea, grosorLinea);

            using (Pen pen = new Pen(Color.Aquamarine, 1))
                g.DrawLine(pen, linea.puntoInicial, linea.puntoFinal);
        }
    }
}
