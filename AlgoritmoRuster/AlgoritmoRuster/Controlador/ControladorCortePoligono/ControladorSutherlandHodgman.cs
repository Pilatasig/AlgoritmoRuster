using System;
using System.Collections.Generic;
using System.Drawing;

namespace AlgoritmoRuster.Controlador.ControladorCortePoligono
{
    internal class ControladorSutherlandHodgman
    {
        public List<PointF> ClipVertices { get; set; }
        public List<PointF> Resultado { get; private set; }

        public List<PointF> Recortar(List<PointF> sujeto)
        {
            if (ClipVertices == null || ClipVertices.Count < 3 || sujeto == null || sujeto.Count < 3)
                return null;

            List<PointF> entrada = new List<PointF>(sujeto);
            List<PointF> salida = new List<PointF>();
            int n = ClipVertices.Count;

            for (int i = 0; i < n; i++)
            {
                PointF A = ClipVertices[i];
                PointF B = ClipVertices[(i + 1) % n];
                salida.Clear();

                for (int j = 0; j < entrada.Count; j++)
                {
                    PointF S = entrada[j];
                    PointF P = entrada[(j + 1) % entrada.Count];
                    bool SIn = EstaDentro(S, A, B);
                    bool PIn = EstaDentro(P, A, B);

                    if (SIn && PIn)
                        salida.Add(P);
                    else if (SIn && !PIn)
                        salida.Add(Interseccion(S, P, A, B));
                    else if (!SIn && PIn)
                    {
                        salida.Add(Interseccion(S, P, A, B));
                        salida.Add(P);
                    }
                }

                entrada = new List<PointF>(salida);
                if (entrada.Count == 0) break;
            }

            Resultado = entrada;
            return entrada;
        }

        private bool EstaDentro(PointF p, PointF A, PointF B)
        {
            return (B.X - A.X) * (p.Y - A.Y) - (B.Y - A.Y) * (p.X - A.X) >= -1e-9f;
        }

        private PointF Interseccion(PointF S, PointF P, PointF A, PointF B)
        {
            float dx1 = P.X - S.X, dy1 = P.Y - S.Y;
            float dx2 = B.X - A.X, dy2 = B.Y - A.Y;
            float denom = dx1 * dy2 - dy1 * dx2;
            if (Math.Abs(denom) < 1e-10f) return S;
            float t = ((A.X - S.X) * dy2 - (A.Y - S.Y) * dx2) / denom;
            return new PointF(S.X + t * dx1, S.Y + t * dy1);
        }
    }
}
