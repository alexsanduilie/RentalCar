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

        List<Car> cars;
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Each search field is independent and only the Car Plate and the City are linked to the Start/End Dates;" +
                            " For example if you enter a Car Plate which is in a certain city, a Model which is found in another city, and a different City where we have 10 cars, All records based on your searches will be returned;" +
                            " If you leave all text boxes blank, All Cars available in the Selected Period will be returned; " +
                            " If you enter the Car Plate and Car Model and a certain Period, those 2 cars will be validated against the selected period -" +
                            " if the car plate matches the model, than one car will be returned if the period will be valid.");
            if(validateCarPlate() & validateCarModel() & validateCity() & validateDate())
            {
                cars = carValidations.searchCars(textBox1.Text, textBox2.Text, textBox5.Text, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = cars;
                dataGridView1.Show();
                label10.Text = "Available Cars based on selected criterias";
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
