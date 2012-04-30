using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace NancyDemo
{
    public class HelloUserModule : NancyModule
    {
        public HelloUserModule()
        {
            Get["/{name}"] = parameters => "Hello " + parameters.name;
        }
    }
}