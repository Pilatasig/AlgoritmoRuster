using System.Drawing;

namespace AlgoritmoRuster.Controlador.ControladorCorteLinea
{
    internal class ControladorCohen
    {
        public float XMin { get; set; } = -4.0f;
        public float XMax { get; set; } = 4.0f;
        public float YMin { get; set; } = -3.0f;
        public float YMax { get; set; } = 3.0f;

        private const int DENTRO = 0;
        private const int IZQUIERDA = 1;
        private const int DERECHA = 2;
        private const int ABAJO = 4;
        private const int ARRIBA = 8;

        private int CalcularOutcode(double x, double y)
        {
            int codigo = DENTRO;
            if (x < XMin) codigo |= IZQUIERDA;
            else if (x > XMax) codigo |= DERECHA;
            if (y < YMin) codigo |= ABAJO;
            else if (y > YMax) codigo |= ARRIBA;
            return codigo;
        }

        public bool RecortarLinea(ref PointF p1, ref PointF p2)
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
                    int outcodeOut = (outcode1 != DENTRO) ? outcode1 : outcode2;

                    if ((outcodeOut & ARRIBA) != 0)
                    {
                        double t = (YMax - y1) / (y2 - y1);
                        x = x1 + t * (x2 - x1);
                        y = YMax;
                    }
                    else if ((outcodeOut & ABAJO) != 0)
                    {
                        double t = (YMin - y1) / (y2 - y1);
                        x = x1 + t * (x2 - x1);
                        y = YMin;
                    }
                    else if ((outcodeOut & DERECHA) != 0)
                    {
                        double t = (XMax - x1) / (x2 - x1);
                        y = y1 + t * (y2 - y1);
                        x = XMax;
                    }
                    else if ((outcodeOut & IZQUIERDA) != 0)
                    {
                        double t = (XMin - x1) / (x2 - x1);
                        y = y1 + t * (y2 - y1);
                        x = XMin;
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
