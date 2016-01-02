using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace FeedIt
{
    public class Enclosure
    {
        public Uri Link { get; set; }
        public int Length { get; set; }
        public string Type { get; set; }
    }
    public class FeedItem
    {
        public string Title { get; set; }
        public Uri Link { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Comments { get; set; }
        public Enclosure Enclosure { get; set; }
        public string Guid { get; set; }
        public string Source { get; set; }
        public DateTime PubDate { get; set; }
        public ITunesFeedItemMetadata ITunesFeedItemMetadata { get; set; }


        public void WriteTo(XmlWriter xw)
        {
            xw.WriteStartElement("item");
            if (!string.IsNullOrWhiteSpace(Title)) xw.WriteElementString("title", this.Title);
            if (!string.IsNullOrWhiteSpace(Description)) xw.WriteElementString("description", this.Description);
            if (Link != null) xw.WriteElementString("link", this.Link.AbsoluteUri);
            if (Enclosure != null)
            {
                xw.WriteStartElement("enclosure");
                xw.WriteAttributeString("url", this.Enclosure.Link.AbsoluteUri);
                xw.WriteAttributeString("length", this.Enclosure.Length.ToString());
                xw.WriteAttributeString("type", this.Enclosure.Type);
                xw.WriteEndElement();
            }
            if (!string.IsNullOrWhiteSpace(Guid)) xw.WriteElementString("guid", this.Guid);
            if (!string.IsNullOrWhiteSpace(Source)) xw.WriteElementString("source", this.Source);
            if (PubDate != DateTime.MinValue) xw.WriteElementString("pubDate", PubDate.ToString());
            if (ITunesFeedItemMetadata != null)
            {
                if (!string.IsNullOrWhiteSpace(ITunesFeedItemMetadata.Author)) xw.WriteElementString("author", Feed.ITunesNS, ITunesFeedItemMetadata.Author);
                if (!string.IsNullOrWhiteSpace(ITunesFeedItemMetadata.SubTitle)) xw.WriteElementString("subtitle", Feed.ITunesNS, ITunesFeedItemMetadata.SubTitle);
                if (!string.IsNullOrWhiteSpace(ITunesFeedItemMetadata.Summary)) xw.WriteElementString("summary", Feed.ITunesNS, ITunesFeedItemMetadata.Summary);
                if (ITunesFeedItemMetadata.Image != null) xw.WriteElementString("summary", Feed.ITunesNS, ITunesFeedItemMetadata.Image.AbsoluteUri);
                if (ITunesFeedItemMetadata.Duration.Ticks > 0) xw.WriteElementString("duration", Feed.ITunesNS, ITunesFeedItemMetadata.Duration.ToString("c"));
            }

            xw.WriteEndElement();

        }
    }

}