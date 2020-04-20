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
            return reservationValidations.validateCarPlate(textBox1.Text, label6);
        }

        private bool validateCarModel()
        {
            return reservationValidations.validateClient(textBox2.Text, label7);
        }

        private bool validateCity()
        {
            return reservationValidations.validateCity(textBox5.Text, textBox1.Text, label9);
        }

        private bool validateDate()
        {
            return reservationValidations.validateDate(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, label8);
        }

        private bool validateRentPeriod()
        {
            return reservationValidations.validateRentPeriod(textBox1.Text, label8, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, "INSERT");
        }

        List<Car> cars;
        private void button1_Click(object sender, EventArgs e)
        {            
            cars = carValidations.searchCars(textBox1.Text, textBox2.Text, textBox5.Text, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = cars;
            dataGridView1.Show();
            label10.Text = "Available Cars based on selected criterias";
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
