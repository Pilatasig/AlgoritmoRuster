using System;
using System.Collections.Generic;
using System.Drawing;

namespace PilatasigDavidBezier.Controlador.ControladorCurva
{
    internal class ControladorBezier
    {
        public List<PointF> PuntosControl { get; private set; }
        public List<PointF> Curva { get; private set; }
        public const int Pasos = 200;

        public ControladorBezier(List<PointF> puntosControl)
        {
            PuntosControl = new List<PointF>(puntosControl);
            Curva = new List<PointF>();
        }

        public void GenerarCurva()
        {
            Curva.Clear();
            if (PuntosControl.Count < 2) return;

            for (int i = 0; i <= Pasos; i++)
            {
                float t = (float)i / Pasos;
                PointF pt = DeCasteljau(PuntosControl, t);
                Curva.Add(pt);
            }
        }

        private PointF DeCasteljau(List<PointF> pts, float t)
        {
            if (pts.Count == 1) return pts[0];

            var nivel = new List<PointF>();
            for (int i = 0; i < pts.Count - 1; i++)
            {
                float x = (1 - t) * pts[i].X + t * pts[i + 1].X;
                float y = (1 - t) * pts[i].Y + t * pts[i + 1].Y;
                nivel.Add(new PointF(x, y));
            }
            return DeCasteljau(nivel, t);
        }
    }
}
