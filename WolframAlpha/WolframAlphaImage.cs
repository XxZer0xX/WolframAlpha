using System;
using System.Xml.Serialization;

namespace WolframAlpha
{
    [Serializable]
    public class WolframAlphaImage
    {
        [XmlAttribute("location")]
        public Uri Location { get; set; }

        [XmlAttribute("alt")]
        public string HoverText { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("width")]
        public int Width { get; set; }

        [XmlAttribute("height")]
        public int Height { get; set; }
    }
}