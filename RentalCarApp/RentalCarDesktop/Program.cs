using RentalCarDesktop.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCarDesktop
{
    static class Program
    {
        public static SqlConnection conn;
       
        [STAThread]
        static void Main()
        {
            InitializeDb initializeDb = new InitializeDb();
            conn = initializeDb.getConnection();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WelcomeScreen());
        }
    }
}
