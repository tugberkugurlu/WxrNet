using System;
using System.Xml.Serialization;

namespace WxrNet
{
    [Serializable]
    [XmlRoot("rss")]
    public class Wxr
    {
        [XmlElement("channel", typeof(Site))]
        public Site Site { get; set; }
    }
}