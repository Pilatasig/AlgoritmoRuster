using AlgoritmoRuster.Modelo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoRuster.Controlador
{
internal class ControladorPuntoMedio
{
    public List<Point> puntos { get; private set; }
    public Circunferencia c { get; private set; }

    public ControladorPuntoMedio(Circunferencia circunferencia)
    {
        puntos = new List<Point>();
        this.c = circunferencia;
    }

    public void generarPuntos()
    {
        int cx = (int)Math.Round(c.centro.X);
        int cy = (int)Math.Round(c.centro.Y);
        int x = 0;
        int y = (int)Math.Round(c.radio);
        int p = 1 - (int)Math.Round(c.radio);
        puntos.Clear();
        crearPuntosSimetricos(cx, cy, x, y);

        while (x < y)
        {
            x++;
            if (p < 0)
                p += 2 * x + 3;
            else
            {
                y--;
                p += 2 * (x - y) + 5;
            }
            crearPuntosSimetricos(cx, cy, x, y);
        }
    }

    private void crearPuntosSimetricos(int cx, int cy, int x, int y)
    {
        puntos.Add(new Point(cx + x, cy + y));
        puntos.Add(new Point(cx - x, cy + y));
        puntos.Add(new Point(cx + x, cy - y));
        puntos.Add(new Point(cx - x, cy - y));
        puntos.Add(new Point(cx + y, cy + x));
        puntos.Add(new Point(cx - y, cy + x));
        puntos.Add(new Point(cx + y, cy - x));
        puntos.Add(new Point(cx - y, cy - x));
    }

    public void dibujarFigura(Graphics g)
    {
        generarPuntos();

        using (Brush b = new SolidBrush(Color.Red))
            foreach (Point p in puntos)
                g.FillRectangle(b, p.X - 1, p.Y - 1, 2, 2);
    }
}
}
