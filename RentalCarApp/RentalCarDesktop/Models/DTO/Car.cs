﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCarDesktop.Models.DTO
{
    class Car
    {
        public int carID { get; set; }
        public string plate { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public double price { get; set; }
        public string location { get; set; }

        public Car(int carID, string plate, string manufacturer, string model, double price, string location)
        {
            this.carID = carID;
            this.plate = plate;
            this.manufacturer = manufacturer;
            this.model = model;
            this.price = price;
            this.location = location;
        }
        //method built for testing purposes, just in case we want to build a Car model without assigning the ID
        public Car(string plate, string manufacturer, string model, double price, string location)
        {
            this.carID = -1;
            this.plate = plate;
            this.manufacturer = manufacturer;
            this.model = model;
            this.price = price;
            this.location = location;
        }
        public Car() { }

        public override string ToString()
        {
            return String.Format("Car ID:{0}, Car Plate:{1}, Manufacturare:{2}, Model:{3}, Price:{4}, Location:{5}", carID, plate, manufacturer, model, price, location);
        }
    }
}
