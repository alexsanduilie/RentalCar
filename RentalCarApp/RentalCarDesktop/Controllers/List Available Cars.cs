using RentalCarDesktop.Models;
using RentalCarDesktop.Models.Business;
using RentalCarDesktop.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace RentalCarDesktop.Controllers
{
    public partial class List_Available_Cars : Form
    {
        private static ReservationValidationsService reservationValidations = ReservationValidationsService.Instance;
        CarValidationsService carValidations = CarValidationsService.Instance;

        public List_Available_Cars()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private bool validateCarPlate()
        {
            return carValidations.validateCarPlate(textBox1.Text, label6);
        }

        private bool validateCarModel()
        {
            return carValidations.validateCarModel(textBox2.Text, label7);
        }

        private bool validateCity()
        {
            return carValidations.validateCity(textBox5.Text, label9);
        }

        private bool validateDate()
        {
            return reservationValidations.validateDate(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, label8);
        }

        private bool validateRentPeriod()
        {
            Reservation r = null;
            return reservationValidations.validateRentPeriod(textBox1.Text, label8, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, "INSERT", r);
        }

        List<Car> cars;
        private void button1_Click(object sender, EventArgs e)
        {
            cars = null;
            if (textBox1.Text != "" && textBox2.Text == "" && textBox5.Text == "")
            {
                if (validateCarPlate() && validateRentPeriod() && validateDate())
                {
                    cars = carValidations.searchCars(textBox1.Text, textBox2.Text, textBox5.Text, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
                }
            }
            else if (textBox1.Text == "" && textBox2.Text != "" && textBox5.Text == "")
            {
                if (validateCarModel())
                {
                    cars = carValidations.searchCars(textBox1.Text, textBox2.Text, textBox5.Text, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
                }
            }
            else if (textBox1.Text == "" && textBox2.Text == "" && textBox5.Text != "")
            {
                if (validateCity())
                {
                    cars = carValidations.searchCars(textBox1.Text, textBox2.Text, textBox5.Text, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
                }
            }
            else if (textBox1.Text == "" && textBox2.Text == "" && textBox5.Text == "")
            {
                cars = carValidations.searchCars(textBox1.Text, textBox2.Text, textBox5.Text, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
            }
            else
            {
                MessageBox.Show(" Each search field is independent, and ONLY the Car Plate is linked to the Start/End Dates;\n" +
                            " You can search ONLY by a single criteria, or leave all criterias blank for returning all cars;\n");
                label6.Text = "";
                label7.Text = "";
                label8.Text = "";
                label9.Text = "";
            }

            if (cars != null)
            {
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = cars;
                dataGridView1.Show();
                label10.Text = "Available Cars based on selected criterias -> ONLY the Car Plate is linked to Start/End Dates";
                label6.Text = "";
                label7.Text = "";
                label8.Text = "";
                label9.Text = "";
            }          
        }
        
        private void List_Available_Cars_Load(object sender, EventArgs e)
        {                     
            if(cars == null)
            {
                label10.Text = "All Cars";
                this.carsTableAdapter.Fill(this.academy_netDataSet.Cars);
            }
            
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";

        }
    }
}
