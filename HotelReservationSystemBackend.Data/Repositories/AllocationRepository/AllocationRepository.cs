using HotelReservationSystemBackend.Data.Context;
using HotelReservationSystemBackend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemBackend.Data.Repositories.AllocationRepository
{
    public class AllocationRepository : IAllocationRepository
    {
        private readonly HotelReservationContext _context;
        public AllocationRepository(HotelReservationContext context)
        {
            _context = context;
        }

        public async Task<List<Allocation>> GetAsync()
        {
            return await _context.Allocations.ToListAsync();
        }

        public async Task<Allocation?> GetAsync(Guid id)
        {
            return await _context.Allocations.FindAsync(id);
        }
        public async Task<List<int>> GetRoomsFromBookings(List<Guid> ids)
        {
            List<int> rooms = await _context.Allocations
                .Where(a => ids.Contains(a.BookingRequestId))
                .Select(a => a.RoomNo)
                //.Distinct()
                .ToListAsync();
            return rooms;
        }

        public async Task<int> AddAsync(Allocation newAllocation)
        {
            _context.Add(newAllocation);
            return await _context.SaveChangesAsync();
        }

    }
}
