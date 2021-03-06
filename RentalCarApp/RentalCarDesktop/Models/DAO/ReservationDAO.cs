﻿using RentalCarDesktop.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCarDesktop.Models.DAO
{
    class ReservationDAO
    {
        private static readonly ReservationDAO instance = new ReservationDAO();
        static ReservationDAO()
        {
        }
        private ReservationDAO()
        {
        }
        public static ReservationDAO Instance
        {
            get
            {
                return instance;
            }
        }

        private static string table_Name = "Reservations";

        public void create(Reservation reservation)
        {
            string insertSQL = "INSERT INTO " + table_Name + " VALUES(@carID, @carPlate, @clientID, @reservStatsID, @startDate, @endDate, @city, @couponCode);";
            SqlDataAdapter dataAdapter = new SqlDataAdapter();

            using (SqlCommand cmd = new SqlCommand(insertSQL, Program.conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@carID", reservation.carID);
                    cmd.Parameters.AddWithValue("@carPlate", reservation.carPlate);
                    cmd.Parameters.AddWithValue("@clientID", reservation.costumerID);
                    cmd.Parameters.AddWithValue("@reservStatsID", reservation.reservStatsID);
                    cmd.Parameters.AddWithValue("@startDate", reservation.startDate);
                    cmd.Parameters.AddWithValue("@endDate", reservation.endDate);
                    cmd.Parameters.AddWithValue("@city", reservation.location);
                    cmd.Parameters.AddWithValue("@couponCode", reservation.couponCode);

                    dataAdapter.InsertCommand = cmd;
                    dataAdapter.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Reservation created successfully");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message + "\n You can not register the same Car Plate and Client Id");
                }
                finally
                {
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
        }

        public void update(Reservation reservation)
        {
            string updateSQL = "UPDATE " + table_Name + " SET ReservStatsID =  @reservStatsID, StartDate =  @startDate, EndDate =  @endDate, Location = @city, CouponCode = @couponCode WHERE CarPlate = @carPlate AND CostumerID = @clientID;";
            SqlDataAdapter dataAdapter = new SqlDataAdapter();

            using (SqlCommand cmd = new SqlCommand(updateSQL, Program.conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@carID", reservation.carID);
                    cmd.Parameters.AddWithValue("@carPlate", reservation.carPlate);
                    cmd.Parameters.AddWithValue("@clientID", reservation.costumerID);
                    cmd.Parameters.AddWithValue("@reservStatsID", reservation.reservStatsID);
                    cmd.Parameters.AddWithValue("@startDate", reservation.startDate);
                    cmd.Parameters.AddWithValue("@endDate", reservation.endDate);
                    cmd.Parameters.AddWithValue("@city", reservation.location);
                    cmd.Parameters.AddWithValue("@couponCode", reservation.couponCode);

                    dataAdapter.UpdateCommand = cmd;
                    dataAdapter.UpdateCommand.ExecuteNonQuery();
                    MessageBox.Show("Reservation updated successfully");
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

        public Reservation search(string plate, string customerID)
        {
            string searchSQL;
            int counter = 0;
            Reservation reservation = null;

            if (plate != "" && customerID != "")
            {
                searchSQL = "SELECT * FROM Reservations WHERE CarPlate = @plate AND CostumerID = @CostumerID;";
            }
            else
            {
                searchSQL = "SELECT * FROM Reservations WHERE CarPlate = @plate OR CostumerID = @CostumerID;";
            }

            using (SqlCommand cmd = new SqlCommand(searchSQL, Program.conn))
            {
                SqlDataReader dr = null;
                try
                {
                    cmd.Parameters.AddWithValue("@plate", plate);
                    cmd.Parameters.AddWithValue("@CostumerID", customerID);
                    dr = cmd.ExecuteReader();

                    List<Reservation> reserv = new List<Reservation>();
                    var message = "";
                    while (dr.Read())
                    {
                        reservation = new Reservation();
                        reservation.carPlate = dr["CarPlate"].ToString();
                        reservation.costumerID = Int32.Parse(dr["CostumerID"].ToString());
                        reservation.startDate = DateTime.Parse(dr["StartDate"].ToString());
                        reservation.carID = Int32.Parse(dr["CarID"].ToString());
                        reservation.reservStatsID = Int32.Parse(dr["ReservStatsID"].ToString());
                        reservation.endDate = DateTime.Parse(dr["EndDate"].ToString());
                        reservation.location = dr["Location"].ToString();
                        reservation.couponCode = dr["CouponCode"].ToString();

                        reserv.Add(reservation);
                        counter++;
                    }
                    message = string.Join(Environment.NewLine, reserv);
                    if (counter == 1)
                    {
                        MessageBox.Show("Rent retrieved successfully:" + reservation);
                        return reservation;
                    }
                    else if (counter > 1)
                    {
                        MessageBox.Show("Multiple Entries found:\n\n" + message + "\n\n" + "Please enter the Car Plate - Client ID association for finalizing the search!");
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

        public List<Reservation> readAll()
        {
            string readSQL = "SELECT * FROM " + table_Name;
            List<Reservation> reservation = new List<Reservation>();

            using (SqlCommand cmd = new SqlCommand(readSQL, Program.conn))
            {
                SqlDataReader dr = null;
                try
                {
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        reservation.Add(new Reservation(Int32.Parse(dr["CarID"].ToString()), dr["CarPlate"].ToString(), Int32.Parse(dr["CostumerID"].ToString()), Int32.Parse(dr["ReservStatsID"].ToString()), DateTime.Parse(dr["StartDate"].ToString()), DateTime.Parse(dr["EndDate"].ToString()), dr["Location"].ToString(), dr["CouponCode"].ToString()));
                    }
                    return reservation;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message);
                    return reservation;
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

        public DataTable readAllInDataTableByStatus(int status)
        {
            string readSQL = "SELECT * FROM " + table_Name + " WHERE ReservStatsID = @reservID;";
            SqlDataAdapter dataAdapter;
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand(readSQL, Program.conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@reservID", status);
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

        public List<Reservation> readByStatus(int status)
        {
            string readSQL = "SELECT * FROM " + table_Name + " WHERE ReservStatsID = @reservID;";
            List<Reservation> reservation = new List<Reservation>();

            using (SqlCommand cmd = new SqlCommand(readSQL, Program.conn))
            {
                SqlDataReader dr = null;
                try
                {
                    cmd.Parameters.AddWithValue("@reservID", status);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        reservation.Add(new Reservation(Int32.Parse(dr["CarID"].ToString()), dr["CarPlate"].ToString(), Int32.Parse(dr["CostumerID"].ToString()), Int32.Parse(dr["ReservStatsID"].ToString()), DateTime.Parse(dr["StartDate"].ToString()), DateTime.Parse(dr["EndDate"].ToString()), dr["Location"].ToString(), dr["CouponCode"].ToString()));
                    }                    
                    return reservation;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message);
                    return reservation;
                }
                finally
                {
                    dr.Close();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                }
            }
        }

        public DataTable readByPlate(string plate)
        {
            string readSQL = "SELECT * FROM Reservations WHERE CarPlate = @plate;";
            SqlDataAdapter dataAdapter;
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand(readSQL, Program.conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@plate", plate);
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
