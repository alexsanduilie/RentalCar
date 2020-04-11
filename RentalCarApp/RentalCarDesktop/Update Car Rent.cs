using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCarDesktop
{
    public partial class Update_Car_Rent : Form
    {
        public Update_Car_Rent()
        {
            InitializeComponent();
        }

        string plate = "";
        string costumerID = "";
        string startD = "";
        string carI = "";
        string rStatus = "";
        string endD = "";
        string location = "";
        string updateLocation = "";
        string coup = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if (validateCarPlate() && validateClient() && validateCity() && validateDate() && validateRentPeriod())
            {
                
                string sql = "UPDATE Reservations SET ReservStatsID =  @reservStatsID, StartDate =  @startDate, EndDate =  @endDate, Location = @city, CouponCode = @couponCode WHERE CarPlate = @carPlate AND CostumerID = @clientID;";
                try
                {
                    SqlCommand cmd;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();

                    cmd = new SqlCommand(sql, Program.conn);
                    cmd.Parameters.AddWithValue("@carID", carI);
                    cmd.Parameters.AddWithValue("@carPlate", plate);
                    cmd.Parameters.AddWithValue("@clientID", costumerID);
                    if(listBox1.SelectedItem.Equals("OPEN"))
                    {
                        rStatus = "1";
                    } else if (listBox1.SelectedItem.Equals("CLOSED"))
                    {
                        rStatus = "2";
                    } else
                    {
                        rStatus = "3";
                    }

                    cmd.Parameters.AddWithValue("@reservStatsID", rStatus);
                    cmd.Parameters.AddWithValue("@startDate", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@endDate", dateTimePicker2.Value);
                    cmd.Parameters.AddWithValue("@city", textBox5.Text);
                    cmd.Parameters.AddWithValue("@couponCode", comboBox1.SelectedItem);

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
                    dateTimePicker2.ResetText();
                    listBox1.SelectedIndex = 0;
                    comboBox1.SelectedIndex = 0;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            search();

            void search()
            {
                if (validateCarPlate() & validateClient())
                {
                    plate = "";
                    costumerID = "";
                    startD = "";
                    carI = "";
                    rStatus = "";
                    endD = "";
                    location = "";
                    coup = "";
                    try
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Reservations WHERE CarPlate = @plate AND CostumerID = @CostumerID;", Program.conn);
                        cmd.Parameters.AddWithValue("@plate", textBox1.Text);
                        cmd.Parameters.AddWithValue("@CostumerID", textBox2.Text);
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            plate = dr["CarPlate"].ToString();
                            costumerID = dr["CostumerID"].ToString();
                            startD = dr["StartDate"].ToString();
                            carI = dr["CarID"].ToString();
                            rStatus = dr["ReservStatsID"].ToString();
                            endD = dr["EndDate"].ToString();
                            location = dr["Location"].ToString();
                            coup = dr["CouponCode"].ToString();

                        }
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        dr.Close();

                        textBox1.Text = plate;
                        textBox2.Text = costumerID;
                        if(rStatus == "1")
                        {
                            listBox1.SelectedItem = "OPEN";
                        } else if(rStatus == "2")
                        {
                            listBox1.SelectedItem = "CLOSED";
                        } else if(rStatus == "3")
                        {
                            listBox1.SelectedItem = "CANCELED";
                        }

                        textBox5.Text = location;
                        dateTimePicker1.Value = DateTime.Parse(startD);
                        dateTimePicker2.Value = DateTime.Parse(endD);
                        comboBox1.SelectedItem = coup;

                        textBox1.ReadOnly = true;
                        textBox2.ReadOnly = true;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error on searching existing records, this Car Plate is not associated with the entered Client ID");

                    }
                }
                else
                {
                    MessageBox.Show("For searching a Reservation, it is mandatory to enter the Car Plate and Client ID");
                }

            }

        }

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
                        updateLocation = dr["Location"].ToString();
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
                MessageBox.Show("Invalid input format for\n", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        private bool validateCarPlate()
        {
            string text = textBox1.Text;
            bool plate = true;

            if (String.IsNullOrEmpty(text))
            {
                label7.Text = "Car Plate field can not be empty!";
                plate = false;
            }
            else
            {
                int carP = getID("CarID", "Cars", "Plate", text);
                if (carP == 0)
                {
                    if (!Regex.IsMatch(text, "[A-Z]{1-2} [0-9]{1-2} [A-Z]{1-3}"))
                    {
                        label7.Text = "Invalid input type, the car plate format should be: ZZ 00 ZZZ";
                        plate = false;
                    }
                    else
                    {
                        label7.Text = "The requested car does not exist, please enter another car plate!";
                        plate = false;
                    }

                }
                else
                {
                    label7.Text = "";
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
                label8.Text = "Client field can not be empty!";
                cl = false;
            }
            else
            {
                int client = getID("CostumerID", "Customers", "CostumerID", text);
                if (client == 0)
                {
                    label8.Text = "This client does not exist, please enter another client!";
                    cl = false;
                }
                else
                {
                    label8.Text = "";
                }

            }
            return cl;
        }

        private bool validateCity()
        {
            string text = textBox5.Text;
            string plate = textBox1.Text;
            bool location = true;

            if (String.IsNullOrEmpty(text))
            {
                label10.Text = "City field can not be empty!";
                location = false;
            }
            else
            {
                int city = getID("Location", "Cars", "Plate", plate);
                if (city == 0 || !updateLocation.Equals(textBox5.Text))
                {
                    label10.Text = "The selected car is not available in this city!";
                    location = false;
                }
                else
                {
                    label10.Text = "";
                }

            }
            return location;
        }

        private bool validateDate()
        {
            bool date = true;

            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                label9.Text = "End Date should be equal or bigger than Start Date!";
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

                if ((dateTimePicker1.Value.Date <= endDate && dateTimePicker2.Value.Date >= startDate) && (dateTimePicker1.Value != startDate && dateTimePicker2.Value != endDate))
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

        private void populateList()
        {
            List<string> reservList = new List<string>();
            reservList.Add("OPEN");
            reservList.Add("CLOSED");
            reservList.Add("CANCELED");
            listBox1.DataSource = reservList;
        }

        private void Update_Car_Rent_Load(object sender, EventArgs e)
        {
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            populateList();

            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT CouponCode FROM Coupons";
                SqlCommand cmd = new SqlCommand(sql, Program.conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBox1.Items.Add(dt.Rows[i]["CouponCode"]);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }

}
