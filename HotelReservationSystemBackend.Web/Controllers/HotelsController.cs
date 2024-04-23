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
        public async Task<int> Post([FromBody] HotelDTO newHotelDTO)
        {
            Hotel newHotel = new Hotel { 
                Name = newHotelDTO.Name,
                NoOfRooms = newHotelDTO.NoOfRooms,
                RentPerDay = newHotelDTO.RentPerDay,
                ImagePaths = newHotelDTO.ImagePaths
            };
            if (!newHotelDTO.Id.IsNullOrEmpty())
            {
                return 0;
            }
            int rowsAffected = await _hotelsManager.AddOrUpdateAsync(newHotel);
            return rowsAffected;
        }

        //[HttpPut]
        //public async Task<int> Put([FromBody] HotelDTO updatedHotelDTO)
        //{
        //    Hotel updatedHotel = new Hotel
        //    {
        //        Name = updatedHotelDTO.Name,
        //        NoOfRooms = updatedHotelDTO.NoOfRooms,
        //        RentPerDay = updatedHotelDTO.RentPerDay,
        //        ImagePaths = updatedHotelDTO.ImagePaths
        //    };
        //    if (updatedHotelDTO.Id.IsNullOrEmpty())
        //    {
        //        return 0;
        //    }
        //    updatedHotel.Id = Guid();
        //    int rowsAffected = await _hotelsManager.AddOrUpdateAsync(updatedHotel);
        //    return rowsAffected;
        //}

        [HttpDelete]
        public async Task<int> Delete(Guid id)
        {
            int rowsAffected = await _hotelsManager.Delete(id);
            return rowsAffected;
        }
    }
}
