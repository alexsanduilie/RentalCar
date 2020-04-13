﻿using RentalCarDesktop.Models.Business;
using RentalCarDesktop.Models.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCarDesktop.Models
{
    class ReservationValidationsService
    {
        private static readonly ReservationValidationsService instance = new ReservationValidationsService();
        static ReservationValidationsService()
        {
        }
        private ReservationValidationsService()
        {
        }
        public static ReservationValidationsService Instance
        {
            get
            {
                return instance;
            }
        }

        private static CarService carService = CarService.Instance;
        private static CustomerService customerService = CustomerService.Instance;
        private static ReservationService reservationService = ReservationService.Instance;
        private static CarDAO carDAO = CarDAO.Instance;

        public bool validateCarPlate(string carPlate, Label message)
        {
            bool plate = true;
            if (String.IsNullOrEmpty(carPlate))
            {
                message.Text = "Car Plate field can not be empty!";
                plate = false;
            }
            else
            {
                int carP = carService.confirmID("CarID", carPlate);
                if (carP == 0)
                {
                    if (!Regex.IsMatch(carPlate, "[A-Z]{1-2} [0-9]{1-2} [A-Z]{1-3}"))
                    {
                        message.Text = "Invalid input type, the car plate format should be: ZZ 00 ZZZ";
                        plate = false;
                    }
                    else
                    {
                        message.Text = "The requested car does not exist, please enter another car plate!";
                        plate = false;
                    }

                }
                else
                {
                    message.Text = "";
                }
            }
            return plate;
        }

        public bool validateClient(string clientID, Label message)
        {
            bool cl = true;
            if (String.IsNullOrEmpty(clientID))
            {
                message.Text = "Client field can not be empty!";
                cl = false;
            }
            else
            {
                int client = customerService.confirmID(clientID);
                if (client == 0)
                {
                    message.Text = "This client does not exist, please enter another client!";
                    cl = false;
                }
                else
                {
                    message.Text = "";
                }

            }
            return cl;
        }

        public bool validateCity(string loc, string plate, Label message)
        {
            bool client = true;
            if (String.IsNullOrEmpty(loc))
            {
                message.Text = "City field can not be empty!";
                client = false;
            }
            else
            {
                int city = carService.confirmID("Location", plate);
                string location = carDAO.location;
                if (city == 0 || !location.Equals(loc))
                {
                    message.Text = "The selected car is not available in this city!";
                    client = false;
                }
                else
                {
                    message.Text = "";
                }
            }
            return client;
        }

        public bool validateDate(DateTime startDate, DateTime endDate, Label message)
        {
            bool date = true;
            if (startDate > endDate)
            {
                message.Text = "End Date should be equal or higher than Start Date!";
                date = false;
            }
            else
            {
                message.Text = "";
            }
            return date;
        }

        public bool validateRentPeriod(string plate, Label message, DateTime presentStartDate, DateTime presentEndDate, string condition)
        {
            bool selectedDate = true;
            DateTime startDate;
            DateTime endDate;
            DataTable dt;

            dt = reservationService.readByPlate(plate);

            foreach (DataRow row in dt.Rows)
            {
                startDate = DateTime.Parse(row["StartDate"].ToString());
                endDate = DateTime.Parse(row["EndDate"].ToString());

                if (((presentStartDate <= endDate && presentEndDate >= startDate) && condition == "INSERT") || (((presentStartDate <= endDate && presentEndDate >= startDate) && (presentStartDate != startDate && presentEndDate != endDate)) && condition == "UPDATE"))
                {
                    selectedDate = false;
                    message.Text = "The selected car was already rented in this period!";
                    break;
                }
                else
                {
                    message.Text = "";
                }
            }
            return selectedDate;
        }
    }
}
