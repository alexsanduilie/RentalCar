using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarDesktop.Models.DTO
{
    class Customer
    {
        public int customerID { get; set; }
        public string name { get; set;  }
        public DateTime birthDate { get; set; }
        public string location { get; set; }
        public int zipCode { get; set; }

        public Customer(int customerID, string name, DateTime birthDate, string location, int zipCode)
        {
            this.customerID = customerID;
            this.name = name;
            this.birthDate = birthDate;
            this.location = location;
            this.zipCode = zipCode;
        }

        public Customer(string name, DateTime birthDate, string location, int zipCode)
        {
            this.customerID = -1;
            this.name = name;
            this.birthDate = birthDate;
            this.location = location;
            this.zipCode = zipCode;

        }

        public Customer() { }

        public override string ToString()
        {
            return String.Format("Customer ID:{0}, Name:{1}, BirthDate:{2}, Location:{3}, ZIP Code:{4}", customerID, name, birthDate, location, zipCode);
        }
    }
}
