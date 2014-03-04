using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;


namespace WolframAlpha
{
    [Serializable]
    public class WolframAlphaPod
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("scanner")]
        public string Scanner { get; set; }

        [XmlAttribute("position")]
        public int Position { get; set; }

        [XmlAttribute("error")]
        public bool ErrorOccured { get; set; }

        [XmlElement("subpod")]
        public List<WolframAlphaSubPod> SubPods { get; set; }
        
        [XmlIgnore]
        public int NumberOfSubPods
        {
            get { return SubPods.Count; }
        }
    }
}
