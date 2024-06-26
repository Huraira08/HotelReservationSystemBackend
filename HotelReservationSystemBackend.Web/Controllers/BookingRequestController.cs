﻿using HotelReservationSystemBackend.Business.BookingRequestManager;
using HotelReservationSystemBackend.Model;
using HotelReservationSystemBackend.Web.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;

namespace HotelReservationSystemBackend.Web.Controllers
{
    [Authorize(Policy= "AdminOrCustomer")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingRequestController : ControllerBase
    {
        private readonly IBookingRequestManager _bookingRequestManager;
        //private readonly Notifier _notifier;
        private readonly IHubContext<Notifier> _hubContext;
        public BookingRequestController(IBookingRequestManager bookingRequestManager,
            IHubContext<Notifier> hubContext
            )
        {
            _bookingRequestManager = bookingRequestManager;
            _hubContext = hubContext;
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

        [HttpGet("RequestAllocation")]
        public async Task<List<RequestAllocationDTO>> GetRequestAndAllocation()
        {
            List<RequestAllocationDTO> requestAllocations = await _bookingRequestManager.GetRequestAndAllocation();
            return requestAllocations;
        }


        [HttpPost]
        public async Task<int> Post(BookingRequest newBookingRequest)
        {
            if (newBookingRequest.Id != Guid.Empty) return 0;

            int rowsAffected = await _bookingRequestManager.AddOrUpdateAsync(newBookingRequest);
            return rowsAffected;
        }

        [HttpPost("allocate/{bookingId}/{roomNo}")]
        public async Task<int> AllocateRoom(Guid bookingId, int roomNo)
        {
            int rowsAffected = await _bookingRequestManager.AllocateRoom(bookingId, roomNo);

            if (rowsAffected > 0)
            {
                BookingRequest bookingRequest = new BookingRequest
                {
                    Id = bookingId,
                    BookingStatus = BookingStatus.Approved
                };
                await _hubContext.Clients.All.SendAsync("status", bookingRequest);
            }
            return rowsAffected;
        }

        [HttpPut("reject/{bookingId}")]
        public async Task<int> Reject(Guid bookingId)
        {
            if (bookingId == Guid.Empty) return 0;
            BookingRequest updatedBookingRequest = new BookingRequest
            {
                Id = bookingId,
                BookingStatus = BookingStatus.Rejected,
            };
            int rowsAffected = await _bookingRequestManager.AddOrUpdateAsync(updatedBookingRequest);
            if(rowsAffected > 0)
            {
                await _hubContext.Clients.All.SendAsync("status", updatedBookingRequest);
            }
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
