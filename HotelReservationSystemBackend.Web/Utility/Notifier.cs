using HotelReservationSystemBackend.Model;
using Microsoft.AspNetCore.SignalR;

namespace HotelReservationSystemBackend.Web.Utility
{
    public class Notifier : Hub
    {
        public async Task SendMessage(BookingRequest request)
        {
            await Clients.All.SendAsync("status", request);
        }
    }
}
