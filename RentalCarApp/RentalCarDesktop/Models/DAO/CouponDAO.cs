using RentalCarDesktop.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCarDesktop.Models.DAO
{
    class CouponDAO
    {
        private static readonly CouponDAO instance = new CouponDAO();

        static CouponDAO()
        {
        }

        private CouponDAO()
        {
        }

        public static CouponDAO Instance
        {
            get
            {
                return instance;
            }
        }

        private static string table_Name = "Coupons";

        public List<Coupon> readAll()
        {
            string readSQL = "SELECT * FROM " + table_Name;
            List<Coupon> coupons = new List<Coupon>();

            using (SqlCommand cmd = new SqlCommand(readSQL, Program.conn))
            {
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        coupons.Add(new Coupon(dr["CouponCode"].ToString(), dr["Description"].ToString(), Double.Parse(dr["Discount"].ToString())));
                    }

                    dr.Close();
                    cmd.Parameters.Clear();
                    cmd.Dispose();
                    return coupons;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("SQL error: " + ex.Message);
                    return coupons;
                }
            }

        }
    }
}
