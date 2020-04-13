using RentalCarDesktop.Models;
using RentalCarDesktop.Models.Business;
using RentalCarDesktop.Models.DTO;
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
        CustomerService customerService = CustomerService.Instance;

        private void List_Customers_Load(object sender, EventArgs e)
        {
            /*List<Customer> customers = new List<Customer>();
            customers = customerService.readAll();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = customers;*/

            DataTable customers = new DataTable();
            customers = customerService.readAllInDataTable();
            dataGridView1.DataSource = customers;

            // TODO: This line of code loads data into the 'academy_netDataSet1.Customers' table. You can move, or remove it, as needed.
            //this.customersTableAdapter.Fill(this.academy_netDataSet.Customers);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
