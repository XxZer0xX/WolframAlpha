#region Referencing

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using WolframAlpha.Collections;

#endregion

namespace WolframAlpha.XmlSerializable
{
    [Serializable]
    [XmlRoot("queryresult")]
    public abstract class QueryResult
    {
        [XmlAttribute("success")]
        public bool Success { get; set; }

        [XmlAttribute("error")]
        public bool ErrorOccured { get; set; }

        [XmlAttribute("timing")]
        public double Timing { get; set; }

        [XmlAttribute("timedout")]
        public string TimedOut { get; set; }

        [XmlAttribute("parsetiming")]
        public double ParsingTime { get; set; }

        [XmlAttribute("parsetimedout")]
        public bool ParseTimedOut { get; set; }

        [XmlAttribute("datatypes")]
        public string DataTypes { get; set; }

        [XmlAttribute("recalculate")]
        public string ReCalculate { get; set; }

        [XmlElement("pod")]
        public List<Pod> Pods { get; set; }

        [XmlElement("sources")]
        public List<QueryResultSource> Sources { get; set; }

        [XmlElement("warngings")]
        public WarningsList Warnings { get; set; }

        [XmlIgnore]
        public int NumberOfPods 
        {
            get { return this.Pods.Count; } 
        } 
    }
}