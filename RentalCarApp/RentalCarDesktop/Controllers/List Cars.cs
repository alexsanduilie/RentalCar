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
            //ListCarsServiceReference.ListCarsServiceSoapClient listCarsServiceSoap = new ListCarsServiceReference.ListCarsServiceSoapClient();
            //The list of cars is returned by querying a web service -> this will work only if the web service is running, because it is built into another solution
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
