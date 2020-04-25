using RentalCarDesktop.Models;
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
    public partial class Report_Cars : Form
    {
        public Report_Cars()
        {
            InitializeComponent();
        }

        ReportsService reportsService = ReportsService.Instance;
        ReservationValidationsService reservationValidations = ReservationValidationsService.Instance;
        private BindingSource bindingSource1 = new BindingSource();
        private void Report_Cars_Load(object sender, EventArgs e)
        {
            label2.Text = "";
            List<string> conditions = new List<string>();
            conditions.Add("MOST");
            conditions.Add("LESS");
            foreach (string c in conditions)
            {
                comboBox1.Items.Add(c);
            }
            comboBox1.SelectedIndex = 0;           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable data = null;
            if (validateDate())
            {
                data = reportsService.returnRentedCars(dateTimePicker1.Value, dateTimePicker2.Value, comboBox1.Text);
            }

            bindingSource1.DataSource = data;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = bindingSource1;
        }

        private bool validateDate()
        {
            return reservationValidations.validateDate(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, label2);
        }
    }
}
