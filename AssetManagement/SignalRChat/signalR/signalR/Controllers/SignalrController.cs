using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using signalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace signalR.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalrController : ControllerBase
    {
        IHubContext<ChatHub> _hub;
        public SignalrController(IHubContext<ChatHub> hub)
        {
            _hub = hub;
        }
        [HttpPost("{id}")]
        public async void JoinGroup(string id)
        {
            var connectionId = Guid.NewGuid().ToString();
            Console.WriteLine($"{connectionId} has joined");
            await _hub.Groups.AddToGroupAsync(connectionId , id) ;

        }
        [HttpPost("{id}/{message}")]
        public async void SendMsg(string id , string message)
        {
            await _hub.Clients.Group(id).SendAsync("Message", message);
        }

    }
}
