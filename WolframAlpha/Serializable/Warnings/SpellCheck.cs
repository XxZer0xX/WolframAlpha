#region Referencing

using System.Linq;
using System.Xml.Serialization;

#endregion

namespace WolframAlpha.Serializable.Warnings
{
    public class SpellCheck : Warning
    {
        [XmlAttribute("word")]
        public string ErroredWord { get; set; }

        [XmlAttribute("suggestion")]
        public string Suggestion { get; set; }

        [XmlAttribute("text")]
        public string InterpretedAs { get; set; }
    }
}
