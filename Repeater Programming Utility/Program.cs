using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Repeater_Programming_Utility
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			if (Properties.Settings.Default.defaultForm == "SSH")
			{
				Application.Run(new FormSSH());
			}
            else
			{
				Application.Run(new Form1());
			}
        }
    }
}
