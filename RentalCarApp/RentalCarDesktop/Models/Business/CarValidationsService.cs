﻿using RentalCarDesktop.Models.DAO;
using RentalCarDesktop.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCarDesktop.Models.Business
{
    class CarValidationsService
    {
        private static readonly CarValidationsService instance = new CarValidationsService();
        static CarValidationsService()
        {
        }
        private CarValidationsService()
        {
        }
        public static CarValidationsService Instance
        {
            get
            {
                return instance;
            }
        }

        private static CarDAO carDAO = CarDAO.Instance;
        private static CarService carService = CarService.Instance;
        private static CustomerService customerService = CustomerService.Instance;
        public List<Car> searchCars(string plate, string model, string city, DateTime presentStartDate, DateTime presentEndDate)
        {
                return carDAO.searchCars(plate, model, city, presentStartDate, presentEndDate);
        }

        public bool validateCarPlate(string carPlate, Label message)
        {
            bool plate = true;
            if (!String.IsNullOrEmpty(carPlate))
            {
                int carP = carService.confirmID("CarID", carPlate);
                if (carP == 0)
                {
                    if (!Regex.IsMatch(carPlate, "[A-Z]{2} [0-9]{2} [A-Z]{3}"))
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
            }
            return plate;
        }

        public bool validateCarModel(string carModel, Label message)
        {
            bool cl = true;
            if (!String.IsNullOrEmpty(carModel))
            {
                int model = carService.confirmID("Model", carModel);
                if (model == 0)
                {
                    message.Text = "This model does not exist, please enter another model!";
                    cl = false;
                }
            }
            return cl;
        }

        public bool validateCity(string city, Label message)
        {
            bool cl = true;
            if (!String.IsNullOrEmpty(city))
            {
                int location = carService.confirmOverallLocation("Location", city);
                if (location == 0)
                {
                    message.Text = "This location does not exist, please enter another location!";
                    cl = false;
                }
            }
            return cl;
        }

    }
}
