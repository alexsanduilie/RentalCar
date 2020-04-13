using RentalCarDesktop.Models;
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
        private static ReservationStatusesService reservationStatuses = ReservationStatusesService.Instance;
        private static CouponService couponService = CouponService.Instance;
        private static ReservationValidationsService reservationValidations = ReservationValidationsService.Instance;
        Reservation reservation;

        string carI = "";
        string rStatus = "";

        private void button1_Click(object sender, EventArgs e)
        {

            if (validateCarPlate() & validateClient() & validateCity() & validateDate() & validateRentPeriod())
            {
                rStatus = reservationStatuses.returnRStatus(listBox1);
                Reservation reservation = new Reservation(Int32.Parse(carI), textBox1.Text, Int32.Parse(textBox2.Text), Int32.Parse(rStatus), dateTimePicker1.Value, dateTimePicker2.Value, textBox5.Text, comboBox1.SelectedItem.ToString());
                reservationService.update(reservation);

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

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";

            reservation = reservationService.search(textBox1.Text, textBox2.Text);
            if (validateCarPlate() & validateClient())
            {
                carI = "";
                rStatus = "";
                

                if (reservation != null)
                {
                    carI = reservation.carID.ToString();
                    textBox1.Text = reservation.carPlate.ToString();
                    textBox2.Text = reservation.costumerID.ToString();
                    rStatus = reservationStatuses.returnRStatusAndSetListBoxItem(reservation, listBox1);
                    textBox5.Text = reservation.location.ToString();
                    dateTimePicker1.Value = DateTime.Parse(reservation.startDate.ToString());
                    dateTimePicker2.Value = DateTime.Parse(reservation.endDate.ToString());
                    comboBox1.SelectedItem = reservation.couponCode.ToString();
                    textBox1.ReadOnly = true;
                    textBox2.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("This car plate is not assocated with the client id, please enter another client or car plate");
                }
            }
            else
            {
                MessageBox.Show("For searching a Reservation, it is mandatory to enter the both Car Plate and Client ID");
            }

        }

        private bool validateCarPlate()
        {
            return reservationValidations.validateCarPlate(textBox1.Text, label7);
        }

        private bool validateClient()
        {
            return reservationValidations.validateClient(textBox2.Text, label8);
        }

        private bool validateCity()
        {
            return reservationValidations.validateCity(textBox5.Text, textBox1.Text, label10);
        }

        private bool validateDate()
        {
            return reservationValidations.validateDate(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, label9);
        }

        private bool validateRentPeriod()
        {
            return reservationValidations.validateRentPeriod(textBox1.Text, label9, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, "UPDATE");
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }

}
