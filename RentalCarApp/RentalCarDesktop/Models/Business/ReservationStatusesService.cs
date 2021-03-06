﻿using RentalCarDesktop.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalCarDesktop.Models.Business
{
    class ReservationStatusesService
    {
        private static readonly ReservationStatusesService instance = new ReservationStatusesService();
        static ReservationStatusesService()
        {
        }
        private ReservationStatusesService()
        {
        }
        public static ReservationStatusesService Instance
        {
            get
            {
                return instance;
            }
        }

        public string returnRStatus(ListBox listBox)
        {
            string rStatus = "";
            if (listBox.SelectedItem.Equals(ReservationStatuses.OPEN.ToString()))
            {
                rStatus = "1";
            }
            else if (listBox.SelectedItem.Equals(ReservationStatuses.CLOSED.ToString()))
            {
                rStatus = "2";
            }
            else if (listBox.SelectedItem.Equals(ReservationStatuses.CANCELED.ToString()))
            {
                rStatus = "3";
            }
            return rStatus;
        }

        public string returnRStatusAndSetListBoxItem(Reservation reservation, ListBox listBox)
        {
            string rStatus = "";
            if (reservation.reservStatsID == 1)
            {
                rStatus = "1";
                listBox.SelectedItem = ReservationStatuses.OPEN.ToString();
            }
            else if (reservation.reservStatsID == 2)
            {
                rStatus = "2";
                listBox.SelectedItem = ReservationStatuses.CLOSED.ToString();
            }
            else if (reservation.reservStatsID == 3)
            {
                rStatus = "3";
                listBox.SelectedItem = ReservationStatuses.CANCELED.ToString();
            }
            return rStatus;
        }
    }
}
