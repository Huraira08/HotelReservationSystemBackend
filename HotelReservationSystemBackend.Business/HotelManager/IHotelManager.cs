using HotelReservationSystemBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemBackend.Business.HotelManager
{
    public interface IHotelManager
    {
        public Task<Hotel?> GetAsync(Guid id);
        public Task<List<Hotel>> GetAsync();
        public Task<List<int>> GetFreeRooms(Guid hotelId, Guid bookingId);
        public Task<int> AddOrUpdateAsync(Hotel newHotel);
        public Task<int> Delete(Guid id);
    }
}
