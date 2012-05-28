using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace NancyDemo
{
    public class HelloWorldModule : NancyModule
    {
        public HelloWorldModule()
        {
            Get["/"] = parameters => "Hello World";
        }
    }
}