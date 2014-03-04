using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WolframAlpha
{
    public class WolframAlphaAssumption
    {
        public string Word { get; set; }

        private IEnumerable<string> _waCategories;
        public IEnumerable<string> Categories
        {
            get { return _waCategories ?? (_waCategories = new List<string>()); }
            set { _waCategories = value; }
        }

        public WolframAlphaAssumption()
        {
            Word = string.Empty;
        }
    }
}
