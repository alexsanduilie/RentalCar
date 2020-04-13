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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register_New_Car_Rent registerRent = new Register_New_Car_Rent();
            registerRent.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                List_Customers customers = new List_Customers();
                customers.Show();

            } catch (SqlException ex)
            {
                MessageBox.Show("SQL error: " + ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Update_Customer update_Customer = new Update_Customer();
            update_Customer.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Register_New_Customer new_Customer = new Register_New_Customer();
            new_Customer.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update_Car_Rent update_Car = new Update_Car_Rent();
            update_Car.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List_Cars list_Cars = new List_Cars();
            list_Cars.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List_Rents list_Rents = new List_Rents();
            list_Rents.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
