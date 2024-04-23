using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelReservationSystemBackend.Model
{
    public class Hotel
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NoOfRooms { get; set; }
        public int RentPerDay { get; set; }
        public string[] ImagePaths { get; set; } = [];
    }
}
