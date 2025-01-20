using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project3
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainMenue());
            Application.Run(new Logins());
            //Application.Run(new AddProducts());
            //Application.Run(new ViewProducts());
            //Application.Run(new AddSuppliers());
            //Application.Run(new AddCustomers());
            //Application.Run(new Billing());
        }
    }
}
