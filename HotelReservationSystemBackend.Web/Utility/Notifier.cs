using HotelReservationSystemBackend.Model;
using Microsoft.AspNetCore.SignalR;

namespace HotelReservationSystemBackend.Web.Utility
{
    public class Notifier : Hub
    {
        public async Task SendMessage(BookingStatus status)
        {
            await Clients.All.SendAsync("status", status);
        }
    }
}
