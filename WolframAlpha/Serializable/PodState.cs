#region Referencing

using System.Linq;
using System.Xml.Serialization;

#endregion

namespace WolframAlpha.Serializable
{
    public class PodState : Serializable
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("input")]
        public string Input { get; set; }
    }
}
