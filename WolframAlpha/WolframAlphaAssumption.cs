using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WolframAlpha
{
    [Serializable]
    public class WolframAlphaAssumption : IEqualityComparer<WolframAlphaAssumption>, IEquatable<WolframAlphaAssumption>
    {
        [XmlElement("word")]
        public List<string> Words { get; set; }
        public string Word 
        {
            get { return Words.First(); }
            private set { Words.Insert(0, value); }
        }

        private List<string> _waCategories;

        [XmlElement("category")]
        public List<string> Categories
        {
            get { return _waCategories ?? (_waCategories = new List<string>()); }
            set { _waCategories = value; }
        }

        public WolframAlphaAssumption()
        {
            Word = string.Empty;
        }

        public WolframAlphaAssumption(string assumption)
        {
            Words = new List<string>();
            Words.Add(assumption);
        }

        public override string ToString()
        {
            return string.Format("&assumption={0}", Word);
        }

        public bool Equals(WolframAlphaAssumption x, WolframAlphaAssumption y)
        {
            return x.Word.Equals(y.Word, StringComparison.CurrentCultureIgnoreCase);
        }

        public bool Equals(WolframAlphaAssumption x, string y)
        {
            return x.Word.Equals(y, StringComparison.CurrentCultureIgnoreCase);
        }

        public int GetHashCode(WolframAlphaAssumption obj)
        {
            throw new NotImplementedException();
        }

        public bool Equals(WolframAlphaAssumption other)
        {
            return Equals(this, other);
        }
    }
}
