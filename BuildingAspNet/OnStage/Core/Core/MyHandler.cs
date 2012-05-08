using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core
{
    public class MyHandler: IHttpHandler
    {
        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("foo");
        }
    }
}