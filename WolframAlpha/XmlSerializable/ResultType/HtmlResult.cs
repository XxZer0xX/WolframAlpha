using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WolframAlpha.XmlSerializable
{
    public class HtmlResult : QueryResult
    {
        public string HtmlSource { get; set; }
    }
}
