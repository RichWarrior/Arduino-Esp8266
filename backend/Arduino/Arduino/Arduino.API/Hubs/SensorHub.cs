using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arduino.API.Hubs
{
    public class SensorHub : Hub
    {
        public override async Task OnConnectedAsync()
        {            

        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
        }
    }
}
