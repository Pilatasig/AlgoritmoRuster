using AlgoritmoRuster.Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace AlgoritmoRuster.Controlador
{
    internal class ControladorCelda
    {
        public List<Celda> ListaCeldas { get; private set; }
        private int celdaSize = 10;

        public ControladorCelda()
        {
            ListaCeldas = new List<Celda>();
        }

        public void generarCeldas(int width, int height)
        {
            ListaCeldas.Clear();

            for (int x = 0; x <= width - celdaSize; x += celdaSize)
            {
                for (int y = 0; y <= height - celdaSize; y += celdaSize)
                {
                    Point pSuperior = new Point(x, y);
                    Point pInferior = new Point(x + celdaSize, y + celdaSize);
                    Celda nuevaCelda = new Celda(pSuperior, pInferior, false);
                    ListaCeldas.Add(nuevaCelda);
                }
            }
        }

        public void DibujarCeldasBase(Graphics g)
        {
            using (Pen pen = new Pen(Color.LightGray, 1))
            {
                foreach (Celda c in ListaCeldas)
                {
                    int anchoCelda = (int)c.getAncho();
                    int largoCelda = (int)c.getLargo();
                    g.DrawRectangle(pen, c.puntoSuperior.X, c.puntoSuperior.Y, anchoCelda, largoCelda);
                }
            }
        }

        public void actualizarEstadoCeldas(List<PointF> puntosLinea)
        {
            foreach (PointF p in puntosLinea)
            {
                int celdaX = ((int)p.X / celdaSize) * celdaSize;
                int celdaY = ((int)p.Y / celdaSize) * celdaSize;

                Celda celdaAfectada = ListaCeldas.Find(c => c.puntoSuperior.X == celdaX && c.puntoSuperior.Y == celdaY);
                if (celdaAfectada != null)
                    celdaAfectada.estado = true;
            }
        }

        public void colorearCeldas(Graphics g)
        {
            using (Pen pen = new Pen(Color.Black, 1))
            using (Brush b = new SolidBrush(Color.Aquamarine))
            {
                foreach (Celda c in ListaCeldas)
                {
                    if (c.estado)
                    {
                        int anchoCelda = (int)c.getAncho();
                        int largoCelda = (int)c.getLargo();
                        g.FillRectangle(b, c.puntoSuperior.X, c.puntoSuperior.Y, anchoCelda, largoCelda);
                        g.DrawRectangle(pen, c.puntoSuperior.X, c.puntoSuperior.Y, anchoCelda, largoCelda);
                    }
                }
            }
        }

        public void LimpiarLienzo()
        {
            foreach (Celda c in ListaCeldas)
            {
                c.estado = false;
            }
        }
    }
}