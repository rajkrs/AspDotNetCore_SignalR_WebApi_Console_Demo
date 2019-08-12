using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalrRDemo.WebApi
{
    public class ChatHubProvider : IChatHubProvider
    {
        private readonly ChatHub _chatHub;
        public ChatHubProvider(ChatHub chatHub)
        {
            _chatHub = chatHub;
        }
        public string GetUniqueConnectionId() {
            return _chatHub.GetUniqueConnectionId();
        }

        public Task SendMessage(string user, string message) {
            return _chatHub.SendMessage(user, message);
        }
       
    }
}
