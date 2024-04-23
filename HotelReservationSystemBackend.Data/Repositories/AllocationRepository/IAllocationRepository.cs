using HotelReservationSystemBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemBackend.Data.Repositories.AllocationRepository
{
    public interface IAllocationRepository
    {
        public Task<Allocation?> GetAsync(Guid id);
        public Task<List<Allocation>> GetAsync();
        public Task<List<int>> GetRoomsFromBookings(List<Guid> ids);
        public Task<int> AddAsync(Allocation newAllocation);
    }
}
