using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace CM7A68_HFT_2021221.Endpoint.Services
{
    public class SiganlRHub:Hub
    {
        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("Connected", Context.ConnectionId);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            Clients.Caller.SendAsync("Disconnected", Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
