using System.Diagnostics;
using System.Threading;
using System.Web.Http;

namespace EventListenerWebAPI.Controllers
{
    public class ListenerController : ApiController
    {
        [HttpGet]
        [Route("api/Listener/DoSomethingWithEvent")]
        public string DoSomethingWithEvent(int id)
        {
            Thread.Sleep(5000);
            var msg = $"Event with id {id} is received";
            Debug.WriteLine(msg);
            return msg;
        }
    }
}
