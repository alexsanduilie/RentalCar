using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCarDesktop.Controllers
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Report_Customers report_Customers = new Report_Customers();
            report_Customers.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Report_Recent_Rents report_Recent = new Report_Recent_Rents();
            report_Recent.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Report_Cars report_Cars = new Report_Cars();
            report_Cars.Show();
        }
    }
}
