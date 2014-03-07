#region Referencing

using System;
using System.Linq;
using System.Xml.Serialization;

#endregion

namespace WolframAlpha.Serializable
{
    [Serializable]
    public class SubPod
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlElement("plaintext")]
        public string Text { get; set; }
        
        [XmlElement("img")]
        public Image PodImage { get; set; }
    }
}