using AlgoritmoRuster.Modelo;
using AlgoritmoRuster.Modelo.Figuras;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoRuster.Controlador.ControladorRelleno
{
    internal class ControladorCanvas
    {
        private Canvas modelo;
        public IControladorRelleno controladorRelleno{ get; set; }

        private readonly Dictionary<String, IFigura> figurasDisponibles;

        public ControladorCanvas(Canvas modelo)
        {
            this.modelo = modelo;
            controladorRelleno = new ControladorInundacion();

            figurasDisponibles = new Dictionary<string, IFigura> {
                { "Circulo", new Circulo()},
                { "Rectangulo", new Rectangulo()},
                { "Estrella", new Estrella()}
            };
        }

        public void setHerramienta(String herramienta) => modelo.herramientaSeleccionada = herramienta;
        public void setColor(Color color) => modelo.currentColor = color;
        public Bitmap getBitMap() => modelo.bitmapCanvas;

        public void dibujarFigura(string nombreFigura, Point inicio, Point fin)
        {
            if (figurasDisponibles.TryGetValue(nombreFigura, out IFigura figura))
            {
                using (Graphics g = Graphics.FromImage(modelo.bitmapCanvas))
                using (Pen pen = new Pen(modelo.currentColor, 2))
                {
                    figura.dibujarFigura(g, pen, inicio, fin);
                }
            }
        }

        public int DelayMs
        {
            get => controladorRelleno?.DelayMs ?? 1;
            set { if (controladorRelleno != null) controladorRelleno.DelayMs = value; }
        }

        public async Task aplicarRelleno(Point inicio, Panel panel)
        {
            if (controladorRelleno != null)
                await controladorRelleno.rellenar(inicio, modelo, panel);
        }
    }
}
