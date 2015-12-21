using System;
using System.Linq;
using System.Collections.Generic;

namespace FeedIt
{
    public class ITunesFeedItemMetadata
    {
        public string Author { get; set; }
        public string SubTitle { get; set; }
        public string Summary { get; set; }
        public Uri Image { get; set; }
        public TimeSpan Duration { get; set; }
    }
}