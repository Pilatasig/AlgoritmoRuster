using AlgoritmoRuster.Controlador.ControladorCorteLinea;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoRuster.Utils
{
    internal class DibujadorPlano
    {
        public int EspaciadoPixeles { get; set; } = 40;
        public int UnidadPorMarca { get; set; } = 1;

        private readonly Color ColorCuadricula = Color.FromArgb(40, 40, 40);
        private readonly Color ColorEjes = Color.FromArgb(100, 100, 100);
        private readonly Color ColorTexto = Color.FromArgb(140, 140, 140);

        public void Dibujar(Graphics g, int ancho, int alto)
        {
            int origenX = ancho / 2;
            int origenY = alto / 2;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 1. Cuadrícula
            using (Pen penCuadricula = new Pen(ColorCuadricula, 1))
            {
                for (int x = origenX; x < ancho; x += EspaciadoPixeles) g.DrawLine(penCuadricula, x, 0, x, alto);
                for (int x = origenX; x >= 0; x -= EspaciadoPixeles) g.DrawLine(penCuadricula, x, 0, x, alto);
                for (int y = origenY; y < alto; y += EspaciadoPixeles) g.DrawLine(penCuadricula, 0, y, ancho, y);
                for (int y = origenY; y >= 0; y -= EspaciadoPixeles) g.DrawLine(penCuadricula, 0, y, ancho, y);
            }

            // 2. Resaltar la Ventana de Recorte de Cohen-Sutherland (Caja Verde translúcida)
            Point ventanaMinPantalla = CartesianoAPantalla(new PointF(ControladorCohen.X_MIN, ControladorCohen.Y_MAX), ancho, alto);
            Point ventanaMaxPantalla = CartesianoAPantalla(new PointF(ControladorCohen.X_MAX, ControladorCohen.Y_MIN), ancho, alto);

            int rectW = ventanaMaxPantalla.X - (int)ventanaMinPantalla.X;
            int rectH = ventanaMaxPantalla.Y - (int)ventanaMinPantalla.Y;

            using (SolidBrush brushVentana = new SolidBrush(Color.FromArgb(25, Color.GreenYellow)))
            using (Pen penVentana = new Pen(Color.GreenYellow, 1.5f) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
            {
                g.FillRectangle(brushVentana, ventanaMinPantalla.X, ventanaMinPantalla.Y, rectW, rectH);
                g.DrawRectangle(penVentana, ventanaMinPantalla.X, ventanaMinPantalla.Y, rectW, rectH);
            }

            // 3. Ejes principales
            using (Pen penEjes = new Pen(ColorEjes, 2))
            {
                g.DrawLine(penEjes, 0, origenY, ancho, origenY);
                g.DrawLine(penEjes, origenX, 0, origenX, alto);
            }

            // 4. Graduaciones y etiquetas numéricas
            using (Font fuente = new Font("Consolas", 8, FontStyle.Regular))
            using (Brush brush = new SolidBrush(ColorTexto))
            using (Pen penMarca = new Pen(ColorEjes, 1.5f))
            {
                int val = 0;
                for (int x = origenX; x < ancho; x += EspaciadoPixeles)
                {
                    g.DrawLine(penMarca, x, origenY - 3, x, origenY + 3);
                    if (val != 0) g.DrawString((val * UnidadPorMarca).ToString(), fuente, brush, x - 6, origenY + 6);
                    val++;
                }
                val = 0;
                for (int x = origenX; x >= 0; x -= EspaciadoPixeles)
                {
                    g.DrawLine(penMarca, x, origenY - 3, x, origenY + 3);
                    if (val != 0) g.DrawString((val * -UnidadPorMarca).ToString(), fuente, brush, x - 12, origenY + 6);
                    val++;
                }
                val = 0;
                for (int y = origenY; y < alto; y += EspaciadoPixeles)
                {
                    g.DrawLine(penMarca, origenX - 3, y, origenX + 3, y);
                    if (val != 0) g.DrawString((val * -UnidadPorMarca).ToString(), fuente, brush, origenX + 8, y - 5);
                    val++;
                }
                val = 0;
                for (int y = origenY; y >= 0; y -= EspaciadoPixeles)
                {
                    g.DrawLine(penMarca, origenX - 3, y, origenX + 3, y);
                    if (val != 0) g.DrawString((val * UnidadPorMarca).ToString(), fuente, brush, origenX + 8, y - 5);
                    val++;
                }
                g.DrawString("0", fuente, brush, origenX - 12, origenY + 6);
            }
        }

        public PointF PantallaACartesiano(Point p, int ancho, int alto)
        {
            float x = (p.X - (ancho / 2f)) / EspaciadoPixeles * UnidadPorMarca;
            float y = ((alto / 2f) - p.Y) / EspaciadoPixeles * UnidadPorMarca;
            return new PointF((float)Math.Round(x, 2), (float)Math.Round(y, 2));
        }

        public Point CartesianoAPantalla(PointF p, int ancho, int alto)
        {
            int x = (int)((ancho / 2f) + (p.X / UnidadPorMarca * EspaciadoPixeles));
            int y = (int)((alto / 2f) - (p.Y / UnidadPorMarca * EspaciadoPixeles));
            return new Point(x, y);
        }

    }
}
