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
        Customer customer;

        string costumerID = "";
        string name = "";
        string birthDate = "";
        string location = "";
        string zipCode = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if(validateClientID() & validateClientUpdate() & validateLocation() & validateZIP())
            {

                Customer customer = new Customer(Int32.Parse(textBox1.Text), textBox2.Text, dateTimePicker1.Value, textBox4.Text, Int32.Parse(textBox3.Text));
                customerService.update(customer);
                /*try
                {
                    string sql = "UPDATE Customers SET Name = @Name, BirthDate = @Date, Location = @City, ZIPCode = @ZIP WHERE CostumerID = @ID;";
                    SqlCommand cmd;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();

                    cmd = new SqlCommand(sql, Program.conn);
                    cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@City", textBox4.Text);
                    cmd.Parameters.AddWithValue("@ZIP", textBox3.Text);

                    dataAdapter.UpdateCommand = cmd;
                    dataAdapter.UpdateCommand.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Dispose();

                    MessageBox.Show("Record updated successfully!");

                    foreach (TextBox tb in this.Controls.OfType<TextBox>().ToArray())
                    {
                        tb.Clear();
                        tb.ReadOnly = false;
                    }
                    dateTimePicker1.ResetText();
                    button2.Enabled = true;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message);
                }*/
            }
  
        }

        private void search()
        {
            costumerID = "";
            name = "";
            birthDate = "";
            location = "";
            zipCode = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";

            customer = customerService.search(textBox1.Text, textBox2.Text);

            if (((textBox1.Text != "" && textBox2.Text == "") && validateClientID()) || ((textBox1.Text == "" && textBox2.Text != "") && validateClientName()))
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
                    button2.Enabled = false;

                } catch (Exception ex)
                {
                    MessageBox.Show("SQL error:" + ex.Message);
                }
                
                /*try
                {

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE CostumerID = @CostumerID OR Name = @Name;", Program.conn);
                    cmd.Parameters.AddWithValue("@CostumerID", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        costumerID = dr["CostumerID"].ToString();
                        name = dr["Name"].ToString();
                        birthDate = dr["BirthDate"].ToString();
                        location = dr["Location"].ToString();
                        zipCode = dr["ZIPCode"].ToString();

                    }
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    dr.Close();*/

                    /*textBox1.Text = costumerID;
                    textBox2.Text = name;
                    textBox4.Text = location;
                    textBox3.Text = zipCode;
                    dateTimePicker1.Value = DateTime.Parse(birthDate);

                    textBox1.ReadOnly = true;
                    button2.Enabled = false;*/
               /* }
                catch (Exception ex)
                {
                    MessageBox.Show("Please enter the full name for finalizing your search!");

                }*/
            }
            else
            {
                MessageBox.Show("You can search a client either by it's client ID or Name");
            }

        }

        private bool validateClientID()
        {
            string ID = textBox1.Text;
            bool cl = true;

            if (String.IsNullOrEmpty(ID))
            {
                label6.Text = "Client ID can not be empty!";
                cl = false;
            }
            else
            {
                if (customer == null)
                {
                    label6.Text = "This client does not exist, please enter another client!";
                    cl = false;
                }
                else
                {
                    label6.Text = "";
                }

            }
            return cl;
        }

        private bool validateClientName()
        {
            string clientName = textBox2.Text;
            bool cl = true;

            if (String.IsNullOrEmpty(clientName))
            {
                label7.Text = "Client Name can not be empty!";
                cl = false;
            }
            else
            {
                if (customer == null)
                {
                    label7.Text = "This client name couldn't be found, please enter another client!";
                    cl = false;
                }
                else
                {
                    label7.Text = "";
                }

            }
            return cl;
        }

        private bool validateClientUpdate()
        {
            string clientName = textBox2.Text;
            bool cl = true;

            if (String.IsNullOrEmpty(clientName))
            {
                label7.Text = "Client Name can not be empty!";
                cl = false;
            } else
            {
                label7.Text = "";
            }
            return cl;
        }

        private bool validateLocation()
        {
            string text = textBox4.Text;
            bool city = true;

            if (String.IsNullOrEmpty(text))
            {
                label8.Text = "Location field can not be empty!";
                city = false;
            }
            else
            {
                label8.Text = "";
            }
            return city;
        }

        private bool validateZIP()
        {
            string text = textBox3.Text;
            bool zip = true;

            if (String.IsNullOrEmpty(text))
            {
                label9.Text = "ZIP Code can not be empty!";
                zip = false;
            }
            else if (!Regex.IsMatch(text, "[0-9]{5}") && !String.IsNullOrEmpty(text))
            {
                label9.Text = "Invalid input type, the zip code format should be a number of 5 digits: 00000";
                zip = false;
            }
            else
            {
                label9.Text = "";
            }
            return zip;
        }

/*        private int getRecords(string col, string table, string param, string paramValue)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                int no = 0;
                if (col == "CostumerID")
                {
                    cmd = new SqlCommand("SELECT " + col + " FROM " + table + " WHERE " + param + "=" + paramValue + ";", Program.conn);
                }
                else
                {
                    cmd = new SqlCommand("SELECT " + col + " FROM " + table + " WHERE " + param + " LIKE '%" + paramValue + "%';", Program.conn);
                }
                cmd.Parameters.AddWithValue(param, paramValue);
                SqlDataReader dr = cmd.ExecuteReader();

                List<String> names = new List<String>();
                while (dr.Read())
                {
                    int counter = 0;
                    if (col == "Name")
                    {
                        no = 1;                        
                        names.Add(dr["Name"].ToString());
                        counter++;

                        if (counter > 1)
                        {
                            no = 0;
                        }
                    }
                    else
                    {
                        no = dr.GetInt32(no);
                    }

                }
                if(col == "Name")
                {
                    var message = string.Join(Environment.NewLine, names);
                    MessageBox.Show("Names found:\n" + message);
                }
                
                dr.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                return no;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input format for " + col + "\n", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }*/

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
