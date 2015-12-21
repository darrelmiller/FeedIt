using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace FeedIt.Controllers
{
    public class FeedController : ApiController
    {
        private Feed _Feed;
        public FeedController()
        {
            var mp3ContainerUrl = new Uri("https://hypermediaapi.blob.core.windows.net/inthemoodforhttp-audio/");
            _Feed = new Feed()
            {
                Title = "In the mood for HTTP",
                Link = new Uri("http://example.org"),
                Description = "A Q&A show about HTTP"
            };

            _Feed.FeedItems.Add(new FeedItem()
            {
                Title = "Episode 1",
                Enclosure = new Uri(mp3ContainerUrl, new Uri("In%20The%20Mood%20For%20HTTP%20Episode%201.mp3", UriKind.Relative))
            });

            _Feed.FeedItems.Add(new FeedItem()
            {
                Title = "Episode 2",
                Enclosure = new Uri(mp3ContainerUrl, new Uri("In%20The%20Mood%20For%20HTTP%20Episode%202.mp3", UriKind.Relative))
            });

            _Feed.FeedItems.Add(new FeedItem()
            {
                Title = "Episode 3",
                Enclosure = new Uri(mp3ContainerUrl, new Uri("In%20The%20Mood%20For%20HTTP%20Episode%203.mp3", UriKind.Relative))
            });
        }

        [Route("feed/{feedId}")]
        public IHttpActionResult Get(string feedId)
        {
            
            return new ResponseMessageResult(new HttpResponseMessage() { Content = new FeedContent(_Feed) });
        }
    }
}