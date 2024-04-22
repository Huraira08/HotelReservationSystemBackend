using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelReservationSystemBackend.Model
{
    public class BookingRequestDTO
    {
        public string Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int TotalRent { get; set; }
        public BookingStatus BookingStatus { get; set; }

        public Guid HotelId { get; set; }
        [JsonIgnore]
        public Hotel? Hotel { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}
