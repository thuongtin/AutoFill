using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace AutoFill
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AutoFill());
        }
    }
}
