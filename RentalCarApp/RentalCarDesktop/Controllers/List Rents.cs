using RentalCarDesktop.Models.Business;
using RentalCarDesktop.Models.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCarDesktop
{
    public partial class List_Rents : Form
    {
        public List_Rents()
        {
            InitializeComponent();
        }

        ReservationService reservationService = ReservationService.Instance;

        private void List_Rents_Load(object sender, EventArgs e)
        {
            DataTable reservations = new DataTable();
            reservations = reservationService.readAllInDataTable();
            dataGridView1.DataSource = reservations;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*List<Reservation> reservations = new List<Reservation>();
            reservations = reservationService.readAll();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = reservations;*/

            DataTable reservations = new DataTable();
            reservations = reservationService.readAllInDataTable();
            dataGridView1.DataSource = reservations;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectReservTypeInDataTable(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectReservTypeInDataTable(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selectReservTypeInDataTable(3);
        }

        private void selectReservType(int reservID)
        {
            List<Reservation> reservations = new List<Reservation>();
            reservations = reservationService.readByStatus(reservID);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = reservations;
        }

        private void selectReservTypeInDataTable(int reservID)
        {
            DataTable reservations;
            reservations = reservationService.readAllInDataTableByStatus(reservID);
            dataGridView1.DataSource = reservations;
        }
    }
}
