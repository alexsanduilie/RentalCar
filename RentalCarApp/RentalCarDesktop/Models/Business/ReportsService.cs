using RentalCarDesktop.Models.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarDesktop.Models.Business
{
    class ReportsService
    {
        private ReportsDAO reportsDAO = ReportsDAO.Instance;
        private static readonly ReportsService instance = new ReportsService();
        static ReportsService()
        {
        }
        private ReportsService()
        {
        }
        public static ReportsService Instance
        {
            get
            {
                return instance;
            }
        }

        public DataTable returnGoldSilverCustomers()
        {
                return reportsDAO.returnGoldSilverCustomers();       
        }

        public DataTable returnRecentRents()
        {
            return reportsDAO.returnRecentRents();
        }

        public DataTable returnRentedCars(DateTime startDate, DateTime endDate, string condition)
        {
            return reportsDAO.returnRentedCars(startDate, endDate, condition);
        }

    }
}
