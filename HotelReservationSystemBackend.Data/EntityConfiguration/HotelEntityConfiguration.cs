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
    internal class HotelEntityConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.ToTable(nameof(Hotel));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.NoOfRooms).IsRequired();
            builder.Property(x => x.RentPerDay).IsRequired();

            builder.HasData(
                new Hotel { Id = Guid.NewGuid(), Name = "Royal hotel", NoOfRooms = 50, RentPerDay = 5000, ImagePaths = [] },
                new Hotel { Id = Guid.NewGuid(), Name = "Five star hotel", NoOfRooms = 70, RentPerDay = 4000, ImagePaths = [] }
                );
        }
    }
}
