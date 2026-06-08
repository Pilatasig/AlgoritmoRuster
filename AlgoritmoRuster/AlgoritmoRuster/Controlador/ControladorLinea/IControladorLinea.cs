using AlgoritmoRuster.Modelo;
using System.Collections.Generic;
using System.Drawing;

namespace AlgoritmoRuster.Controlador
{
    internal interface IControladorLinea
    {
        Linea linea { get; }
        List<Point> puntos { get; }
        void generarPuntos();
    }
}
