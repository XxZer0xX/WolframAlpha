#region Referencing

using System.Linq;
using System.Xml.Serialization;

#endregion

namespace WolframAlpha.XmlSerializable
{
    public class QueryResultSource : Serializable
    {
        [XmlAttribute("url")]
        public string Url { get; set; }

        [XmlAttribute("text")]
        public string DataSource { get; set; }
    }
}
