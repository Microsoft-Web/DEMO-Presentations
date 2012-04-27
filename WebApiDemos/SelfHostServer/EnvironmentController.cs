using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SelfHostServer
{
    public class EnvironmentStatus
    {
        public string MachineName { get; set; }
        public DateTime TimeOnServer { get; set; }
    }

    public class EnvironmentController : ApiController
    {
        public EnvironmentStatus Get()
        {
            Console.WriteLine("User agent " + Request.Headers.UserAgent);

            return new EnvironmentStatus
            {
                MachineName = Environment.MachineName,
                TimeOnServer = DateTime.Now
            };
        }
    }
}
