using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace WxrNet
{
    public struct ZeroOne : IXmlSerializable 
    {
        private bool _value;

        public ZeroOne(bool value)
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
            _value = (reader.ReadElementContentAsString() == "1");
        }

        public void WriteXml(XmlWriter writer) 
        {
            writer.WriteString((Value) ? "1" : "0");
        }

        public static implicit operator bool(ZeroOne value) => value.Value;
        public static implicit operator ZeroOne(bool value) => new ZeroOne(value);
    }
}