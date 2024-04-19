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
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
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
        }
    }
}
