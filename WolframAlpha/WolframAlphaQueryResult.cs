using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WolframAlpha
{
    [Serializable]
    public class WolframAlphaQueryResult
    {
        [XmlAttribute("success")]
        public bool Success { get; set; }

        [XmlAttribute("error")]
        public bool ErrorOccured { get; set; }

        [XmlAttribute("timing")]
        public double Timing { get; set; }

        [XmlAttribute("timedout")]
        public string TimedOut { get; set; }

        [XmlAttribute("datatypes")]
        public string DataTypes { get; set; }

        [XmlElement("pod")]
        public List<WolframAlphaPod> Pods { get; set; }
       
        [XmlIgnore]
        public int NumberOfPods 
        {
            get { return Pods.Count; } 
        }

        public double ParsingTime { get; set; }
    }
}