using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoRuster.Modelo
{
    internal class LineaCartesiana
    {

        public PointF PuntoInicio { get; set; }
        public PointF PuntoFin { get; set; }
        public bool EsValida { get; set; } = false;

        public void Configurar(PointF inicio, PointF fin)
        {
            PuntoInicio = inicio;
            PuntoFin = fin;
            EsValida = true;
        }

        public void Limpiar()
        {
            EsValida = false;
        }

    }
}
