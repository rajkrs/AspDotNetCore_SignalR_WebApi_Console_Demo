using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalrRDemo.WebApi
{
    public interface IChatHubProvider
    {
        string GetUniqueConnectionId();

        Task SendMessage(string user, string message);
    }
}
