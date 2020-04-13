using RentalCarDesktop.Models;
using RentalCarDesktop.Models.Business;
using RentalCarDesktop.Models.DAO;
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
    public partial class Register_New_Car_Rent : Form
    {
        public Register_New_Car_Rent()
        {
            InitializeComponent();
        }
        private static ReservationService reservationService = ReservationService.Instance;
        private static ReservationValidationsService reservationValidations = ReservationValidationsService.Instance;
        private static CarService carService = CarService.Instance;
        private static CouponService couponService = CouponService.Instance;

        private bool validateCarPlate()
        {
            return reservationValidations.validateCarPlate(textBox1.Text, label6) == true;

        }

        private bool validateClient()
        {
            return reservationValidations.validateClient(textBox2.Text, label7);
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
            return reservationValidations.validateRentPeriod(textBox1.Text, label9, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, "INSERT");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (validateCarPlate() & validateClient() & validateCity() & validateDate() & validateRentPeriod())
            {
                int carID = carService.confirmID("CarID", textBox1.Text);
                Reservation reservation = new Reservation(carID, textBox1.Text, Int32.Parse(textBox2.Text), 1, dateTimePicker1.Value, dateTimePicker2.Value, textBox5.Text, comboBox1.SelectedItem.ToString());
                reservationService.create(reservation);
            }
        }

        private void Register_New_Car_Rent_Load(object sender, EventArgs e)
        {

            label6.Text = "";
            label7.Text = "";
            label9.Text = "";
            label10.Text = "";

            List<Coupon> coupons = new List<Coupon>();
            coupons = couponService.readAll();

            foreach (Coupon coupon in coupons)
            {
                comboBox1.Items.Add(coupon.couponCode);
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }

}
