using System;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;

namespace WxrNet
{
    [Serializable]
    public class Comment
    {
        private const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

        [XmlElement("comment_id")]
        public string Id { get; set; }

        [XmlElement("comment_content")]
        public XmlCDataSection Content { get; set; }

        [XmlElement("comment_author")]
        public string AuthorFullName { get; set; }

        [XmlElement("comment_author_email")]
        public string AuthorEmail { get; set; }

        [XmlElement("comment_author_url")]
        public string AuthorUrl { get; set; }

        [XmlElement("comment_author_IP")]
        public string IpAddress { get; set; }

        [XmlIgnore]
        public DateTime CommentDateInGmt { get; set; }

        [XmlElement("comment_date_gmt")]
        public string CommentDateInGmtString 
        {
            get 
            {
                return CommentDateInGmt.ToString(DateTimeFormat);
            }

            set 
            {
                CommentDateInGmt = DateTime.ParseExact(value, DateTimeFormat, CultureInfo.InvariantCulture);
            }
        }

        [XmlElement("comment_approved")]
        public ZeroOne IsApproved { get; set; }
    }
}