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
            List<Hotel> hotels = await _context.Hotels.ToListAsync();
            return hotels;
        }
        public async Task<Hotel?> GetAsync(Guid id)
        {
            Hotel? hotel = await _context.Hotels.FindAsync(id);
            return hotel;
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
            int rowAffected = await _context.SaveChangesAsync();
            return rowAffected;
        }

        public async Task<int> Delete(Guid id)
        {
            Hotel? hotel = await GetAsync(id);
            if (hotel == null) return 0;

            _context.Hotels.Remove(hotel);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }
    }
}
