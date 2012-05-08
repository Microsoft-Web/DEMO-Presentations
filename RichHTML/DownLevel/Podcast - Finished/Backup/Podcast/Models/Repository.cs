using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Podcast.Models;

namespace Podcast
{
    public class Repository
    {
        List<Episode> Episodes; 

        public Repository()
        {
            Episodes = new List<Episode>();

            for (int i = 0; i < 10; i++)
            {
                var e = new Episode();
                e.ID = i + 1;
                e.Number = i + 1;
                e.Title = "Epsiode" + e.Number;
                e.Description = "A really good show this week...";
                e.FileName = "Episode.mp3";
                Episodes.Add(e);
            }
        }

        public IQueryable<Episode> GetEpisodes()
        {
            return Episodes.AsQueryable();
        }

        public Episode GetEpisode(int id)
        {
            return Episodes.SingleOrDefault(e => e.ID == id);
        }
    }
}