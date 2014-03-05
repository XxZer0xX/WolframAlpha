#region Referencing

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

#endregion

namespace WolframAlpha.XmlSerializable
{
    [Serializable]
    public class Pod
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("scanner")]
        public string Scanner { get; set; }

        [XmlAttribute("position")]
        public int Position { get; set; }

        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("error")]
        public bool ErrorOccured { get; set; }

        [XmlElement("subpod")]
        public List<SubPod> SubPods { get; set; }

        [XmlElement("states")]
        public List<PodState> States { get; set; }

        [XmlIgnore]
        public int NumberOfSubPods
        {
            get { return this.SubPods.Count; }
        }
    }
}
