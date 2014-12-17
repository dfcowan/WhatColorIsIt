using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WhatColorIsIt
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                string modeArgument = args[0].ToLower().Trim();
                string secondArgument = null;

                if (modeArgument.Length > 2)
                {
                    secondArgument = modeArgument.Substring(3).Trim();
                    modeArgument = modeArgument.Substring(0, 2);
                }
                else if (args.Length > 1)
                {
                    secondArgument = args[1];
                }

                if (modeArgument == "/c")
                {
                    Application.Exit();
                }
                else if (modeArgument == "/p")
                {
                    Application.Exit();
                }
                else if (modeArgument == "/s")
                {
                    ShowScreenSaver();
                    Application.Run();
                }
                else
                {
                    MessageBox.Show("Sorry, but the command line argument \"" + modeArgument +
                        "\" is not valid.", "WhatColorIsIt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                // TODO no arguments - treat like /c
            }
        }

        static void ShowScreenSaver()
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                WhatColorIsItForm screenSaver = new WhatColorIsItForm(screen.Bounds);
                screenSaver.Show();
            }
        }
    }
}
