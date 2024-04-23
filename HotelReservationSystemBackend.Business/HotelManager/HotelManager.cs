using HotelReservationSystemBackend.Data.Repositories.AllocationRepository;
using HotelReservationSystemBackend.Data.Repositories.BookingRepository;
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
        private readonly IAllocationRepository _allocationRepository;
        private readonly IBookingRequestRepository _bookingRequestRepository;
        public HotelManager(IHotelRepository hotelRepository, 
            IAllocationRepository allocationRepository,
            IBookingRequestRepository bookingRequestRepository
            )
        {
            _hotelRepository = hotelRepository;
            _allocationRepository = allocationRepository;
            _bookingRequestRepository = bookingRequestRepository;
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
        public async Task<List<int>> GetFreeRooms(Guid hotelId, Guid bookingId)
        {
            Hotel? hotel = await _hotelRepository.GetAsync(hotelId);
            BookingRequest? bookingRequest = await _bookingRequestRepository.GetAsync(bookingId);

            if (hotel == null|| bookingRequest == null) return [];
            List<Guid> approvedRequestIds = await _bookingRequestRepository.GetAccpetedRequestsWithDateRange(
                hotelId,
                bookingRequest.CheckInDate, 
                bookingRequest.CheckOutDate
                );

            List<int> freeRooms = Enumerable.Range(1, hotel.NoOfRooms).ToList();
            List<int> occupiedRooms = await _allocationRepository.GetRoomsFromBookings(approvedRequestIds);
            freeRooms = freeRooms.Except(occupiedRooms).ToList();
            return freeRooms;
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
