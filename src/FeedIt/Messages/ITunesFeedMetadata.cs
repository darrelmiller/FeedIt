using System;
using System.Linq;
using System.Collections.Generic;

namespace FeedIt
{
    public class ITunesFeedMetadata
    {
        public string SubTitle { get; set; }
        public string Author { get; set; }
        public string Summary { get; set; }
        public string OwnerName { get; set; }
        public string OwnerEmail { get; set; }
        public Uri Image { get; set; }
        public string Category { get; set; }  // needs to allow nesting
    }
}