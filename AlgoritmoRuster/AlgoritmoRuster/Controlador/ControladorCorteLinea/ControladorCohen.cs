using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoRuster.Controlador.ControladorCorteLinea
{
    internal class ControladorCohen
    {

        public const float X_MIN = -4.0f;
        public const float X_MAX = 4.0f;
        public const float Y_MIN = -3.0f;
        public const float Y_MAX = 3.0f;

        private const int DENTRO = 0;    
        private const int IZQUIERDA = 1; 
        private const int DERECHA = 2;   
        private const int ABAJO = 4;     
        private const int ARRIBA = 8;    
        

        private int CalcularOutcode(double x, double y)
        {
            int codigo = DENTRO;

            if (x < X_MIN) codigo |= IZQUIERDA;
            else if (x > X_MAX) codigo |= DERECHA;

            if (y < Y_MIN) codigo |= ABAJO;
            else if (y > Y_MAX) codigo |= ARRIBA;  

            return codigo;
        }

        public bool RecortarLineaParametrica(ref PointF p1, ref PointF p2)
        {
            double x1 = p1.X, y1 = p1.Y;
            double x2 = p2.X, y2 = p2.Y;

            int outcode1 = CalcularOutcode(x1, y1);
            int outcode2 = CalcularOutcode(x2, y2);
            bool aceptar = false;

            while (true)
            {
                
                if ((outcode1 | outcode2) == 0)
                {
                    aceptar = true;
                    break;
                }
                
                else if ((outcode1 & outcode2) != 0)
                {
                    break;
                }
                
                else
                {
                    double x = 0, y = 0;
                    double t = 0;
                    int outcodeOut = (outcode1 != DENTRO) ? outcode1 : outcode2;

                   
                    if ((outcodeOut & ARRIBA) != 0)
                    {
                        t = (Y_MAX - y1) / (y2 - y1);
                        x = x1 + t * (x2 - x1);
                        y = Y_MAX;
                    }
                    else if ((outcodeOut & ABAJO) != 0)
                    {
                        t = (Y_MIN - y1) / (y2 - y1);
                        x = x1 + t * (x2 - x1);
                        y = Y_MIN;
                    }
                    else if ((outcodeOut & DERECHA) != 0)
                    {
                        t = (X_MAX - x1) / (x2 - x1);
                        y = y1 + t * (y2 - y1);
                        x = X_MAX;
                    }
                    else if ((outcodeOut & IZQUIERDA) != 0)
                    {
                        t = (X_MIN - x1) / (x2 - x1);
                        y = y1 + t * (y2 - y1);
                        x = X_MIN;
                    }

                   
                    if (outcodeOut == outcode1)
                    {
                        x1 = x; y1 = y;
                        outcode1 = CalcularOutcode(x1, y1);
                    }
                    else
                    {
                        x2 = x; y2 = y;
                        outcode2 = CalcularOutcode(x2, y2);
                    }
                }
            }

            if (aceptar)
            {
                p1 = new PointF((float)x1, (float)y1);
                p2 = new PointF((float)x2, (float)y2);
                return true;
            }

            return false;
        }
    }

}
