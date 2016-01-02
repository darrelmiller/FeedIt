using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedIt.Services
{
    public class FeedService
    {
        Dictionary<int, Feed> _Feeds;

        public FeedService()
        {
            _Feeds = new Dictionary<int, Feed>();
            SeedData();
        }
        public Feed GetFeed(int id)
        {
            return _Feeds[id];
        }

        private void SeedData()
        {

            var mp3ContainerUrl = new Uri("http://hypermediaapi.blob.core.windows.net/inthemoodforhttp-audio/");
            var feed = new Feed()
            {
                Title = "In the mood for HTTP",
                Link = new Uri("https://inthemoodforhttp.azurewebsites.net"),
                Description = "A Q&A show about HTTP",
                ITunesFeedMetaData = new ITunesFeedMetadata
                {
                    Author = "Darrel Miller / Glenn Block",
                    SubTitle = "A Q&A show about HTTP",
                    Summary = "A Q&A show about HTTP - desc"
                },
                Language = "en-US"
            };

            feed.FeedItems.Add(new FeedItem()
            {
                Title = "Episode 1",
                Enclosure = new Enclosure
                {
                    Link = new Uri(mp3ContainerUrl, new Uri("In%20The%20Mood%20For%20HTTP%20Episode%201.mp3", UriKind.Relative)),
                    Length = 49962696,
                    Type = "audio/mpeg"
                },
                ITunesFeedItemMetadata = new ITunesFeedItemMetadata
                {
                    Author = "Darrel Miller / Glenn Block",
                    SubTitle = "A Q&A show about HTTP",
                    Summary = "A Q&A show about HTTP - desc"
                },
                Guid = "http://tavis.net/feed/1/item/1/media",
                PubDate = new DateTime()
            });

            feed.FeedItems.Add(new FeedItem()
            {
                Title = "Episode 2",
                Enclosure = new Enclosure
                {
                    Link = new Uri(mp3ContainerUrl, new Uri("In%20The%20Mood%20For%20HTTP%20Episode%202.mp3", UriKind.Relative)),
                    Length = 60673117,
                    Type = "audio/mpeg"
                },
                ITunesFeedItemMetadata = new ITunesFeedItemMetadata
                {
                    Author = "Darrel Miller / Glenn Block",
                    SubTitle = "A Q&A show about HTTP",
                    Summary = "A Q&A show about HTTP - desc"
                },
                Guid = "http://tavis.net/feed/1/item/2/media",
                PubDate = new DateTime()
            });

            feed.FeedItems.Add(new FeedItem()
            {
                Title = "Episode 3",
                Enclosure = new Enclosure
                {
                    Link = new Uri(mp3ContainerUrl, new Uri("In%20The%20Mood%20For%20HTTP%20Episode%203.mp3", UriKind.Relative)),
                    Length = 58428736,
                    Type = "audio/mpeg"
                },
                ITunesFeedItemMetadata = new ITunesFeedItemMetadata
                {
                    Author = "Darrel Miller / Glenn Block",
                    SubTitle = "A Q&A show about HTTP",
                    Summary = "A Q&A show about HTTP - desc"
                },
                Guid = "http://tavis.net/feed/1/item/3/media",
                PubDate = new DateTime()

            });

            _Feeds.Add(1, feed);
        }

        public FeedItem GetFeedEntry(int feedId, int entryId)
        {
            var feed = _Feeds[feedId];
            return feed.FeedItems[entryId];
        }
    }
}
