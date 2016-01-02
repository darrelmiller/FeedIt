using FeedIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedIt.Services
{
    public class PodcastService
    {

        private Dictionary<int, Podcast> _Podcasts = new Dictionary<int, Podcast>();
        public PodcastService()
        {
            SeedData();
        }

        private void SeedData()
        {
            var podcast = new Podcast
            {
                Title = "In the mood for HTTP",
                Description = "A Q&A for HTTP",
                Episodes = new List<Episode> {
                    new Episode {
                        Title = "Episode 1"
                    }
                }
            };
            _Podcasts.Add(1, podcast);
        }

        public Feed GetFeedFromPodcast(int podcastId)
        {
            var podcast = GetPodcast(podcastId);

            return ConvertPodcastToFeed(podcast);
        }

        private Podcast GetPodcast(int podcastId)
        {
            return _Podcasts[podcastId];
        }

        private Feed ConvertPodcastToFeed(Podcast podcast )
        {
            var feed = new Feed {
                Title = podcast.Title,
                Language = "en-US",
                Description = podcast.Description
            };

            foreach (var episode in podcast.Episodes)
            {
                var item = new FeedItem
                {
                    Title = episode.Title,
                    Description = episode.Description,
                    PubDate = episode.PubDate
                };
                feed.FeedItems.Add(item);
            }
            return new Feed();
        }
    }
}
