using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemBackend.Model
{
    public class RequestAllocationDTO
    {
        public BookingRequest BookingRequest { get; set; }
        public Allocation? Allocation { get; set; }
    }
}
