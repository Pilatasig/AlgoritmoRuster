using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AlgoritmoRuster.Controlador
{
    internal class ControladorProgresivo
    {
        private Timer timer;
        private List<Point> puntosCompletos;
        private int indiceActual;

        public int Interval
        {
            get => timer.Interval;
            set => timer.Interval = Math.Max(10, value);
        }

        public List<Point> PuntosCompletos => puntosCompletos;
        public int IndiceActual => indiceActual;
        public bool EstaEnProgreso => timer.Enabled;
        public bool EstaCompleto => puntosCompletos != null && indiceActual >= puntosCompletos.Count;
        public bool HayPuntos => puntosCompletos != null && puntosCompletos.Count > 0;
        public int TotalPuntos => puntosCompletos?.Count ?? 0;
        public int EstadoPaso => controlIniciado ? (puntosCompletos != null ? Math.Min(indiceActual, puntosCompletos.Count) : 0) : 0;

        private bool controlIniciado = false;

        public event Action ProgresoActualizado;

        public ControladorProgresivo()
        {
            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += (s, e) => AvanzarUnPaso();
        }

        public void IniciarProgresivo(List<Point> puntos)
        {
            puntosCompletos = puntos;
            indiceActual = 0;
            controlIniciado = true;
            timer.Start();
            ProgresoActualizado?.Invoke();
        }

        public void IniciarPasoAPaso(List<Point> puntos)
        {
            puntosCompletos = puntos;
            indiceActual = 0;
            controlIniciado = true;
            timer.Stop();
            ProgresoActualizado?.Invoke();
        }

        public void AvanzarUnPaso()
        {
            if (puntosCompletos == null) return;
            if (indiceActual < puntosCompletos.Count)
            {
                indiceActual++;
                ProgresoActualizado?.Invoke();
            }
            else
            {
                timer.Stop();
            }
        }

        public void MostrarTodo()
        {
            if (puntosCompletos != null)
                indiceActual = puntosCompletos.Count;
            timer.Stop();
            ProgresoActualizado?.Invoke();
        }

        public void Pausar()
        {
            timer.Stop();
        }

        public void Reanudar()
        {
            if (!EstaCompleto && puntosCompletos != null && controlIniciado)
                timer.Start();
        }

        public void Reiniciar()
        {
            indiceActual = 0;
            timer.Stop();
            ProgresoActualizado?.Invoke();
        }

        public void Limpiar()
        {
            puntosCompletos = null;
            indiceActual = 0;
            controlIniciado = false;
            timer.Stop();
            ProgresoActualizado?.Invoke();
        }

        public List<Point> ObtenerPuntosActuales()
        {
            if (puntosCompletos == null) return new List<Point>();
            return puntosCompletos.GetRange(0, Math.Min(indiceActual, puntosCompletos.Count));
        }
    }
}
