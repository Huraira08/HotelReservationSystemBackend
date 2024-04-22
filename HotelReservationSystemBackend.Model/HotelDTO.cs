using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemBackend.Model
{
    public class HotelDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int NoOfRooms { get; set; }
        public int RentPerDay { get; set; }
        public string[] ImagePaths { get; set; } = [];
    }
}
