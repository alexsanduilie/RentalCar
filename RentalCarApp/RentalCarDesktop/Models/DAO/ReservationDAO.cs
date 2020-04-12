using RentalCarDesktop.Models.DTO;
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

                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    MessageBox.Show("Reservation created successfully");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message);
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

                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    MessageBox.Show("Reservation updated successfully");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message);
                }
            }

        }

        public Reservation search(string plate, string customerID)
        {
            string searchSQL;
            int counter = 0;
            Reservation reservation = null;

            searchSQL = "SELECT * FROM Reservations WHERE CarPlate = @plate AND CostumerID = @CostumerID;";

            using (SqlCommand cmd = new SqlCommand(searchSQL, Program.conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@plate", plate);
                    cmd.Parameters.AddWithValue("@CostumerID", customerID);
                    SqlDataReader dr = cmd.ExecuteReader();

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
                        counter++;
                    }

                    if (counter == 1)
                    {
                        MessageBox.Show("Rent retrieved successfully:" + reservation);
                        dr.Close();
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        return reservation;
                    }
                    else
                    {
                        dr.Close();
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        return null;
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message);
                    return null;
                }
            }

        }

        public DataTable readByPlate(string plate)
        {
            string insertSQL = "SELECT * FROM Reservations WHERE CarPlate = @plate;";
            SqlDataAdapter dataAdapter;
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand(insertSQL, Program.conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@plate", plate);
                    dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);

                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    return dt;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message);
                    return dt;
                }
            }

        }

    }
}
