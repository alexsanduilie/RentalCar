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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCarDesktop
{
    public partial class Update_Customer : Form
    {
        public Update_Customer()
        {
            InitializeComponent();
        }

        private static CustomerService customerService = CustomerService.Instance;
        private static CustomerValidationsService customerValidations = CustomerValidationsService.Instance;
        Customer customer;

        string costumerID = "";
        string name = "";
        string birthDate = "";
        string location = "";
        string zipCode = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.ReadOnly == true)
            {
                if (validateClientID() & validateClientName() & validateLocation() & validateZIP()){
                    Customer customer = new Customer(Int32.Parse(textBox1.Text), textBox2.Text, dateTimePicker1.Value, textBox4.Text, Int32.Parse(textBox3.Text));
                    customerService.update(customer);
                    foreach (TextBox tb in this.Controls.OfType<TextBox>().ToArray())
                    {
                        tb.Clear();
                        tb.ReadOnly = false;
                    }
                    dateTimePicker1.ResetText();
                }
            } else
            {
                MessageBox.Show("You can update the rent only after you validate the search");
            }
        }

        private void search()
        {
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";

            if((textBox1.ReadOnly == true))
            {
                textBox2.Text = "";     
            }
            if((textBox1.Text != "" && textBox2.Text == ""))
            {
                if (validateClientID())
                {
                    customer = customerService.search(textBox1.Text, textBox2.Text);
                }
                
            } else if((textBox1.Text == "" && textBox2.Text != ""))
            {
                if (validateClientName())
                {    
                    customer = customerService.search(textBox1.Text, textBox2.Text);
                }
                
            } else if((textBox1.Text != "" && textBox2.Text != "")){
                if(validateClientID() && validateClientName())
                {
                    customer = customerService.search(textBox1.Text, textBox2.Text);
                }
                
            }
            
            if (customer != null)
            {
                try
                {
                    costumerID = customer.customerID.ToString();
                    name = customer.name.ToString();
                    birthDate = customer.birthDate.ToString();
                    zipCode = customer.zipCode.ToString();
                    location = customer.location.ToString();
                    textBox1.Text = costumerID;
                    textBox2.Text = name;
                    textBox4.Text = location;
                    textBox3.Text = zipCode;
                    dateTimePicker1.Value = DateTime.Parse(birthDate);
                    textBox1.ReadOnly = true;
                    //button2.Enabled = false;
                } catch (Exception ex)
                {
                    MessageBox.Show("SQL error:" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("You can search a customer either by it's ID, or Name");
            }
        }

        private bool validateClientID()
        {
            return customerValidations.validateClientID(textBox1.Text, label6, customer);
        }

        private bool validateClientName()
        {
            return customerValidations.validateClientName(textBox2.Text, label7, customer);
        }

        private bool validateLocation()
        {
            return customerValidations.validateLocation(textBox4.Text, label8);
        }

        private bool validateZIP()
        {
            return customerValidations.validateZIP(textBox3.Text, label9);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            search();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Update_Customer_Load(object sender, EventArgs e)
        {
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
        }
    }
}
