using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace NancyDemo
{
    public class RandomChuckFactModule : NancyModule
    {
        public RandomChuckFactModule()
        {
            string[] quotes = new string[]
            {
                "Chuck Norris does not sleep. He waits.",
                "When the Boogeyman goes to sleep every night, he checks his closet for Chuck Norris.",
                "Chuck Norris doesn't read books. He stares them down until he gets the information he wants.",
                "There is no theory of evolution. Just a list of creatures Chuck Norris has allowed to live.",
                "Outer space exists because its afraid to be on the same planet with Chuck Norris.",
                "Chuck Norris is currently suing NBC, claiming Law and Order are trademarked names for his left and right legs.",
                "Chuck Norris is the reason why Waldo is hiding."
            };

            var rnd = new Random().Next(0, quotes.Length - 1);

            Get["/facts"] = paramters =>
            {
                return quotes[rnd];
            };
        }
    }
}