using System;
using System.Collections.Generic;
using System.Drawing;

namespace AlgoritmoRuster.Controlador.ControladorCorteLinea
{
    internal class ControladorCyrusBeck
    {
        public float XMin { get; set; } = -4.0f;
        public float XMax { get; set; } = 4.0f;
        public float YMin { get; set; } = -3.0f;
        public float YMax { get; set; } = 3.0f;

        public List<PointF> Vertices { get; private set; } = new List<PointF>();
        public bool UsarPoligono { get; set; } = false;

        private struct EdgeData { public PointF P; public PointF N; }
        private List<EdgeData> _edges = new List<EdgeData>();

        public void EstablecerPoligono(List<PointF> vertices)
        {
            Vertices = new List<PointF>(vertices);
            _edges.Clear();
            int n = Vertices.Count;
            if (n < 3) return;

            float cx = 0, cy = 0;
            foreach (var v in Vertices) { cx += v.X; cy += v.Y; }
            cx /= n; cy /= n;

            for (int i = 0; i < n; i++)
            {
                PointF v0 = Vertices[i];
                PointF v1 = Vertices[(i + 1) % n];
                float ex = v1.X - v0.X, ey = v1.Y - v0.Y;
                float mx = (v0.X + v1.X) / 2, my = (v0.Y + v1.Y) / 2;

                PointF n1 = new PointF(-ey, ex);
                PointF n2 = new PointF(ey, -ex);

                if (n1.X * (cx - mx) + n1.Y * (cy - my) > 0)
                    _edges.Add(new EdgeData { P = v0, N = n1 });
                else
                    _edges.Add(new EdgeData { P = v0, N = n2 });
            }
        }

        public bool RecortarLinea(ref PointF p1, ref PointF p2)
        {
            if (UsarPoligono && _edges.Count >= 3)
                return RecortarConPoligono(ref p1, ref p2);
            return RecortarConRectangulo(ref p1, ref p2);
        }

        private bool RecortarConPoligono(ref PointF p1, ref PointF p2)
        {
            double dx = p2.X - p1.X;
            double dy = p2.Y - p1.Y;
            double tEnter = 0.0, tLeave = 1.0;

            foreach (var edge in _edges)
            {
                double denom = edge.N.X * dx + edge.N.Y * dy;
                double numer = -(edge.N.X * (p1.X - edge.P.X) + edge.N.Y * (p1.Y - edge.P.Y));

                if (Math.Abs(denom) < 1e-10)
                {
                    if (numer > 0) return false;
                    continue;
                }

                double t = numer / denom;
                if (denom < 0) { if (t < tLeave) tLeave = t; }
                else { if (t > tEnter) tEnter = t; }
                if (tEnter > tLeave) return false;
            }

            float ox = p1.X, oy = p1.Y;
            p1 = new PointF((float)(ox + tEnter * dx), (float)(oy + tEnter * dy));
            p2 = new PointF((float)(ox + tLeave * dx), (float)(oy + tLeave * dy));
            return true;
        }

        private bool RecortarConRectangulo(ref PointF p1, ref PointF p2)
        {
            double dx = p2.X - p1.X;
            double dy = p2.Y - p1.Y;
            double tEnter = 0.0;
            double tLeave = 1.0;

            if (dx != 0)
            {
                double tLeft = (XMin - p1.X) / dx;
                double tRight = (XMax - p1.X) / dx;
                if (dx > 0)
                {
                    if (tLeft > tEnter) tEnter = tLeft;
                    if (tRight < tLeave) tLeave = tRight;
                }
                else
                {
                    if (tRight > tEnter) tEnter = tRight;
                    if (tLeft < tLeave) tLeave = tLeft;
                }
            }
            else
            {
                if (p1.X < XMin || p1.X > XMax) return false;
            }

            if (dy != 0)
            {
                double tBottom = (YMin - p1.Y) / dy;
                double tTop = (YMax - p1.Y) / dy;
                if (dy > 0)
                {
                    if (tBottom > tEnter) tEnter = tBottom;
                    if (tTop < tLeave) tLeave = tTop;
                }
                else
                {
                    if (tTop > tEnter) tEnter = tTop;
                    if (tBottom < tLeave) tLeave = tBottom;
                }
            }
            else
            {
                if (p1.Y < YMin || p1.Y > YMax) return false;
            }

            if (tEnter > tLeave) return false;

            float ox = p1.X, oy = p1.Y;
            p1 = new PointF((float)(ox + tEnter * dx), (float)(oy + tEnter * dy));
            p2 = new PointF((float)(ox + tLeave * dx), (float)(oy + tLeave * dy));
            return true;
        }
    }
}
