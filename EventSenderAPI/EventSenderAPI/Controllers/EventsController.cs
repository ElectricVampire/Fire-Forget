using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;

namespace EventSenderAPI.Controllers
{
    public class EventsController : ApiController
    {
        [HttpGet]
        [Route("api/Events/SendEvent")]
        public string SendEvent(int id)
        {
            HostingEnvironment.QueueBackgroundWorkItem(ct => PostEventToAnotherWebAPI(id));
            var msg = $"Event with id {id} is sent";
            Debug.WriteLine(msg);
            return msg;
        }

        private void PostEventToAnotherWebAPI(int id)
        {
            CustomWebAPIClient client = new CustomWebAPIClient();
            client.CallWebAPIAsync(id);
        }
    }
}
