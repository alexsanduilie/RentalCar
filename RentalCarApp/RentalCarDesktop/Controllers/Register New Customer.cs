using RentalCarDesktop.Models;
using RentalCarDesktop.Models.Business;
using RentalCarDesktop.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCarDesktop
{
    public partial class Register_New_Customer : Form
    {
        public Register_New_Customer()
        {
            InitializeComponent();
        }
        private static CustomerService customerService = CustomerService.Instance;
        private static CustomerValidationsService customerValidations = CustomerValidationsService.Instance;

        private bool validateClient()
        {
            return customerValidations.validateClient(textBox2.Text, label6);
        }

        private bool validateLocation()
        {
            return customerValidations.validateClient(textBox4.Text, label7);
        }

        private bool validateZIP()
        {
            return customerValidations.validateZIP(textBox3.Text, label8);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validateClient() & validateLocation() & validateZIP())
            {
                Customer customer = new Customer(textBox2.Text, dateTimePicker1.Value, textBox4.Text, Int32.Parse(textBox3.Text));
                customerService.create(customer);
                textBox1.Text = customerService.getMaxID("CostumerID").ToString();
            }
        }

        private void Register_New_Customer_Load(object sender, EventArgs e)
        {
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            textBox1.Text = customerService.getMaxID("CostumerID").ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
