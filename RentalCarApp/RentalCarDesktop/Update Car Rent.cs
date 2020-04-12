using RentalCarDesktop.Models.Business;
using RentalCarDesktop.Models.DAO;
using RentalCarDesktop.Models.DTO;
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
        private static ReservationService reservationService = ReservationService.Instance;

        private static CarService carService = CarService.Instance;
        private static CustomerService customerService = CustomerService.Instance;
        private static CarDAO carDAO = CarDAO.Instance;
        private static CouponService couponService = CouponService.Instance;
        Reservation reservation;

/*        string plate = "";
        string costumerID = "";
        string startD = "";*/
        string carI = "";
        string rStatus = "";
/*        string endD = "";
        string location = "";*/
        string updateLocation = "";
/*        string coup = "";*/

        private void button1_Click(object sender, EventArgs e)
        {
            if (validateCarPlate() && validateClient() && validateCity() && validateDate() && validateRentPeriod())
            {
                if (listBox1.SelectedItem.Equals("OPEN"))
                {
                    rStatus = "1";
                }
                else if (listBox1.SelectedItem.Equals("CLOSED"))
                {
                    rStatus = "2";
                }
                else
                {
                    rStatus = "3";
                }

                Reservation reservation = new Reservation(Int32.Parse(carI), textBox1.Text, Int32.Parse(textBox2.Text), Int32.Parse(rStatus), dateTimePicker1.Value, dateTimePicker2.Value, textBox5.Text, comboBox1.SelectedItem.ToString());
                reservationService.update(reservation);

                /*string sql = "UPDATE Reservations SET ReservStatsID =  @reservStatsID, StartDate =  @startDate, EndDate =  @endDate, Location = @city, CouponCode = @couponCode WHERE CarPlate = @carPlate AND CostumerID = @clientID;";
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

                    MessageBox.Show("Record updated successfully!");*/

                foreach (TextBox tb in this.Controls.OfType<TextBox>().ToArray())
                {
                    tb.Clear();
                    tb.ReadOnly = false;
                }
                dateTimePicker1.ResetText();
                dateTimePicker2.ResetText();
                listBox1.SelectedIndex = 0;
                comboBox1.SelectedIndex = 0;
                /*}
                catch (SqlException ex)
            {
                MessageBox.Show("SQL error: " + ex.Message);
            }*/
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*            search();

                        void search()
                        {*/
            if (validateCarPlate() & validateClient())
            {
                /*plate = "";
                costumerID = "";
                startD = "";*/
                carI = "";
                rStatus = "";
                /*endD = "";
                location = "";
                coup = "";*/
                reservation = reservationService.search(textBox1.Text, textBox2.Text);

                /*try
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
                    dr.Close();*/
                carI = reservation.carID.ToString();
                textBox1.Text = reservation.carPlate.ToString();
                textBox2.Text = reservation.costumerID.ToString();
                if (reservation.reservStatsID == 1)
                {
                    rStatus = "1";
                    listBox1.SelectedItem = ReservationStatuses.OPEN.ToString();
                }
                else if (reservation.reservStatsID == 2)
                {
                    rStatus = "2";
                    listBox1.SelectedItem = ReservationStatuses.CLOSED.ToString();
                }
                else if (reservation.reservStatsID == 3)
                {
                    rStatus = "3";
                    listBox1.SelectedItem = ReservationStatuses.CANCELED.ToString();
                }

                textBox5.Text = reservation.location.ToString();
                dateTimePicker1.Value = DateTime.Parse(reservation.startDate.ToString());
                dateTimePicker2.Value = DateTime.Parse(reservation.endDate.ToString());
                comboBox1.SelectedItem = reservation.couponCode.ToString();

                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;

                /*}
                catch (Exception ex)
                {
                    MessageBox.Show("Error on searching existing records, this Car Plate is not associated with the entered Client ID");

                }*/
            }
            else
            {
                MessageBox.Show("For searching a Reservation, it is mandatory to enter the Car Plate and Client ID");
            }

            //}

        }

        /*private int getID(string col, string table, string param, string paramValue)
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
        }*/

        private bool validateCarPlate()
        {
            string carPlate = textBox1.Text;
            bool plate = true;

            if (String.IsNullOrEmpty(carPlate))
            {
                label7.Text = "Car Plate field can not be empty!";
                plate = false;
            }
            else
            {
                int carP = carService.confirmID("CarID", carPlate);
                //int carP = getID("CarID", "Cars", "Plate", text);
                if (carP == 0)
                {
                    if (!Regex.IsMatch(carPlate, "[A-Z]{1-2} [0-9]{1-2} [A-Z]{1-3}"))
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
            string clientID = textBox2.Text;
            bool cl = true;

            if (String.IsNullOrEmpty(clientID))
            {
                label8.Text = "Client field can not be empty!";
                cl = false;
            }
            else
            {
                int client = customerService.confirmID(clientID);
                //int client = getID("CostumerID", "Customers", "CostumerID", text);
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
            string loc = textBox5.Text;
            string plate = textBox1.Text;
            bool location = true;

            if (String.IsNullOrEmpty(loc))
            {
                label10.Text = "City field can not be empty!";
                location = false;
            }
            else
            {
                //int city = getID("Location", "Cars", "Plate", plate);
                int city = carService.confirmID("Location", plate);
                updateLocation = carDAO.location;
                if (city == 0 || !updateLocation.Equals(loc))
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
            DataTable dt;
            /*try
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
            }*/

            dt = reservationService.readByPlate(textBox1.Text);

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
            reservList.Add(ReservationStatuses.OPEN.ToString());
            reservList.Add(ReservationStatuses.CLOSED.ToString());
            reservList.Add(ReservationStatuses.CANCELED.ToString());
            listBox1.DataSource = reservList;

        }

        private void Update_Car_Rent_Load(object sender, EventArgs e)
        {
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            populateList();

            List<Coupon> coupons = new List<Coupon>();
            coupons = couponService.readAll();

            foreach (Coupon coupon in coupons)
            {
                comboBox1.Items.Add(coupon.couponCode);
            }
            comboBox1.SelectedIndex = 0;

            /*DataTable dt = new DataTable();
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
            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }

}
