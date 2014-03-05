using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WolframAlpha.XmlSerializable.ResultType
{
    public class XmlResult : QueryResult
    {
        [XmlIgnore]
        public XDocument XmlDocument { get; set; }
    }
}
