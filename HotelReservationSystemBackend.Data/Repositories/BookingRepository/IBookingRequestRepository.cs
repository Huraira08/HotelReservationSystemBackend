using HotelReservationSystemBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemBackend.Data.Repositories.BookingRepository
{
    public interface IBookingRequestRepository
    {
        public Task<BookingRequest?> GetAsync(Guid id);
        public Task<List<BookingRequest>> GetByUserId(Guid userId);
        public Task<List<BookingRequest>> GetAsync();
        public Task<int> AddOrUpdateAsync(BookingRequest newBookingRequest);
        public Task<int> DeleteAsync(Guid id);
    }
}
