using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarDesktop.Models.DTO
{
    class Coupon
    {
        public string couponCode { get; set; }
        public string description { get; set; }
        public double discount { get; set; }

        public Coupon(string couponCode, string description, double discount)
        {
            this.couponCode = couponCode;
            this.description = description;
            this.discount = discount;
        }

        public override string ToString()
        {
            return String.Format("Coupon Code:{0}, Description:{1}, Discount:{2}", couponCode, description, discount);
        }
    }
}
