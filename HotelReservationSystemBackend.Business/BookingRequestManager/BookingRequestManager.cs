using HotelReservationSystemBackend.Data.Repositories.AllocationRepository;
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
        private readonly IAllocationRepository _allocationRepository;
        public BookingRequestManager(
            IBookingRequestRepository bookingRequestRepository,
            IAllocationRepository allocationRepository
            )
        {
            _bookingRequestRepository = bookingRequestRepository;
            _allocationRepository = allocationRepository;
        }
        public async Task<List<BookingRequest>> GetAsync()
        {
            List<BookingRequest> bookingRequests = await _bookingRequestRepository.GetAsync();
            return bookingRequests;
        }

        public async Task<List<BookingRequest>> GetByUserId(Guid userId)
        {
            List<BookingRequest> bookingRequests = await _bookingRequestRepository.GetByUserId(userId);
            return bookingRequests;
        }

        public async Task<BookingRequest?> GetAsync(Guid id)
        {
            BookingRequest? bookingRequest = await _bookingRequestRepository.GetAsync(id);
            return bookingRequest;
        }

        public async Task<List<RequestAllocationDTO>> GetRequestAndAllocation()
        {
            List<BookingRequest> bookingRequests = await _bookingRequestRepository.GetAsync();
            List<Allocation> allocations = await _allocationRepository.GetAsync();
            List<RequestAllocationDTO> requestAllocationDTOs = [];
            foreach (BookingRequest bookingRequest in bookingRequests)
            {
                Allocation? allocation = allocations.Find(a=>a.BookingRequestId == bookingRequest.Id);
                RequestAllocationDTO allocationDTO = new RequestAllocationDTO {
                    BookingRequest = bookingRequest,
                    Allocation = allocation
                };
                requestAllocationDTOs.Add(allocationDTO);
            }
            return requestAllocationDTOs;
        }

        public async Task<int> AddOrUpdateAsync(BookingRequest newBookingRequest)
        {
            int rowsAffected = await _bookingRequestRepository.AddOrUpdateAsync(newBookingRequest);
            return rowsAffected;
        }

        public async Task<int> AllocateRoom(Guid bookingId, int roomNo)
        {
            Allocation allocation = new Allocation { 
                BookingRequestId = bookingId,
                RoomNo = roomNo 
            };
            int rowsAffected = await _allocationRepository.AddAsync(allocation);
            if(rowsAffected > 0)
            {
                BookingRequest bookingRequest = new BookingRequest {
                    Id = bookingId,
                    BookingStatus = BookingStatus.Approved
                };
                rowsAffected = await _bookingRequestRepository.AddOrUpdateAsync(bookingRequest);
                return rowsAffected;
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            int rowsAffected = await _bookingRequestRepository.DeleteAsync(id);
            return rowsAffected;
        }
    }
}
