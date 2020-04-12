using RentalCarDesktop.Models.DTO;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCarDesktop.Models.DAO
{
    class CustomerDAO
    {
        private static readonly CustomerDAO instance = new CustomerDAO();

        static CustomerDAO()
        {
        }

        private CustomerDAO()
        {
        }

        public static CustomerDAO Instance
        {
            get
            {
                return instance;
            }
        }

        private static string table_Name = "Customers";

        public void create(Customer customer)
        {
            string insertSQL = "INSERT INTO " + table_Name + " VALUES(@Name, @Date, @City, @ZIP);";
            SqlDataAdapter dataAdapter = new SqlDataAdapter();

            using (SqlCommand cmd = new SqlCommand(insertSQL, Program.conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@Name", customer.name);
                    cmd.Parameters.AddWithValue("@Date", customer.birthDate);
                    cmd.Parameters.AddWithValue("@City", customer.location);
                    cmd.Parameters.AddWithValue("@ZIP", customer.zipCode);

                    dataAdapter.InsertCommand = cmd;
                    dataAdapter.InsertCommand.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    MessageBox.Show("Customer created successfully");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message);
                }
            }

        }

        public void update(Customer customer)
        {
            string updateSQL = "UPDATE Customers SET Name = @Name, BirthDate = @Date, Location = @City, ZIPCode = @ZIP WHERE CostumerID = @ID;";
            SqlDataAdapter dataAdapter = new SqlDataAdapter();

            using (SqlCommand cmd = new SqlCommand(updateSQL, Program.conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@ID", customer.customerID);
                    cmd.Parameters.AddWithValue("@Name", customer.name);
                    cmd.Parameters.AddWithValue("@Date", customer.birthDate);
                    cmd.Parameters.AddWithValue("@City", customer.location);
                    cmd.Parameters.AddWithValue("@ZIP", customer.zipCode);

                    dataAdapter.UpdateCommand = cmd;
                    dataAdapter.UpdateCommand.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    MessageBox.Show("Customer updated successfully");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message);
                }
            }

        }

        public Customer search(string customerID, string Name)
        {
            string searchSQL;
            Customer customer = null;
            
            if (Name == "")
            {
                searchSQL = "SELECT * FROM Customers WHERE CostumerID = @CostumerID;";
            }
            else
            {
                searchSQL = "SELECT * FROM Customers WHERE CostumerID = @CostumerID OR Name LIKE '%" + Name + "%';";
            }

            using (SqlCommand cmd = new SqlCommand(searchSQL, Program.conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@CostumerID", customerID);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    SqlDataReader dr = cmd.ExecuteReader();

                    List<Customer> cust = new List<Customer>();
                    int counter = 0;
                    var message = "";
                    while (dr.Read())
                    {
                        customer = new Customer();
                        customer.customerID = Int32.Parse(dr["CostumerID"].ToString());
                        customer.name = dr["Name"].ToString();
                        customer.birthDate = DateTime.Parse(dr["BirthDate"].ToString());
                        customer.location = dr["Location"].ToString();
                        customer.zipCode = Int32.Parse(dr["ZIPCode"].ToString());

                        cust.Add(customer);
                        counter++;

                    }
                    message = string.Join(Environment.NewLine, cust);
                    MessageBox.Show("Names found:\n\n" + message);
                    if (counter == 1)
                    {

                        MessageBox.Show("Records retreived successfully");
                        dr.Close();
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        return customer;

                    }
                    else
                    {
                        MessageBox.Show("Please enter the full name for finalizing your search!");
                    }

                    dr.Close();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    return null;

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message);
                    return null;
                }
            }

        }

        public int getMaxID(string customerID)
        {
            string getID = "SELECT MAX(" + customerID + ") FROM " + table_Name + ";";
            int no = 0;
            using (SqlCommand cmd = new SqlCommand(getID, Program.conn))
            {
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        no = dr.GetInt32(no) + 1;
                    }
                    dr.Close();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    return no;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message);
                    return no;
                }
            }

        }

        public int confirmID(string paramValue)
        {
            int no = 0;
            string getID = "SELECT CostumerID FROM " + table_Name + " WHERE CostumerID = @CustomerID;";

            using (SqlCommand cmd = new SqlCommand(getID, Program.conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@CustomerID", paramValue);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        no = dr.GetInt32(no);
                    }
                    dr.Close();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    return no;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message);
                    return no;
                }
            }

        }

    }
}
