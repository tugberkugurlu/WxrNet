using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

namespace WxrNet
{
    [Serializable]
    public class Post
    {
        private const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        private string _content;

        [XmlElement(ElementName = "thread_identifier", Namespace = "http://www.disqus.com/")]
        public string Id { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("link")]
        public string Link { get; set; }

        [XmlIgnore]
        public DateTime PostDateInGmt { get; set; }

        [XmlElement(ElementName = "post_date_gmt", Namespace = "http://wordpress.org/export/1.0/")]
        public string CommentDateInGmtString 
        {
            get 
            {
                return PostDateInGmt.ToString(DateTimeFormat);
            }

            set 
            {
                PostDateInGmt = DateTime.ParseExact(value, DateTimeFormat, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement(ElementName = "encoded", Namespace = "http://purl.org/rss/1.0/modules/content/")]
        public XmlCDataSection Content { get; set; }

        [XmlElement(ElementName = "comment_status", Namespace = "http://wordpress.org/export/1.0/")]
        public OpenClosed IsCommentsOpen { get; set; }

        [XmlElement(ElementName = "comment", Namespace = "http://wordpress.org/export/1.0/", Type = typeof(Comment))]
        public List<Comment> Comments { get; set; }
    }
}