using System;
using System.Windows.Forms;

namespace EStudentPlatform
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin()); // Make sure this points to the login page!
        }
    }
}