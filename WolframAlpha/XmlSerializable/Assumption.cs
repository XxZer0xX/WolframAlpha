#region Referencing

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

#endregion

namespace WolframAlpha.XmlSerializable
{
    public class Assumption : Serializable, IEqualityComparer<Assumption>, IEquatable<Assumption>
    {
        [XmlElement("word")]
        public List<string> Words { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        [XmlIgnore]
        public string Word 
        {
            get { return this.Words.First(); }
            private set { this.Words.Insert(0, value); }
        }

        private List<string> _waCategories;

        [XmlElement("category")]
        public List<string> Categories
        {
            get { return this._waCategories ?? (this._waCategories = new List<string>()); }
            set { this._waCategories = value; }
        }

        public Assumption()
        {
            this.Word = string.Empty;
        }

        public Assumption(string assumption)
        {
            this.Words = new List<string> { assumption };
        }

        public override string ToString()
        {
            return string.Format("&assumption={0}", this.Word);
        }

        public bool Equals(Assumption x, Assumption y)
        {
            return x.Word.Equals(y.Word, StringComparison.CurrentCultureIgnoreCase);
        }

        public bool Equals(Assumption x, string y)
        {
            return x.Word.Equals(y, StringComparison.CurrentCultureIgnoreCase);
        }

        public int GetHashCode(Assumption obj)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Assumption other)
        {
            return this.Equals(this, other);
        }
    }
}
