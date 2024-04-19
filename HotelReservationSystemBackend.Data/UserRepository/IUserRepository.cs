using HotelReservationSystemBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemBackend.Data.UserRepository
{
    public interface IUserRepository
    {
        public Task<User?> GetAsync(Guid id);
        public Task<List<User>> GetAsync();
        public Task<int> AddOrUpdateAsync(User user);
        public Task<int> Delete(Guid id);
    }
}
