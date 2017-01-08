using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace WxrNet
{
    public static class WxrSerializer
    {
        public static string Serialize(Wxr site)
        {
            var serializer = new XmlSerializer(typeof(Wxr));
            var xmlNamespaces = new XmlSerializerNamespaces();
            var output = new StringBuilder();
            xmlNamespaces.Add("content", "http://purl.org/rss/1.0/modules/content/");
            xmlNamespaces.Add("dc", "http://purl.org/dc/elements/1.1/");
            xmlNamespaces.Add("dsq", "http://www.disqus.com/");
            xmlNamespaces.Add("wp", "http://wordpress.org/export/1.0/");

            using (var writer = XmlWriter.Create(output, new XmlWriterSettings { Indent = true }))
            {
                serializer.Serialize(writer, site, xmlNamespaces);
            }

            return output.ToString();
        }
    }
}