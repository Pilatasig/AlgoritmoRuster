using PilatasigDavidBezier.Vista;
using System;
using System.Windows.Forms;

namespace PilatasigDavidBezier
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmBezier());
        }
    }
}
