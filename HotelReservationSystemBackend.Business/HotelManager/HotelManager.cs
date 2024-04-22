using HotelReservationSystemBackend.Data.Repositories.HotelRepository;
using HotelReservationSystemBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemBackend.Business.HotelManager
{
    public class HotelManager : IHotelManager
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<List<Hotel>> GetAsync()
        {
            List<Hotel> hotels = await _hotelRepository.GetAsync();
            return hotels;
        }
        public async Task<Hotel?> GetAsync(Guid id)
        {
            Hotel? hotel = await _hotelRepository.GetAsync(id);
            return hotel;
        }
        public async Task<int> AddOrUpdateAsync(Hotel newHotel)
        {
            int rowsAffected = await _hotelRepository.AddOrUpdateAsync(newHotel);
            return rowsAffected;
        }
        public async Task<int> Delete(Guid id)
        {
            int rowsAffected = await _hotelRepository.Delete(id);
            return rowsAffected;
        }
    }
}
