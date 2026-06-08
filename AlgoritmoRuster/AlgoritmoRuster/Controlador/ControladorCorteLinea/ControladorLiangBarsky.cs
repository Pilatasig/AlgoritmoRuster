using System;
using System.Drawing;

namespace AlgoritmoRuster.Controlador.ControladorCorteLinea
{
    internal class ControladorLiangBarsky
    {
        public float XMin { get; set; } = -4.0f;
        public float XMax { get; set; } = 4.0f;
        public float YMin { get; set; } = -3.0f;
        public float YMax { get; set; } = 3.0f;

        public bool RecortarLinea(ref PointF p1, ref PointF p2)
        {
            double dx = p2.X - p1.X;
            double dy = p2.Y - p1.Y;
            double tEnter = 0.0, tLeave = 1.0;

            if (!ClipTest(-dx, p1.X - XMin, ref tEnter, ref tLeave)) return false;
            if (!ClipTest(dx, XMax - p1.X, ref tEnter, ref tLeave)) return false;
            if (!ClipTest(-dy, p1.Y - YMin, ref tEnter, ref tLeave)) return false;
            if (!ClipTest(dy, YMax - p1.Y, ref tEnter, ref tLeave)) return false;

            float ox = p1.X, oy = p1.Y;
            p1 = new PointF((float)(ox + tEnter * dx), (float)(oy + tEnter * dy));
            p2 = new PointF((float)(ox + tLeave * dx), (float)(oy + tLeave * dy));
            return true;
        }

        private bool ClipTest(double p, double q, ref double tEnter, ref double tLeave)
        {
            if (Math.Abs(p) < 1e-10)
            {
                if (q < 0) return false;
                return true;
            }

            double r = q / p;
            if (p < 0)
            {
                if (r > tEnter) tEnter = r;
            }
            else
            {
                if (r < tLeave) tLeave = r;
            }

            return tEnter <= tLeave;
        }
    }
}
