﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Podcast.Models
{
    public class Episode
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
    }
}