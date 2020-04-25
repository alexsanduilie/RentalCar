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
            reservationDAO.create(reservation);
        }

        public void update(Reservation reservation)
        {
            reservationDAO.update(reservation);
        }

        public Reservation search(string plate, string customerID)
        {
            return reservationDAO.search(plate, customerID);
        }

        public DataTable readByPlate(string plate)
        {
            return reservationDAO.readByPlate(plate);
        }

        public List<Reservation> readAll()
        {
            List<Reservation> reservations = new List<Reservation>();
            reservations = reservationDAO.readAll();
            return reservations;
        }

        public DataTable readAllInDataTable()
        {
            return reservationDAO.readAllInDataTable();
        }
        public DataTable readAllInDataTableByStatus(int status)
        {
            return reservationDAO.readAllInDataTableByStatus(status);
        }

        public List<Reservation> readByStatus(int status)
        {
            List<Reservation> reservations = new List<Reservation>();
            reservations = reservationDAO.readByStatus(status);
            return reservations;
        }
    }
}
