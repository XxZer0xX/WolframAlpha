using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Web;
using WolframAlpha.Utilities;

namespace WolframAlpha
{
    
    public class WolframAlphaQuery
    {
        private const string _mainRoot = "http://api.wolframalpha.com/v1/query.jsp";

        #region Properties

        private IDictionary<string, IList<string>> UriParams
        {
            get 
            {
                return new Dictionary<string, IList<string>>
                {
                    {"&substitution=",Substitutions},
                    {"&assumptions=", Assumptions},
                    {"&podtitle=",PodTitles}
                }; 
            }
        }

        public string ApiKey { get; set; }
        public string Format { get; set; }
        public string Query { get; set; }
        public bool MoreOutput { get; set; }
        public bool Asynchronous { get; set; }
        public bool AllowCaching { get; set; }
        public int TimeLimit { get; set; }
        public IList<string> Substitutions { get; private set; }
        public IList<string> Assumptions { get; private set; }
        public IList<string> PodTitles { get; private set; }

        public string FullQueryString
        {get
            {
                var strBuilder = new StringBuilder();
                strBuilder.
                return string.Format(
                    "?appid={0}&moreoutput={1}&timelimit={2}&format={3}&input={4}" ,
                    ApiKey, MoreOutput,
                    TimeLimit, Format,
                    string.Format(
                        "{0}{1}{2}",
                        Query, _assumption,
                       _substitution));     
            }
        }

        #endregion

        #region Constructor

        public WolframAlphaQuery()
        {
            Substitutions = new List<string>();
            PodTitles = new List<string>();
            Assumptions = new List<string>();
            ApiKey = string.Empty;
            Format = string.Empty;
            Query = string.Empty;
        }

        #endregion

        #region Methods

        public void AddPodTitle(string podtitle, bool checkForDuplicates = false)
        {
            if (!checkForDuplicates || !_podTitle.ContainsCaseIgnore(string.Format("&podtitle={0}", HttpUtility.UrlEncode(podtitle))))
                _podTitle += string.Format("&podtitle={0}", HttpUtility.UrlEncode(podtitle));
        }

        public void AddSubstitution(string substitution, bool checkForDuplicates = false)
        {
            if (!checkForDuplicates || !_podTitle.ContainsCaseIgnore(string.Format("&substitution={0}", HttpUtility.UrlEncode(substitution))))
                _podTitle += string.Format("&substitution={0}", HttpUtility.UrlEncode(substitution));
        }

        public void AddAsssumption(string assumption, bool checkForDuplicates = false)
        {
            if (!checkForDuplicates || !_podTitle.ContainsCaseIgnore(string.Format("&asssumption={0}", HttpUtility.UrlEncode(assumption))))
                _podTitle += string.Format("&asssumption={0}", HttpUtility.UrlEncode(assumption));
        }

        public void AddAssumption(WolframAlphaAssumption assumption, bool checkForDuplicates = false)
        {
            if (!checkForDuplicates || !_podTitle.ContainsCaseIgnore(string.Format("&asssumption={0}", HttpUtility.UrlEncode(assumption.Word))))
                _podTitle += string.Format("&asssumption={0}", HttpUtility.UrlEncode(assumption.Word));
        }

        #endregion

    }
}
