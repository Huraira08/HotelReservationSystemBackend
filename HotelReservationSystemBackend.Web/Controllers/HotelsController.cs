using HotelReservationSystemBackend.Business.HotelManager;
using HotelReservationSystemBackend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HotelReservationSystemBackend.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelManager _hotelsManager;
        public HotelsController(IHotelManager hotelManager)
        {
            _hotelsManager = hotelManager;
        }

        [HttpGet]
        public async Task<List<Hotel>> Get()
        {
            List<Hotel> hotels = await _hotelsManager.GetAsync();
            return hotels;
        }

        [HttpGet("{id}")]
        public async Task<Hotel?> Get(Guid id)
        {
            Hotel? hotel = await _hotelsManager.GetAsync(id);
            return hotel;
        }

        [HttpGet("freeRooms/{hotelId}/{bookingId}")]
        public async Task<List<int>> GetFreeRooms(Guid hotelId, Guid bookingId)
        {
            if (hotelId == Guid.Empty || bookingId == Guid.Empty) return [];
            List<int> freeRooms = await _hotelsManager.GetFreeRooms(hotelId, bookingId);
            return freeRooms;
        }


        [HttpPost]
        public async Task<int> Post([FromBody] Hotel newHotel)
        {
            if (newHotel.Id != Guid.Empty)
            {
                return 0;
            }
            int rowsAffected = await _hotelsManager.AddOrUpdateAsync(newHotel);
            return rowsAffected;
        }

        [HttpPut]
        public async Task<int> Put([FromBody] Hotel updatedHotel)
        {
            if (updatedHotel.Id == Guid.Empty)
            {
                return 0;
            }
            int rowsAffected = await _hotelsManager.AddOrUpdateAsync(updatedHotel);
            return rowsAffected;
        }

        [HttpDelete]
        public async Task<int> Delete(Guid id)
        {
            int rowsAffected = await _hotelsManager.Delete(id);
            return rowsAffected;
        }
    }
}
