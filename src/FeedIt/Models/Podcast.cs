using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedIt.Models
{
    public class Podcast
    {
        public Uri Logo { get; set; }
        public Uri StorageContainer { get; set; }
        public string Title { get; set; }
        public string[] Hosts { get; set; }
        public string Description { get; set; } 

        public ICollection<Episode> Episodes { get; set; }
    }
}
