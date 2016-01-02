using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedIt.Models
{
    public class Episode
    {
        public string Title { get; set; }
        public string[] Hosts { get; set; }
        public string[] Guests { get; set; }
        public string Description { get; set; }
        public string AudioFileSlug { get; set; }
        public DateTime PubDate { get; internal set; }
    }
}
