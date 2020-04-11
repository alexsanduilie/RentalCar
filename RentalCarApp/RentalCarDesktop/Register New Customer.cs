using RentalCarDesktop.Models;
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

        private int getID(string col, string table)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                int no = 0;
                cmd = new SqlCommand("SELECT MAX(" + col + ") FROM " + table + ";", Program.conn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    no = dr.GetInt32(no) + 1;
                }
                dr.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                return no;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on generating ID.\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private bool validateClient()
        {
            string text = textBox2.Text;
            bool cl = true;

            if (String.IsNullOrEmpty(text))
            {
                label6.Text = "Client field can not be empty!";
                cl = false;
            }
            else
            {
                label6.Text = "";
            }
            return cl;
        }

        private bool validateLocation()
        {
            string text = textBox4.Text;
            bool city = true;

            if (String.IsNullOrEmpty(text))
            {
                label7.Text = "Location field can not be empty!";
                city = false;
            }
            else
            {
                label7.Text = "";
            }
            return city;
        }

        private bool validateZIP()
        {
            string text = textBox3.Text;
            bool zip = true;

            if (String.IsNullOrEmpty(text))
            {
                label8.Text = "ZIP Code can not be empty!";
                zip = false;
            } else if (!Regex.IsMatch(text, "[0-9]{5}") && !String.IsNullOrEmpty(text))
            {
                label8.Text = "Invalid input type, the zip code format should be a number of 5 digits: 00000";
                zip = false;
            }
            else
            {
                label8.Text = "";
            }
            return zip;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (validateClient() & validateLocation() & validateZIP())
            {
                string sql = "INSERT INTO Customers VALUES(@Name, @Date, @City, @ZIP);";
                try
                {
                    SqlCommand cmd;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();

                    cmd = new SqlCommand(sql, Program.conn);
                    cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@City", textBox4.Text);
                    cmd.Parameters.AddWithValue("@ZIP", textBox3.Text);

                    dataAdapter.InsertCommand = cmd;
                    dataAdapter.InsertCommand.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    MessageBox.Show("Customer created successfully");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message);
                }
                textBox1.Text = getID("CostumerID", "Customers").ToString();
            }

        }

        private void Register_New_Customer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'academy_netDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.academy_netDataSet.Customers);

            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            textBox1.Text = getID("CostumerID", "Customers").ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
