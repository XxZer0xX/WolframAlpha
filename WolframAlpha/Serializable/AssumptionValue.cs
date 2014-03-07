#region Referencing

using System.Linq;
using System.Xml.Serialization;

#endregion

namespace WolframAlpha.Serializable
{
    public class AssumptionValue : Serializable
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("desc")]
        public string Description { get; set; }

        [XmlAttribute("input")]
        public string Input { get; set; }

        [XmlAttribute("word")]
        public string Word { get; set; }
    }
}
