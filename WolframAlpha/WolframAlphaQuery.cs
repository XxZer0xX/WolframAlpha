using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WolframAlpha
{
    
    public class WolframAlphaQuery
    {
        public const string MainURL = "http://api.wolframalpha.com/v1/query.jsp";
        private const string _substitutionKey = "&substitution=";
        private const string _podTitleKey = "&podtitle=";

        #region Properties

        public IList<string> Substitutions { get; private set; }

        public IList<WolframAlphaAssumption> Assumptions { get; private set; }
       
        public IList<string> PodTitles { get; private set; }

        public string ApiKey 
        {
            get { return WolframAlphaEngine.ApiKey; }
            //set { WolframAlphaEngine.ApiKey = value; }
        }

        public string Format { get; set; }
        public string Query { get; set; }
        public bool MoreOutput { get; set; }
        public bool IsAsync { get; set; }
        public bool AllowCaching { get; set; }
        public int TimeLimit { get; set; }

        public string FullQueryString
        {
            get
            {
                return string.Format(
                    "?appid={0}&moreoutput={1}&timelimit={2}&format={3}&input={4}", 
                    ApiKey, MoreOutput, TimeLimit, Format,
                    string.Format("{0}{1}{2}", Query, 
                        Assumptions.Select(a => a.ToString()).Aggregate((a,b) => a+b), 
                        Substitutions.Aggregate((a,b) => string.Format("{0}{1}{0}{2}",_substitutionKey,a,b) )));
            }
        }
      
        #endregion

        #region Constructor

        public WolframAlphaQuery()
        {
            Substitutions = new List<string>();
            PodTitles = new List<string>();
            Assumptions = new List<WolframAlphaAssumption>();
            //ApiKey = string.Empty;
            Format = string.Empty;
            Query = string.Empty;
        }

        #endregion

        #region Methods

        public void AddPodTitle(string podTitle, bool allowDuplicates = false)
        {
            var encodedPodTitle = HttpUtility.UrlEncode(podTitle);
            if (!PodTitles.Any(title
                => title.Equals(encodedPodTitle, StringComparison.CurrentCultureIgnoreCase))
                || allowDuplicates)
                PodTitles.Add(encodedPodTitle);
        }

        public void AddSubstitution(string substitution, bool allowDuplicates = false)
        {
            var encodedSubstitution = HttpUtility.UrlEncode(substitution);
            if (!Substitutions.Any(sub
                => sub.Equals(encodedSubstitution, StringComparison.CurrentCultureIgnoreCase)) 
                || allowDuplicates)
                Substitutions.Add(encodedSubstitution);
        }

        public void AddAssumption(string word, bool allowDuplicates = false)
        {
            AddAssumption(new WolframAlphaAssumption(HttpUtility.UrlEncode(word)), allowDuplicates);
        }

        public void AddAssumption(WolframAlphaAssumption assumption, bool allowDuplicates = false)
        {
            if (!Assumptions.Contains(assumption) || allowDuplicates )
                Assumptions.Add(assumption);
        }

        #endregion

    }
}
