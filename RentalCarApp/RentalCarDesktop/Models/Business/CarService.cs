using RentalCarDesktop.Models.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCarDesktop.Models.Business
{
    class CarService
    {
        private static readonly CarService instance = new CarService();
        private CarDAO carDAO;
        static CarService()
        {
        }

        private CarService()
        {
            carDAO = CarDAO.Instance;
        }

        public static CarService Instance
        {
            get
            {
                return instance;
            }
        }

        public int confirmID(string column, string paramValue)
        {
            try
            {
                return carDAO.confirmID(column, paramValue);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error getting customer ID: " + ex.Message);
                return 0;
            }
        }
    }
}
