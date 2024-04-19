﻿using HotelReservationSystemBackend.Data.Context;
using HotelReservationSystemBackend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemBackend.Data.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly HotelReservationContext _context;

        public UserRepository(HotelReservationContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User?> GetAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<int> AddOrUpdateAsync(User newUser)
        {
            if(newUser.Id == Guid.Empty)
            {
                _context.Users.Add(newUser);
            }
            else
            {
                User? oldUser = await GetAsync(newUser.Id);

                if (oldUser == null) return 0;

                oldUser.Name = newUser.Name;
                oldUser.Email = newUser.Email;
                oldUser.Password = newUser.Password;
                oldUser.Age = newUser.Age;
                oldUser.Gender = newUser.Gender;
                oldUser.Cnic = newUser.Cnic;
                oldUser.Role = newUser.Role;
                _context.Entry(oldUser).State = EntityState.Modified;
            }
            return _context.SaveChanges();
        }
        public async Task<int> Delete(Guid id)
        {
            User? user = await GetAsync(id);
            if(user == null) return 0;

            _context.Users.Remove(user);
            return _context.SaveChanges();
        }
    }
}