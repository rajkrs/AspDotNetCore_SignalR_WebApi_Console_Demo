using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalrRDemo.WebApi
{
    public class ChatHub : Hub 
    {


        public string GetUniqueConnectionId()
        {
            return this.Context.ConnectionId;
        }


        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }


    }
}
