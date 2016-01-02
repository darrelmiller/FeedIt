using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace FeedIt
{
    public class Feed
    {
        public const string ITunesNS = "http://www.itunes.com/dtds/podcast-1.0.dtd";

        public string Title { get; set; }
        public Uri Link { get; set; }
        public string Description { get; set; }

        public string Copyright { get; set; }
        public string PubDate { get; set; }
        public string ManagingEditor { get; set; }
        public string WebMaster { get; set; }
        public ITunesFeedMetadata ITunesFeedMetaData { get; set; }
        public string Language { get; set; }

        public List<FeedItem> FeedItems { get; set; }
        public Feed()
        {
            FeedItems = new List<FeedItem>();
        }

        public List<Exception> Validate()
        {
            var list = new List<Exception>();
            if (string.IsNullOrWhiteSpace(Title)) list.Add(new ArgumentNullException("Feed Title cannot be null"));
            if (string.IsNullOrWhiteSpace(Description)) list.Add(new ArgumentNullException("Feed Description cannot be null"));
            if (Link == null) list.Add(new ArgumentNullException("Feed Link cannot be null"));

            return list;
        }

        public async Task WriteToStreamAsync(Stream stream)
        {
            var errors = Validate();
            if (errors.Count > 0) throw new AggregateException(errors.ToArray());

            var xw = XmlWriter.Create(stream, new XmlWriterSettings() { Async = true });

            WriteTo(xw);

            await xw.FlushAsync();

        }

        private void WriteTo(XmlWriter xw)
        {

            xw.WriteStartDocument();
            xw.WriteStartElement("rss");
            xw.WriteAttributeString("xmlns", "itunes", null, ITunesNS);
            xw.WriteAttributeString("version", "2.0");

            xw.WriteStartElement("channel");
            xw.WriteElementString("title", this.Title);
            xw.WriteElementString("link", this.Link.AbsoluteUri);
            xw.WriteElementString("description", this.Description);
            if (!string.IsNullOrWhiteSpace(Language)) xw.WriteElementString("language", Language);

            if (ITunesFeedMetaData != null)
            {
                xw.WriteElementString("subtitle", ITunesNS, ITunesFeedMetaData.SubTitle);
                xw.WriteElementString("author", ITunesNS, ITunesFeedMetaData.Author);
                xw.WriteElementString("summary", ITunesNS, ITunesFeedMetaData.Summary);
                if (this.ITunesFeedMetaData.Image != null)
                {
                    xw.WriteStartElement("image", ITunesNS);
                    xw.WriteAttributeString("href", ITunesFeedMetaData.Image.AbsoluteUri);
                    xw.WriteEndElement();
                }
                //Owner
                xw.WriteStartElement("category", ITunesNS);
                xw.WriteAttributeString("text", "Technology");
                xw.WriteStartElement("category", ITunesNS);
                xw.WriteAttributeString("text", "Software How-To");
                xw.WriteEndElement();

                xw.WriteEndElement();
            }
            foreach (var item in FeedItems)
            {
                item.WriteTo(xw);
            }


            xw.WriteEndElement();
            xw.WriteEndElement();
            xw.WriteEndDocument();
        }
    }
}