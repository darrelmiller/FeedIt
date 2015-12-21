using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace FeedIt
{
    public class FeedContent : HttpContent
    {
        readonly Feed feed;

        public FeedContent(Feed feed)
        {
            this.feed = feed;
            this.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/rss+xml");
        }

        protected async override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {

            await feed.WriteToStreamAsync(stream);

        }
        protected override bool TryComputeLength(out long length)
        {
            length = -1;
            return false;
        }
    }
}