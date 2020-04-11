using RentalCarDesktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCarDesktop
{
    public partial class List_Customers : Form
    {
        public List_Customers()
        {
            InitializeComponent();
        }

        private void List_Customers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'academy_netDataSet1.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.academy_netDataSet.Customers);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
