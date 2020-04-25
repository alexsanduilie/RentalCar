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
    class CarService
    {
        private static readonly CarService instance = new CarService();      
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

        private CarDAO carDAO;
        public int confirmID(string column, string paramValue)
        {
                return carDAO.confirmID(column, paramValue);
        }

        public int confirmOverallLocation(string column, string paramValue)
        {
                return carDAO.confirmOverallLocation(column, paramValue);
        }

        public DataTable readAllInDataTable()
        {
                return carDAO.readAllInDataTable();
        }

        public List<Car> readAll()
        {
            List<Car> cars = new List<Car>();
                cars = carDAO.readAll();
                return cars;
        }
    }
}
