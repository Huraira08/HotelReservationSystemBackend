using HotelReservationSystemBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemBackend.Business.UserManager
{
    public interface IUserManager
    {
        public Task<User?> GetAsync(Guid id);
        public Task<List<User>> GetAsync();
        public Task<User?> AddOrUpdateAsync(User newUser);
        public Task<int> DeleteAsync(Guid id);
    }
}
