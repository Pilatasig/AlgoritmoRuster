using AlgoritmoRuster.Controlador.ControladorRelleno;
using AlgoritmoRuster.Modelo;
using AlgoritmoRuster.Utils;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoRuster.Vista
{
    public partial class FrmComparacionRelleno : Form
    {
        private Canvas modelo;
        private ControladorCanvas controlador;
        private DibujadorPlano dibujadorPlano;
        private bool figuraDibujada = false;
        private bool esPrimerClic = true;
        private Point primerClic;
        private Point ultimoCentroFigura;

        private int pixelesInundacion;
        private int pixelesCola;
        private int pixelesScanLine;

        public FrmComparacionRelleno()
        {
            InitializeComponent();
            dibujadorPlano = new DibujadorPlano();
            configurarTabla();
        }

        private void configurarTabla()
        {
            dvgComparacion.Columns.Clear();
            dvgComparacion.Columns.Add("Algoritmo", "Algoritmo");
            dvgComparacion.Columns.Add("Pixeles", "Pixeles");
            dvgComparacion.Columns.Add("Tipo", "Tipo");
            dvgComparacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void rellenarTabla()
        {
            dvgComparacion.Rows.Clear();
            dvgComparacion.Rows.Add("Inundacion", pixelesInundacion, "Recursivo 4-vecinos");
            dvgComparacion.Rows.Add("Cola 8 vecinos", pixelesCola, "Cola 8 direcciones");
            dvgComparacion.Rows.Add("ScanLine", pixelesScanLine, "Scanline horizontal");
        }

        private void actualizarInfoAlgoritmo()
        {
            switch (cboAlgoritmo.SelectedItem?.ToString())
            {
                case "Inundacion":
                    lblAlgoritmoInfo.Text = "Recursivo con 4-vecinos (N,S,E,O)";
                    break;
                case "Cola":
                    lblAlgoritmoInfo.Text = "Cola con 8 direcciones, evita stack overflow";
                    break;
                case "ScanLine":
                    lblAlgoritmoInfo.Text = "Relleno horizontal optimizado con pila";
                    break;
                default:
                    lblAlgoritmoInfo.Text = "";
                    break;
            }
        }

        private async Task<int> contarPixeles(Point inicio, Bitmap referencia)
        {
            Canvas temp = new Canvas(referencia.Width, referencia.Height);
            using (Graphics gt = Graphics.FromImage(temp.bitmapCanvas))
                gt.DrawImage(referencia, 0, 0);

            var cola = new ControladorCola { DelayMs = 0 };
            await cola.rellenar(inicio, temp, null);

            int count = 0;
            for (int x = 0; x < referencia.Width; x++)
                for (int y = 0; y < referencia.Height; y++)
                    if (referencia.GetPixel(x, y) != temp.bitmapCanvas.GetPixel(x, y))
                        count++;

            return count;
        }

        private async void panelDibujo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (cboAlgoritmo.SelectedItem == null) return;

            string herramienta = modelo.herramientaSeleccionada;

            if (herramienta != "Balde")
            {
                if (esPrimerClic)
                {
                    primerClic = e.Location;
                    esPrimerClic = false;
                    lblInfoPuntos.Text = $"Primer clic: ({e.X},{e.Y}) — haga clic en el segundo punto";
                    return;
                }
                controlador.dibujarFigura(herramienta, primerClic, e.Location);
                ultimoCentroFigura = new Point(
                    (primerClic.X + e.Location.X) / 2,
                    (primerClic.Y + e.Location.Y) / 2);
                esPrimerClic = true;
                figuraDibujada = true;
                lblInfoPuntos.Text = $"Figura dibujada — seleccione algoritmo y haga clic dentro para rellenar";
                panelDibujo.Invalidate();
                return;
            }

            if (!figuraDibujada) return;

            await ejecutarRelleno(e.Location, animado: true);
        }

        private async Task ejecutarRelleno(Point punto, bool animado)
        {
            panelDibujo.Enabled = false;

            Bitmap shapeBmp = new Bitmap(modelo.bitmapCanvas);

            int total = await contarPixeles(punto, shapeBmp);
            pixelesInundacion = total;
            pixelesCola = total;
            pixelesScanLine = total;

            using (Graphics g = Graphics.FromImage(modelo.bitmapCanvas))
                g.DrawImage(shapeBmp, 0, 0);

            shapeBmp.Dispose();

            string seleccion = cboAlgoritmo.SelectedItem?.ToString();
            if (!animado && seleccion == "Inundacion")
                seleccion = "Cola";
            switch (seleccion)
            {
                case "Inundacion": controlador.controladorRelleno = new ControladorInundacion(); break;
                case "Cola": controlador.controladorRelleno = new ControladorCola(); break;
                case "ScanLine": controlador.controladorRelleno = new ControladorScanLine(); break;
            }
            controlador.DelayMs = animado ? 1 : 0;
            await controlador.aplicarRelleno(punto, animado ? panelDibujo : null);

            rellenarTabla();
            panelDibujo.Enabled = true;
            panelDibujo.Invalidate();
        }

        private async void btnRellenar_Click(object sender, EventArgs e)
        {
            if (!figuraDibujada) return;
            if (cboAlgoritmo.SelectedItem == null) return;
            await ejecutarRelleno(ultimoCentroFigura, animado: false);
        }

        private void panelDibujo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            dibujadorPlano.Dibujar(e.Graphics, panelDibujo.Width, panelDibujo.Height);
            if (controlador != null)
            {
                Bitmap bmp = controlador.getBitMap();
                using (var attr = new System.Drawing.Imaging.ImageAttributes())
                {
                    attr.SetColorKey(Color.White, Color.White);
                    e.Graphics.DrawImage(bmp,
                        new Rectangle(0, 0, bmp.Width, bmp.Height),
                        0, 0, bmp.Width, bmp.Height,
                        GraphicsUnit.Pixel, attr);
                }
            }
        }

        private void cboAlgoritmo_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarInfoAlgoritmo();
            if (cboAlgoritmo.SelectedItem == null || modelo == null) return;
            switch (cboAlgoritmo.SelectedItem.ToString())
            {
                case "Inundacion": modelo.herramientaSeleccionada = "Balde"; break;
                case "Cola": modelo.herramientaSeleccionada = "Balde"; break;
                case "ScanLine": modelo.herramientaSeleccionada = "Balde"; break;
            }
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            figuraDibujada = false;
            esPrimerClic = true;
            primerClic = Point.Empty;
            ultimoCentroFigura = Point.Empty;
            pixelesInundacion = 0;
            pixelesCola = 0;
            pixelesScanLine = 0;
            dvgComparacion.Rows.Clear();
            modelo = new Canvas(panelDibujo.Width, panelDibujo.Height);
            controlador = new ControladorCanvas(modelo);
            controlador.setHerramienta("Circulo");
            controlador.setColor(Color.Black);
            panelDibujo.Enabled = true;
            lblInfoPuntos.Text = "Seleccione herramienta, dibuje figura y haga clic dentro para comparar";
            lblAlgoritmoInfo.Text = "";
            panelDibujo.Invalidate();
        }

        private void btnCirculo_Click(object sender, EventArgs e)
        {
            controlador.setHerramienta("Circulo");
            resetearClics();
        }

        private void btnRectangulo_Click(object sender, EventArgs e)
        {
            controlador.setHerramienta("Rectangulo");
            resetearClics();
        }

        private void btnEstrella_Click(object sender, EventArgs e)
        {
            controlador.setHerramienta("Estrella");
            resetearClics();
        }

        private void resetearClics()
        {
            esPrimerClic = true;
            primerClic = Point.Empty;
            figuraDibujada = false;
        }

        private void FrmComparacionRelleno_Load(object sender, EventArgs e)
        {
            DisenoUI.AplicarTema(this);

            modelo = new Canvas(panelDibujo.Width, panelDibujo.Height);
            controlador = new ControladorCanvas(modelo);
            controlador.setHerramienta("Circulo");
            controlador.setColor(Color.Black);

            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, panelDibujo, new object[] { true });

            cboAlgoritmo.SelectedIndex = 0;
        }
    }
}
