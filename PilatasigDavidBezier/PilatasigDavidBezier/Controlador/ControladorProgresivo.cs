using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PilatasigDavidBezier.Controlador
{
    public class ControladorProgresivo
    {
        private List<Point> _puntosCompletos;
        private List<Point> _puntosActuales;
        private int _indiceActual;
        private System.Windows.Forms.Timer _timer;
        private bool _modoProgresivo;

        public bool HayPuntos => _puntosCompletos != null && _puntosCompletos.Count > 0;
        public bool EstaCompleto => HayPuntos && _indiceActual >= _puntosCompletos.Count;
        public int Interval
        {
            get => _timer != null ? _timer.Interval : 0;
            set { if (_timer != null) _timer.Interval = value; }
        }

        public event Action ProgresoActualizado;

        public void IniciarProgresivo(List<Point> puntos)
        {
            _modoProgresivo = true;
            _puntosCompletos = new List<Point>(puntos);
            _puntosActuales = new List<Point>();
            _indiceActual = 0;

            if (_timer == null)
                _timer = new System.Windows.Forms.Timer { Interval = 50 };
            _timer.Tick += TimerTick;
            _timer.Start();
        }

        public void IniciarPasoAPaso(List<Point> puntos)
        {
            _modoProgresivo = false;
            _puntosCompletos = new List<Point>(puntos);
            _puntosActuales = new List<Point>();
            _indiceActual = 0;
            DetenerTimer();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (_indiceActual < _puntosCompletos.Count)
            {
                _puntosActuales.Add(_puntosCompletos[_indiceActual]);
                _indiceActual++;
                ProgresoActualizado?.Invoke();
            }
            else
                DetenerTimer();
        }

        public void AvanzarUnPaso()
        {
            if (!_modoProgresivo && _indiceActual < _puntosCompletos.Count)
            {
                _puntosActuales.Add(_puntosCompletos[_indiceActual]);
                _indiceActual++;
                ProgresoActualizado?.Invoke();
            }
        }

        public void MostrarTodo()
        {
            if (HayPuntos)
            {
                _puntosActuales = new List<Point>(_puntosCompletos);
                _indiceActual = _puntosCompletos.Count;
                DetenerTimer();
                ProgresoActualizado?.Invoke();
            }
        }

        public void Reanudar()
        {
            if (_modoProgresivo && HayPuntos && !EstaCompleto)
            {
                if (_timer == null)
                    _timer = new System.Windows.Forms.Timer { Interval = 50 };
                _timer.Start();
            }
        }

        public void Pausar()
        {
            DetenerTimer();
        }

        public void Limpiar()
        {
            DetenerTimer();
            _puntosCompletos = null;
            _puntosActuales = null;
            _indiceActual = 0;
        }

        public List<Point> ObtenerPuntosActuales()
        {
            return _puntosActuales != null ? new List<Point>(_puntosActuales) : new List<Point>();
        }

        private void DetenerTimer()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer.Tick -= TimerTick;
            }
        }
    }
}
