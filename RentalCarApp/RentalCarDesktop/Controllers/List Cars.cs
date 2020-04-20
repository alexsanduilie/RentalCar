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

namespace RentalCarDesktop
{
    public partial class List_Cars : Form
    {
        public List_Cars()
        {
            InitializeComponent();
        }
        CarService carService = CarService.Instance;

        private void List_Cars_Load(object sender, EventArgs e)
        {
            ListCarsServiceReference.ListCarsServiceSoapClient listCarsServiceSoap = new ListCarsServiceReference.ListCarsServiceSoapClient();
            //The list of cars is returned by querying a web service
            /*DataTable cars = new DataTable();
            listCarsServiceSoap.Open();
            cars = listCarsServiceSoap.readAllInDataTable();
            dataGridView1.DataSource = cars;*/

            DataTable cars = new DataTable();
            cars = carService.readAllInDataTable();
            dataGridView1.DataSource = cars;

            /*List<Car> cars = new List<Car>();
            cars = carService.readAll();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = cars;*/

            // TODO: This line of code loads data into the 'academy_netDataSet.Cars' table. You can move, or remove it, as needed.
            //this.carsTableAdapter.Fill(this.academy_netDataSet.Cars);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
