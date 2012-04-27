using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApiDemos.Models;

namespace WebApiDemos.Controllers
{
    public class PersonController : ApiController
    {
        List<Person> _people;

        public PersonController()
        {
            if (HttpContext.Current.Cache["people"] == null)
            {
                _people = new List<Person>();

                _people.AddRange(new Person[]
                {
                    new Person { Id = 1, Name = "Chuck Norris" },
                    new Person { Id = 2, Name = "David Carradine" },
                    new Person { Id = 3, Name = "Bruce Lee" }
                });

                HttpContext.Current.Cache["people"] = _people;
            }

            _people = (List<Person>)HttpContext.Current.Cache["people"];
        }

        public IQueryable<Person> Get()
        {
            return _people.AsQueryable<Person>();
        }

        public HttpResponseMessage<Person> Get(int id)
        {
            try
            {
                var person = _people.First(x => x.Id == id);

                Console.WriteLine(person.Name + " was requested");

                return new HttpResponseMessage<Person>(
                    person,
                    HttpStatusCode.OK
                    );
            }
            catch
            {
                return new HttpResponseMessage<Person>(HttpStatusCode.NotFound);
            }
        }

        public HttpResponseMessage Post(Person person)
        {
            person.Id = _people.Count + 1;

            if (_people.Any(x => x.Id == person.Id))
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            try
            {
                _people.Add(person);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
