using FeedIt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace FeedItTests
{
    public class FeedTests
    {

        [Fact]
        public async Task SimplestFeed()
        {
            var feed = new Feed()
            { Title = "This is my feed",
              Link = new Uri("http://example.org/here"),
              Description = "This is the description of my feed"
            };

            var stream = new MemoryStream();
            await feed.WriteToStreamAsync(stream);

            stream.Position = 0;
            var x = XDocument.Load(stream);
            Assert.NotNull(x.Element("rss"));
            Assert.NotNull(x.Element("rss").Element("channel"));
            Assert.NotNull(x.Element("rss").Element("channel").Element("title"));
            Assert.NotNull(x.Element("rss").Element("channel").Element("link"));
            Assert.NotNull(x.Element("rss").Element("channel").Element("description"));
        }

        [Fact]
        public async Task SimplestFeedWithItems()
        {
            var feed = new Feed()
            {
                Title = "This is my feed",
                Link = new Uri("http://example.org/here"),
                Description = "This is the description of my feed"
            };

            feed.FeedItems.Add(new FeedItem() { Title = "This is an item in the feed" });

            var stream = new MemoryStream();
            await feed.WriteToStreamAsync(stream);
            stream.Position = 0;
            stream.Position = 0;
            var x = XDocument.Load(stream);
            Assert.NotNull(x.Element("rss"));
            Assert.NotNull(x.Element("rss").Element("channel"));
            Assert.NotNull(x.Element("rss").Element("channel").Element("item"));
            Assert.NotNull(x.Element("rss").Element("channel").Element("item").Element("title"));

        }

        [Fact]
        public async Task FeedWithItemsAndItunesdata()
        {
            var feed = new Feed()
            {
                Title = "This is my feed",
                Link = new Uri("http://example.org/here"),
                Description = "This is the description of my feed",
                ITunesFeedMetaData = new ITunesFeedMetadata {
                    SubTitle = "Here is a subtitle",
                    Author = "Dave Brown",
                    Summary = "The summary"
                }
                
            };

            feed.FeedItems.Add(new FeedItem() {
                Title = "This is an item in the feed",
                ITunesFeedItemMetadata = new ITunesFeedItemMetadata
                {
                    Author = "Bob",
                    Duration = new TimeSpan(1,2,0),
                    Image = new Uri("http://example.org/image.gif")
                }
                
            });

            var stream = new MemoryStream();
            await feed.WriteToStreamAsync(stream);
            stream.Position = 0;
            var sr = new StreamReader(stream);
            var output = sr.ReadToEnd();

            Assert.NotNull(output);
        }
    }
}
