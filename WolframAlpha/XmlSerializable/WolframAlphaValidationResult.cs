#region Referencing

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

#endregion

namespace WolframAlpha.XmlSerializable
{
    [Serializable]
    public class WolframAlphaValidationResult
    {
        [XmlAttribute("success")]
        public bool Success { get; set; }

        [XmlAttribute("error")]
        public bool ErrorOccured { get; set; }

        [XmlAttribute("timing")]
        public double Timing { get; set; }

        [XmlElement("parseddata")]
        public List<string> ParsedDataList { get; set; }

        [XmlElement("assumptions")]
        public List<Assumption> Assumptions { get; set; }
       
        [XmlIgnore]
        public string ParseData
        {
            get { return this.ParsedDataList.First(); }
        }
    }
}