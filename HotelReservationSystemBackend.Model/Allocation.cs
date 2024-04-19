using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemBackend.Model
{
    public class Allocation
    {
        public Guid Id { get; set; }
        public int RoomNo { get; set; }
        public Guid BookingRequestId { get; set; }
        public BookingRequest BookingRequest { get; set; }
    }
}
