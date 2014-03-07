using System.Linq;
using System.Xml.Serialization;

namespace WolframAlpha.Serializable.ResultType
{
    [XmlRoot("queryresult")]
    public class HtmlResult : QueryResult
    {
        [XmlText]
        public string Value { get; set; }
    }
}
