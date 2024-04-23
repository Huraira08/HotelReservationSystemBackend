using HotelReservationSystemBackend.Business.BookingRequestManager;
using HotelReservationSystemBackend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace HotelReservationSystemBackend.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingRequestController : ControllerBase
    {
        private readonly IBookingRequestManager _bookingRequestManager;
        public BookingRequestController(IBookingRequestManager bookingRequestManager)
        {
            _bookingRequestManager = bookingRequestManager;
        }

        [HttpGet]
        public async Task<List<BookingRequest>> Get()
        {
            List<BookingRequest> bookingRequests = await _bookingRequestManager.GetAsync();
            return bookingRequests;
        }

        [HttpGet("{id}")]
        public async Task<BookingRequest?> Get(Guid id)
        {
            BookingRequest? bookingRequest = await _bookingRequestManager.GetAsync(id);
            return bookingRequest;
        }

        [HttpGet("UserRequests/{userId}")]
        public async Task<List<BookingRequest>> GetByUserId(Guid userId)
        {
            List<BookingRequest> bookingRequests = await _bookingRequestManager.GetByUserId(userId);
            return bookingRequests;
        }


        [HttpPost]
        public async Task<int> Post(BookingRequestDTO newBookingRequestDTO)
        {
            if (!newBookingRequestDTO.Id.IsNullOrEmpty()) return 0;
            BookingRequest newBookingRequest = new BookingRequest
            {
                CheckInDate = newBookingRequestDTO.CheckInDate,
                CheckOutDate = newBookingRequestDTO.CheckOutDate,
                TotalRent = newBookingRequestDTO.TotalRent,
                BookingStatus = newBookingRequestDTO.BookingStatus,
                HotelId = newBookingRequestDTO.HotelId,
                UserId = newBookingRequestDTO.UserId
            };

            int rowsAffected = await _bookingRequestManager.AddOrUpdateAsync(newBookingRequest);
            return rowsAffected;
        }

        [HttpPut]
        public async Task<int> Put(BookingRequestDTO updatedBookingRequestDTO)
        {
            if (updatedBookingRequestDTO.Id.IsNullOrEmpty()) return 0;
            BookingRequest updatedBookingRequest = new BookingRequest
            {
                CheckInDate = updatedBookingRequestDTO.CheckInDate,
                CheckOutDate = updatedBookingRequestDTO.CheckOutDate,
                TotalRent = updatedBookingRequestDTO.TotalRent,
                BookingStatus = updatedBookingRequestDTO.BookingStatus,
                HotelId = updatedBookingRequestDTO.HotelId,
                UserId = updatedBookingRequestDTO.UserId
            };
            int rowsAffected = await _bookingRequestManager.AddOrUpdateAsync(updatedBookingRequest);
            return rowsAffected;
        }

        [HttpDelete]
        public async Task<int> Delete(Guid id)
        {
            if(id == Guid.Empty) return 0;
            int rowsAffected = await _bookingRequestManager.DeleteAsync(id);
            return rowsAffected;
        }
    }
}
