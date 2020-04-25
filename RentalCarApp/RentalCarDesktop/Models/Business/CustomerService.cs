using RentalCarDesktop.Models.DAO;
using RentalCarDesktop.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCarDesktop.Models.Business
{
    class CustomerService
    {
        private static readonly CustomerService instance = new CustomerService();
        private CustomerDAO customerDAO;
        static CustomerService()
        {
        }
        private CustomerService()
        {
            customerDAO = CustomerDAO.Instance;
        }
        public static CustomerService Instance
        {
            get
            {
                return instance;
            }
        }

        public void create(Customer customer)
        {
            customerDAO.create(customer);
        }

        public void update(Customer customer)
        {
            customerDAO.update(customer);
        }

        public Customer search(string customerID, string Name)
        {
            return customerDAO.search(customerID, Name);
        }

        public int getMaxID(string customerID)
        {
            return customerDAO.getMaxID(customerID);
        }

        public int confirmID(string paramValue)
        {
            return customerDAO.confirmID(paramValue);
        }

        public List<Customer> readAll()
        {
            List<Customer> customers = new List<Customer>();
            customers = customerDAO.readAll();
            return customers;
        }

        public DataTable readAllInDataTable()
        {
            return customerDAO.readAllInDataTable();
        }
    }
}
