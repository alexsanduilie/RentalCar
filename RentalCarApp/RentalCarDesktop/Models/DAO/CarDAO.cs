using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCarDesktop.Models.DAO
{
    class CarDAO
    {
            private static readonly CarDAO instance = new CarDAO();

            static CarDAO()
            {
            }

            private CarDAO()
            {
            }

            public static CarDAO Instance
            {
                get
                {
                    return instance;
                }
            }

            private static string table_Name = "Cars";
            public string location = "";

        public int confirmID(string column, string paramValue)
        {
            int no = 0;
            string getID = "SELECT " + column + " FROM " + table_Name + " WHERE Plate = @Plate;";

            using (SqlCommand cmd = new SqlCommand(getID, Program.conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@Plate", paramValue);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (column == "Location")
                        {
                            no = 1;
                            location = dr["Location"].ToString();
                        }
                        else
                        {
                            no = dr.GetInt32(no);
                        }
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
