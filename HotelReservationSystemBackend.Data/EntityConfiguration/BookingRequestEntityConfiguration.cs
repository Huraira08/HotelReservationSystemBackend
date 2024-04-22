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
    internal class BookingRequestEntityConfiguration : IEntityTypeConfiguration<BookingRequest>
    {
        public void Configure(EntityTypeBuilder<BookingRequest> builder)
        {
            builder.ToTable(nameof(BookingRequest));
            builder.HasKey(b => b.Id);
            // use validation in business such that
            // checkin is greater than today's date
            builder.Property(b => b.CheckInDate).IsRequired();
            // use validation in business such
            // checkout is greater than checkin date
            builder.Property(b => b.CheckOutDate).IsRequired();
            builder.Property(b => b.TotalRent).IsRequired();
            builder.Property(b => b.BookingStatus).IsRequired();
            builder.Property(b => b.HotelId).IsRequired();
            builder.Ignore(b => b.Hotel);
            builder.Property(b => b.UserId).IsRequired();
            builder.Ignore(b => b.User);
        }
    }
}
