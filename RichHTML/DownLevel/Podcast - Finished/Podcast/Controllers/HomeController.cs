using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Podcast.Models;

namespace Podcast.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var repo = new Repository();
            IQueryable<Episode> episodes = repo.GetEpisodes();

            var model = new FrontPageViewModel();
            model.Episodes = episodes.OrderByDescending(e => e.Number);
            model.Featured = model.Episodes.FirstOrDefault();

            return View(model);
        }

        public ActionResult Episode(int id)
        {
            var repo = new Repository();
            var model = repo.GetEpisode(id);
            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
