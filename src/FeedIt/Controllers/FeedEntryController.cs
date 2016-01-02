using FeedIt.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace FeedIt.Controllers
{
    public class FeedEntryController : ApiController
    {
        [Route("feed/{feedId}/entry/{entryId}/media")]
        public IHttpActionResult Get(int feedId, int entryId)
        {
            var feedService = new FeedService();
            var item = feedService.GetFeedEntry(feedId, entryId);
            return new RedirectResult(item.Enclosure.Link, this);
        }
    }
}
