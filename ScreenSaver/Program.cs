using System;
using System.Windows.Forms;

namespace ScreenSaver
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
                if (args[0].ToLower().Trim().Substring(0, 2) == "/p") //preview
                {
                    //show the screen saver preview
                    //args[1] is the handle to the preview window
                    Application.Run(new MainForm(new IntPtr(long.Parse(args[1]))));
                }
                else if (args[0].ToLower().Trim().Substring(0, 2) == "/c") //configure
                {
                    new OptionsForm().ShowDialog();
                    //Application.Run();
                }
                else //if (args[0].ToLower().Trim().Substring(0, 2) == "/s") //show
                {
                    Application.Run(new MainForm(Screen.PrimaryScreen.Bounds));
                }
            }
            else
                Application.Run(new MainForm(Screen.PrimaryScreen.Bounds));
        }

    }
}
