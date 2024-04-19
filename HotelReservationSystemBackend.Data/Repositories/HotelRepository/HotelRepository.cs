using HotelReservationSystemBackend.Data.Context;
using HotelReservationSystemBackend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemBackend.Data.Repositories.HotelRepository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelReservationContext _context;
        public HotelRepository(HotelReservationContext context)
        {
            _context = context;
        }

        public async Task<List<Hotel>> GetAsync()
        {
            return await _context.Hotels.ToListAsync();
        }
        public async Task<Hotel?> GetAsync(Guid id)
        {
            return await _context.Hotels.FindAsync(id);
        }
        public async Task<int> AddOrUpdateAsync(Hotel newHotel)
        {
            if (newHotel.Id == Guid.Empty)
            {
                _context.Add(newHotel);
            }
            else
            {
                Hotel? oldHotel = await GetAsync(newHotel.Id);
                if (oldHotel == null) return 0;

                oldHotel.Name = newHotel.Name;
                oldHotel.NoOfRooms = newHotel.NoOfRooms;
                oldHotel.RentPerDay = newHotel.RentPerDay;
                oldHotel.ImagePaths = newHotel.ImagePaths;

                _context.Entry(newHotel).State = EntityState.Modified;
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(Guid id)
        {
            Hotel? hotel = await GetAsync(id);
            if (hotel == null) return 0;

            _context.Hotels.Remove(hotel);
            return await _context.SaveChangesAsync();
        }
    }
}
