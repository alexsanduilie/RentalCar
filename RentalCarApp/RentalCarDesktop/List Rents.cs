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
            // TODO: This line of code loads data into the 'academy_netDataSet.Reservations' table. You can move, or remove it, as needed.
            this.reservationsTableAdapter.Fill(this.academy_netDataSet.Reservations);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*List<Reservation> reservations = new List<Reservation>();
            reservations = reservationService.readAll();
            dataGridView1.DataSource = reservations;*/

            DataTable reservations = new DataTable();
            reservations = reservationService.readAllInDataTable();
            dataGridView1.DataSource = reservations;

            /*try
            {
                string sql = "SELECT * FROM Reservations;";
                SqlCommand cmd = new SqlCommand(sql, Program.conn);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable allRents = new DataTable();
                dataAdapter.Fill(allRents);
                dataGridView1.DataSource = allRents;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }*/

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //selectReservType(1);
            selectReservTypeInDataTable(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //selectReservType(2);
            selectReservTypeInDataTable(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //selectReservType(3);
            selectReservTypeInDataTable(3);
        }

        private void selectReservType(int reservID)
        {

            List<Reservation> reservations = new List<Reservation>();
            reservations = reservationService.readByStatus(reservID);
            dataGridView1.DataSource = reservations;

            /*try
            {
                string sql = "SELECT * FROM Reservations WHERE ReservStatsID = @reservID;";
                SqlCommand cmd = new SqlCommand(sql, Program.conn);
                cmd.Parameters.AddWithValue("@reservID", reservID);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable cancelledRents = new DataTable();
                dataAdapter.Fill(cancelledRents);
                dataGridView1.DataSource = cancelledRents;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void selectReservTypeInDataTable(int reservID)
        {
            DataTable reservations;
            reservations = reservationService.readAllInDataTableByStatus(reservID);
            dataGridView1.DataSource = reservations;
        }
    }
}
