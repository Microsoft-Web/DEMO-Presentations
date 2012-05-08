using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podcast.Models
{
    public class FrontPageViewModel
    {
        public Episode Featured { get; set; }
        public IEnumerable<Episode> Episodes { get; set; }

    }
}