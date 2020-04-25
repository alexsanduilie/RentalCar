using RentalCarDesktop.Models.Business;
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
    public partial class Report_Customers : Form
    {
        public Report_Customers()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        ReportsService reportsService = ReportsService.Instance;
        private BindingSource bindingSource1 = new BindingSource();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {            
        }

        private void Report_Customers_Load(object sender, EventArgs e)
        {
            DataTable data;
            data = reportsService.returnGoldSilverCustomers();
            bindingSource1.DataSource = data;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bindingSource1;
        }
    }
}
