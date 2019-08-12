using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SignalrRDemo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IHubContext<ChatHub> _chatHubContext;
        private readonly IChatHubProvider _chatHubProvider;


        public ValuesController(IHubContext<ChatHub> chatHubContext, IChatHubProvider chatHubProvider)
        {
            _chatHubContext = chatHubContext;
            _chatHubProvider = chatHubProvider; 
            
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            await _chatHubProvider.SendMessage("WebApi_caller", "Message from ChatHub.");
            await _chatHubContext.Clients.All.SendAsync("ReceiveMessage", "WebApi_caller", "Message from ChatHubContext");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
