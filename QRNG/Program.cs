using System;
using System.Windows.Forms;

namespace QaRaNuGe
{
    // ReSharper disable once UnusedMember.Global
    public static class Program
    {
        [STAThread]
        // ReSharper disable once ArrangeTypeMemberModifiers
        // ReSharper disable once UnusedMember.Local
        // ReSharper disable once UnusedMember.Global
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
