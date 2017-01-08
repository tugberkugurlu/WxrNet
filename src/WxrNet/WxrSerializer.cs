using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace WxrNet
{
    public static class WxrSerializer
    {
        private static readonly XmlSerializer _serializer;
        private static readonly XmlSerializerNamespaces _xmlNamespaces;

        static WxrSerializer()
        {
            var serializer = new XmlSerializer(typeof(Wxr));
            var xmlNamespaces = new XmlSerializerNamespaces();
            var output = new StringBuilder();
            xmlNamespaces.Add("content", "http://purl.org/rss/1.0/modules/content/");
            xmlNamespaces.Add("dc", "http://purl.org/dc/elements/1.1/");
            xmlNamespaces.Add("dsq", "http://www.disqus.com/");
            xmlNamespaces.Add("wp", "http://wordpress.org/export/1.0/");

            _serializer = serializer;
            _xmlNamespaces = xmlNamespaces;
        }

        public static string Serialize(Wxr site)
        {
            var output = new StringBuilder();

            using (var writer = XmlWriter.Create(output, new XmlWriterSettings { Indent = true }))
            {
                _serializer.Serialize(writer, site, _xmlNamespaces);
            }

            return output.ToString();
        }
    }
}