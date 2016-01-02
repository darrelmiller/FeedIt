using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using FeedIt.Services;

namespace FeedIt.Controllers
{
    public class FeedController : ApiController
    {
        

        [Route("feed/{feedId}")]
        public IHttpActionResult Get(int feedId)
        {
            var feedService = new FeedService();
            var feed = feedService.GetFeed(feedId);

            return new ResponseMessageResult(new HttpResponseMessage() { Content = new FeedContent(feed) });
        }

    }
}