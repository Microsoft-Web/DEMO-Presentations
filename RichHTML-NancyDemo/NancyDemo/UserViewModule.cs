using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace NancyDemo
{
    public class UserViewModule : NancyModule
    {
        public UserViewModule()
        {
            Get["/person"] = paramters =>
            {
                return View["PersonView.html", new { name = "Chuck Norris", Id = 1 }];
            };
        }
    }
}