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
    class ReportsDAO
    {
        private static readonly ReportsDAO instance = new ReportsDAO();

        static ReportsDAO()
        {
        }

        private ReportsDAO()
        {
        }

        public static ReportsDAO Instance
        {
            get
            {
                return instance;
            }
        }

        public DataTable returnGoldSilverCustomers()
        {
            string readSQL = "SELECT c.Name, r.CostumerID, count(r.CostumerID) as RentsNumber " +
                             "FROM Reservations r " +
                             "INNER JOIN Customers c on r.CostumerID = c.CostumerID " +
                             "WHERE CONVERT(date, r.StartDate) >= CONVERT(date, GETDATE()-30) " +
                             "GROUP BY c.Name, r.CostumerID " +
                             "HAVING count(r.CostumerID) = 4 OR count(r.CostumerID) = 3";

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

        public DataTable returnRecentRents()
        {
            string readSQL = "SELECT CarPlate, CostumerID, StartDate, EndDate, Location, CouponCode " +
                             "FROM Reservations " +
                             "WHERE CONVERT(date, StartDate) >= CONVERT(date, GETDATE()-6) ";

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

        public DataTable returnRentedCars(DateTime startDate, DateTime endDate, string condition)
        {
            string readSQL = "";
            if(condition == "MOST")
            {
                readSQL = "SELECT TOP(5) c.Plate, c.Manufacturer, c.Model, c.PricePerDay, c.Location, count(r.CarPlate) as 'Number of Rents' " +
                          "FROM Reservations r " +
                          "INNER JOIN Cars c ON r.CarID = c.CarID " +
                          "WHERE CONVERT(date, r.StartDate) >= '" + startDate.Date + "' AND CONVERT(date, r.EndDate) <= '" + endDate.Date + "' " +
                          "GROUP BY c.Plate, c.Manufacturer, c.Model, c.PricePerDay, c.Location " +
                          "ORDER BY 'Number of Rents' ASC";
            } else
            {
                readSQL = "SELECT TOP(5) c.Plate, c.Manufacturer, c.Model, c.PricePerDay, c.Location, count(r.CarPlate) as 'Number of Rents' " +
                          "FROM Reservations r " +
                          "INNER JOIN Cars c ON r.CarID = c.CarID " +
                          "WHERE CONVERT(date, r.StartDate) >= '" + startDate.Date + "' AND CONVERT(date, r.EndDate) <= '" + endDate.Date + "' " +
                          "GROUP BY c.Plate, c.Manufacturer, c.Model, c.PricePerDay, c.Location " +
                          "ORDER BY 'Number of Rents' DESC";
            }
            
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
