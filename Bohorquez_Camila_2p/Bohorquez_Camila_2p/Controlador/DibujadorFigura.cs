using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Bohorquez_Camila_2p.Controlador
{
    internal class DibujadorFigura
    {
        private List<Point> puntos { get; set; }

        public void dibujar(Graphics g, int width, int height)
        {
            float centroX = width / 2;
            float centroY = height / 2;

            using (Pen p = new Pen(Color.Red, 1))
            {
                for ( float i = 0; i <= centroX; i += 10)
                {
                    //g.DrawLine(p, i, 0, centroX, i);
                    //g.DrawLine(p, i, centroY, 0, i);

                    //g.DrawLine(p, width - i, 0, centroX, i);
                    //g.DrawLine(p, centroX + i, centroY, width, centroY-i);


                    g.DrawLine(p, i, height, centroX, height - i);
                    //g.DrawLine(p, i, centroY, 0, height - i);

                    //g.DrawLine(p, width - i, height, centroX, height - i);
                    //g.DrawLine(p, centroX + i, centroY, width, centroY + i);

                    //g.DrawLine(p, centroX, 0, centroX, height);
                    //g.DrawLine(p, 0, centroY, width, centroY);

                }
            }
        }
    }
}