#region Referencing

using System.Linq;
using System.Xml.Serialization;

#endregion

namespace WolframAlpha.Serializable
{
    public class Image : Serializable
    {
        [XmlAttribute("location")]
        public string Location { get; set; }

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