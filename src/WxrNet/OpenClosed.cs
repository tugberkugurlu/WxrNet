using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace WxrNet
{
    public struct OpenClosed : IXmlSerializable 
    {
        private bool _value;

        public OpenClosed(bool value)
        {
            _value = value;
        }

        private bool Value 
        { 
            get 
            { 
                return _value; 
            }
        }

        public XmlSchema GetSchema() { return null; }

        public void ReadXml(XmlReader reader) 
        {
            _value = (reader.ReadElementContentAsString() == "open");
        }

        public void WriteXml(XmlWriter writer) 
        {
            writer.WriteString((Value) ? "open" : "closed");
        }

        public static implicit operator bool(OpenClosed value) => value.Value;
        public static implicit operator OpenClosed(bool value) => new OpenClosed(value);
    }
}