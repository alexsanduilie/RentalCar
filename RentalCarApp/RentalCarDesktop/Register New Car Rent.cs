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
    public partial class Register_New_Car_Rent : Form
    {
        public Register_New_Car_Rent()
        {
            InitializeComponent();
        }

        string location = "";
        private int getID(string col, string table, string param, string paramValue)
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
                    cmd = new SqlCommand("SELECT " + col + " FROM " + table + " WHERE " + param + "='" + paramValue + "';", Program.conn);
                }
                cmd.Parameters.AddWithValue(param, paramValue);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if (col == "Location")
                    {
                        no = 1;
                        location = dr["Location"].ToString();
                    }
                    else
                    {
                        no = dr.GetInt32(no);
                    }

                }
                dr.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                return no;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input format for " + ex.Message + "\n", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private bool validateCarPlate()
        {
            string text = textBox1.Text;

            bool plate = true;

            if (String.IsNullOrEmpty(text))
            {
                label6.Text = "Car Plate field can not be empty!";
                plate = false;
            }
            else
            {
                int carP = getID("CarID", "Cars", "Plate", text);
                if (carP == 0)
                {
                    if (!Regex.IsMatch(text, "[A-Z]{1-2} [0-9]{1-2} [A-Z]{1-3}"))
                    {
                        label6.Text = "Invalid input type, the car plate format should be: ZZ 00 ZZZ";
                        plate = false;
                    }
                    else
                    {
                        label6.Text = "The requested car does not exist, please enter another car plate!";
                        plate = false;
                    }

                }
                else
                {
                    label6.Text = "";
                }

            }
            return plate;
        }

        private bool validateClient()
        {
            string text = textBox2.Text;

            bool cl = true;

            if (String.IsNullOrEmpty(text))
            {
                label7.Text = "Client field can not be empty!";
                cl = false;
            }
            else
            {
                int client = getID("CostumerID", "Customers", "CostumerID", text);
                if (client == 0)
                {
                    label7.Text = "This client does not exist, please enter another client!";
                    cl = false;
                }
                else
                {
                    label7.Text = "";
                }

            }
            return cl;
        }

        private bool validateCity()
        {
            string text = textBox5.Text;
            string plate = textBox1.Text;

            bool cl = true;

            if (String.IsNullOrEmpty(text))
            {
                label10.Text = "City field can not be empty!";
                cl = false;
            }
            else
            {
                int city = getID("Location", "Cars", "Plate", plate);
                if (city == 0 || !location.Equals(textBox5.Text))
                {
                    label10.Text = "The selected car is not available in this city!";
                    cl = false;
                }
                else
                {
                    label10.Text = "";
                }

            }
            return cl;
        }

        private bool validateDate()
        {
            bool date = true;

            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                label9.Text = "End Date should be equal or higher than Start Date!";
                date = false;
            }
            else
            {
                label9.Text = "";
            }
            return date;
        }

        private bool validateRentPeriod()
        {
            bool selectedDate = true;
            DateTime startDate;
            DateTime endDate;
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM Reservations WHERE CarPlate = @plate;";
                SqlCommand cmd = new SqlCommand(sql, Program.conn);
                cmd.Parameters.AddWithValue("@plate", textBox1.Text);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            foreach (DataRow row in dt.Rows)
            {
                startDate = DateTime.Parse(row["StartDate"].ToString());
                endDate = DateTime.Parse(row["EndDate"].ToString());

                if ((dateTimePicker1.Value.Date <= endDate && dateTimePicker2.Value.Date >= startDate))
                {
                    selectedDate = false;
                    label9.Text = "The selected car was already rented in this period!";
                    break;
                }
                else
                {
                    label9.Text = "";
                }
            }
            return selectedDate;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (validateCarPlate() && validateClient() && validateCity() && validateDate() && validateRentPeriod())
            {
                string sql = "INSERT INTO Reservations VALUES(@carID, @carPlate, @clientID, @reservStatsID, @startDate, @endDate, @city, @couponCode);";
                try
                {
                    SqlCommand cmd;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();

                    cmd = new SqlCommand(sql, Program.conn);
                    cmd.Parameters.AddWithValue("@carID", getID("CarID", "Cars", "Plate", textBox1.Text));
                    cmd.Parameters.AddWithValue("@carPlate", textBox1.Text);
                    cmd.Parameters.AddWithValue("@clientID", textBox2.Text);
                    cmd.Parameters.AddWithValue("@reservStatsID", 1);
                    cmd.Parameters.AddWithValue("@startDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@endDate", dateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@city", textBox5.Text);
                    cmd.Parameters.AddWithValue("@couponCode", comboBox1.SelectedItem);

                    dataAdapter.InsertCommand = cmd;
                    dataAdapter.InsertCommand.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Dispose();

                    MessageBox.Show("Record registered succeffully!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message);
                }
            }
        }

        private void Register_New_Car_Rent_Load(object sender, EventArgs e)
        {
            label6.Text = "";
            label7.Text = "";
            label9.Text = "";
            label10.Text = "";

            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT CouponCode FROM Coupons";
                SqlCommand cmd = new SqlCommand(sql, Program.conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);

                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBox1.Items.Add(dt.Rows[i]["CouponCode"]);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }

}
