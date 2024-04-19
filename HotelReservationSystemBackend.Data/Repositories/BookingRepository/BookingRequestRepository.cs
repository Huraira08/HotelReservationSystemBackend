using HotelReservationSystemBackend.Data.Context;
using HotelReservationSystemBackend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemBackend.Data.Repositories.BookingRepository
{
    public class BookingRequestRepository : IBookingRequestRepository
    {
        private readonly HotelReservationContext _context;
        public BookingRequestRepository(HotelReservationContext context)
        {
            _context = context;
        }
        public async Task<List<BookingRequest>> GetAsync()
        {
            return await _context.BookingRequests.ToListAsync();
        }
        public async Task<BookingRequest?> GetAsync(Guid id)
        {
            return await _context.BookingRequests.FindAsync(id);
        }
        public async Task<int> AddOrUpdateAsync(BookingRequest newBookingRequest)
        {
            if (newBookingRequest.Id == Guid.Empty)
            {
                _context.Add(newBookingRequest);
            }
            else
            {
                BookingRequest? oldBookingRequest = await GetAsync(newBookingRequest.Id);
                if (oldBookingRequest == null
                    || oldBookingRequest.BookingStatus != BookingStatus.Pending) return 0;

                oldBookingRequest.BookingStatus = newBookingRequest.BookingStatus;

                _context.Entry(newBookingRequest).State = EntityState.Modified;
            }

            return await _context.SaveChangesAsync();
        }
        public async Task<int> Delete(Guid id)
        {
            BookingRequest? bookingRequest = await GetAsync(id);
            if (bookingRequest == null) return 0;

            _context.BookingRequests.Remove(bookingRequest);
            return await _context.SaveChangesAsync();
        }
    }
}
