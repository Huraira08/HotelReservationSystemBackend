using HotelReservationSystemBackend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystemBackend.Data.EntityConfiguration
{
    internal class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).HasMaxLength(100).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(50).IsRequired();
            builder.Property(u => u.Password).HasMaxLength(32).IsRequired();
            builder.Property(u => u.Age).IsRequired();
            builder.Property(u => u.Gender).IsRequired();
            builder.Property(u => u.Cnic).HasMaxLength(15).IsRequired();
            builder.Property(u => u.Role).IsRequired();
            builder.Ignore(u => u.BookingRequests);

            builder.HasData(
                new User { 
                    Id = Guid.NewGuid(), 
                    Name = "Aslam Azhar",
                    Email = "aslamazhar@gmail.com",
                    Password = "aslam1234",
                    Age = 26,
                    Gender = Gender.Male,
                    Cnic = "33293-5749302-1",
                    Role = Role.Customer
                }
                );
            builder.HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    Email = "admin@gmail.com",
                    Password = "Admin123",
                    Age = 30,
                    Gender = Gender.Male,
                    Cnic = "33889-170293-3",
                    Role = Role.Admin
                }
                );
        }
    }
}
