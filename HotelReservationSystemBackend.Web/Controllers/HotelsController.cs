﻿using HotelReservationSystemBackend.Business.HotelManager;
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


        [HttpPost]
        public async Task<int> Post([FromBody] HotelDTO newHotel)
        {
            if(!newHotel.Id.IsNullOrEmpty())
            {
                return 0;
            }
            Hotel hotel = new Hotel {
                Name = newHotel.Name,
                NoOfRooms = newHotel.NoOfRooms,
                RentPerDay = newHotel.RentPerDay,
                ImagePaths = newHotel.ImagePaths
            };
            int rowsAffected = await _hotelsManager.AddOrUpdateAsync(hotel);
            return rowsAffected;
        }

        [HttpPut]
        public async Task<int> Put([FromBody] Hotel updatedHotel)
        {
            if(updatedHotel.Id == Guid.Empty)
            {
                return 0;
            }
            Hotel hotel = new Hotel
            {
                Name = updatedHotel.Name,
                NoOfRooms = updatedHotel.NoOfRooms,
                RentPerDay = updatedHotel.RentPerDay,
                ImagePaths = updatedHotel.ImagePaths
            };
            int rowsAffected = await _hotelsManager.AddOrUpdateAsync(hotel);
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