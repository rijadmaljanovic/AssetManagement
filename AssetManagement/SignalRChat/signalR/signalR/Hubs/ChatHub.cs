using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using signalR.Hubs;

namespace signalR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("Message" , message);
        }

        public async Task SendToGroup(string group, string message) 
        {
            await Clients.Group(group).SendAsync("Message",message);
        }

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            Console.WriteLine($"{Context.ConnectionId} has joined");
        }

        public async Task LeaveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            Console.WriteLine($"{Context.ConnectionId} has left");
        }

        public override async Task OnConnectedAsync()
        {
            Console.WriteLine("Someone connected.");
            await base.OnConnectedAsync();
        }

    }
}
