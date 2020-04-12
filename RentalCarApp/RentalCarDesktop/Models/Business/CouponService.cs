using RentalCarDesktop.Models.DAO;
using RentalCarDesktop.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCarDesktop.Models.Business
{
    class CouponService
    {
        private static readonly CouponService instance = new CouponService();
        private CouponDAO couponDAO;
        static CouponService()
        {
        }

        private CouponService()
        {
            couponDAO = CouponDAO.Instance;
        }

        public static CouponService Instance
        {
            get
            {
                return instance;
            }
        }

        public List<Coupon> readAll()
        {
            List<Coupon> coupons = new List<Coupon>();
            try
            {
                coupons = couponDAO.readAll();
                return coupons;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error getting records: " + ex.Message);
                return coupons;
            }
        }
    }
}
