using HotelReservationSystemBackend.Data.Repositories.UserRepository;
using HotelReservationSystemBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemBackend.Business.UserManager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<User>> GetAsync()
        {
            List<User> users = await _userRepository.GetAsync();
            return users;
        }
        public async Task<User?> GetAsync(Guid id)
        {
            User? user = await _userRepository.GetAsync(id);
            return user;
        }
        public async Task<User?> AddOrUpdateAsync(User newUser)
        {
            User? user = await _userRepository.AddOrUpdateAsync(newUser);
            return user;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            int rowsAffected = await _userRepository.Delete(id);
            return rowsAffected;
        }

        public async Task<User?> Login(string email, string password)
        {
            User? user = await _userRepository.GetByEmailAsync(email);
            if(user == null || user.Password != password)
            {
                return null;
            }
            return user;
        }
    }
}
