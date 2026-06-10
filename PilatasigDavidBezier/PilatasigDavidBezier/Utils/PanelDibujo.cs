using System.Windows.Forms;

namespace PilatasigDavidBezier.Utils
{
    internal class PanelDibujo : Panel
    {
        public PanelDibujo()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }
    }
}
