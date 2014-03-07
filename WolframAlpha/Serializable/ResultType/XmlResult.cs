using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WolframAlpha.Serializable.ResultType
{
    public class XmlResult : QueryResult
    {
        [XmlIgnore]
        public XDocument XmlDocument { get; set; }
    }
}
