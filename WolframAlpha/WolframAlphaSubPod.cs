using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WolframAlpha
{
    [Serializable]
    public class WolframAlphaSubPod
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlElement("plaintext")]
        public string Text { get; set; }
        
        [XmlElement("img")]
        public WolframAlphaImage PodImage { get; set; }
    }
}