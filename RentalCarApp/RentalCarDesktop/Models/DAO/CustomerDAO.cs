﻿using RentalCarDesktop.Models.DTO;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
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
        private static int searchCounter = 0;

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
                    MessageBox.Show("Customer created successfully");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message);
                }
                finally
                {
                    cmd.Parameters.Clear();
                    cmd.Dispose();
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
                    MessageBox.Show("Customer updated successfully");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message);
                }
                finally
                {
                    cmd.Parameters.Clear();
                    cmd.Dispose();
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
                SqlDataReader dr = null;
                try
                {
                    cmd.Parameters.AddWithValue("@CostumerID", customerID);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    dr = cmd.ExecuteReader();

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
                        searchCounter++;

                    }
                    message = string.Join(Environment.NewLine, cust);

                    if (counter == 1)
                    {
                        if (searchCounter == 1)
                        {
                            MessageBox.Show("Records retrieved successfully\n\n" + message);
                        }
                        return customer;
                    }
                    else if (counter > 1)
                    {
                        MessageBox.Show("Multimple Names found:\n\n" + message + "\n\n" + "Please enter the ONLY client ID for finalizing your search!");
                    }
                    return null;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message);
                    return null;
                }
                finally
                {
                    dr.Close();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }

        }

        public int getMaxID(string customerID)
        {
            string getID = "SELECT MAX(" + customerID + ") FROM " + table_Name + ";";
            int no = 0;
            using (SqlCommand cmd = new SqlCommand(getID, Program.conn))
            {
                SqlDataReader dr = null;
                try
                {
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        no = dr.GetInt32(no) + 1;
                    }
                    return no;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message);
                    return no;
                }
                finally
                {
                    dr.Close();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }

        }

        public int confirmID(string paramValue)
        {
            int no = 0;
            string getID = "SELECT CostumerID FROM " + table_Name + " WHERE CostumerID = @CustomerID;";

            using (SqlCommand cmd = new SqlCommand(getID, Program.conn))
            {
                SqlDataReader dr = null;
                try
                {
                    cmd.Parameters.AddWithValue("@CustomerID", paramValue);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        no = dr.GetInt32(no);
                    }
                    return no;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message);
                    return no;
                }
                finally
                {
                    dr.Close();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }

        }

        public List<Customer> readAll()
        {
            string readSQL = "SELECT * FROM " + table_Name;
            List<Customer> customers = new List<Customer>();

            using (SqlCommand cmd = new SqlCommand(readSQL, Program.conn))
            {
                SqlDataReader dr = null;
                try
                {
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        customers.Add(new Customer(Int32.Parse(dr["CostumerID"].ToString()), dr["Name"].ToString(), DateTime.Parse(dr["BirthDate"].ToString()), dr["Location"].ToString(), Int32.Parse(dr["ZIPCode"].ToString())));
                    }
                    return customers;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message);
                    return customers;
                }
                finally
                {
                    dr.Close();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }

        }

        public DataTable readAllInDataTable()
        {
            string readSQL = "SELECT * FROM " + table_Name;
            SqlDataAdapter dataAdapter;
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand(readSQL, Program.conn))
            {
                try
                {
                    dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                    return dt;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message);
                    return dt;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
        }

    }
}
