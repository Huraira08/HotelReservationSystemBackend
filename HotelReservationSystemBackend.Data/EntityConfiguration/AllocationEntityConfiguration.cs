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
    public class AllocationEntityConfiguration : IEntityTypeConfiguration<Allocation>
    {
        public void Configure(EntityTypeBuilder<Allocation> builder)
        {
            builder.ToTable(nameof(Allocation));
            builder.HasKey(a => a.Id);
            builder.Property(a => a.RoomNo).IsRequired();
            builder.Property(a => a.BookingRequestId).IsRequired();
            builder.Ignore(a => a.BookingRequest);
        }
    }
}
