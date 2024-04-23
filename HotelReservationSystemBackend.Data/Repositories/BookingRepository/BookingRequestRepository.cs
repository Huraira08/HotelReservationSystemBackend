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
            return await _context.BookingRequests.Include(r=>r.Hotel).ToListAsync();
        }
        public async Task<BookingRequest?> GetAsync(Guid id)
        {
            BookingRequest? request = await _context.BookingRequests
                .Include(r => r.Hotel)
                .FirstOrDefaultAsync(r => r.Id == id);
            return request;
        }
        public async Task<List<BookingRequest>> GetByUserId(Guid userId)
        {
            List<BookingRequest> requests = await _context.BookingRequests
                .Where(r => r.UserId == userId)
                .Include(b => b.Hotel)
                .ToListAsync();
            return requests;
        }
        public async Task<List<Guid>> GetAccpetedRequestsWithDateRange(Guid hotelId, DateTime checkIn, DateTime checkOut)
        {
            List<Guid> approvedRequestIds = await _context.BookingRequests
                .Where(r => r.HotelId == hotelId)
                .Where(r =>
                (r.CheckInDate.Date >= checkIn.Date
                && r.CheckInDate.Date <= checkOut.Date)
                || (r.CheckOutDate.Date >= checkIn.Date
                && r.CheckOutDate.Date <= checkOut.Date))
                .Where(r => r.BookingStatus == BookingStatus.Approved)
                .Select(r => r.Id)
                .ToListAsync();
            return approvedRequestIds;
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

                //_context.Entry(newBookingRequest).State = EntityState.Modified;
            }

            return await _context.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(Guid id)
        {
            BookingRequest? bookingRequest = await GetAsync(id);
            if (bookingRequest == null) return 0;

            _context.BookingRequests.Remove(bookingRequest);
            return await _context.SaveChangesAsync();
        }
    }
}
