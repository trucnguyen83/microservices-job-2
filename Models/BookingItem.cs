using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Models
{
    public class BookingItem
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public string PickupPoint { get; set; }
        public string Destination { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}

