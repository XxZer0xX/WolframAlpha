#region Referencing

using System;
using System.Linq;
using System.Xml.Serialization;

#endregion

namespace WolframAlpha.XmlSerializable
{
    [Serializable]
    public class SubPod
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlElement("plaintext")]
        public string Text { get; set; }
        
        [XmlElement("img")]
        public WolframAlphaImage PodImage { get; set; }
    }
}