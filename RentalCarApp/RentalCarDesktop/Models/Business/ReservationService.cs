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
    class ReservationService
    {
        private static readonly ReservationService instance = new ReservationService();
        private ReservationDAO reservationDAO;
        static ReservationService()
        {
        }

        private ReservationService()
        {
            reservationDAO = ReservationDAO.Instance;
        }

        public static ReservationService Instance
        {
            get
            {
                return instance;
            }
        }

        public void create(Reservation reservation)
        {
            try
            {
                reservationDAO.create(reservation);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error inserting customer: " + ex.Message);
            }
        }

        public void update(Reservation reservation)
        {
            try
            {
                reservationDAO.update(reservation);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error inserting customer: " + ex.Message);
            }
        }

        public Reservation search(string plate, string customerID)
        {
            try
            {
                return reservationDAO.search(plate, customerID);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message);
                return null;
            }
        }

        public DataTable readByPlate(string plate)
        {
            try
            {
                return reservationDAO.readByPlate(plate);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error finding data: " + ex.Message);
                return null;
            }
        }
    }
}
