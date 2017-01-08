using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace WxrNet
{
    [Serializable]
    public class Site
    {
        [XmlElement("item", typeof(Post))]
        public List<Post> Posts { get; set; }
    }
}