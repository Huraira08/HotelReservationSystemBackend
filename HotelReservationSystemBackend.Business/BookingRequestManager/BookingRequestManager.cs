using HotelReservationSystemBackend.Data.Repositories.BookingRepository;
using HotelReservationSystemBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemBackend.Business.BookingRequestManager
{
    public class BookingRequestManager : IBookingRequestManager
    {
        private readonly IBookingRequestRepository _bookingRequestRepository;
        public BookingRequestManager(IBookingRequestRepository bookingRequestRepository)
        {
            _bookingRequestRepository = bookingRequestRepository;
        }
        public async Task<List<BookingRequest>> GetAsync()
        {
            List<BookingRequest> bookingRequests = await _bookingRequestRepository.GetAsync();
            return bookingRequests;
        }

        public async Task<BookingRequest?> GetAsync(Guid id)
        {
            BookingRequest? bookingRequest = await _bookingRequestRepository.GetAsync(id);
            return bookingRequest;
        }

        public async Task<int> AddOrUpdateAsync(BookingRequest newBookingRequest)
        {
            int rowsAffected = await _bookingRequestRepository.AddOrUpdateAsync(newBookingRequest);
            return rowsAffected;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            int rowsAffected = await _bookingRequestRepository.DeleteAsync(id);
            return rowsAffected;
        }
    }
}
