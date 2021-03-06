﻿#define Debug

#region Referencing

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Linq;
using WolframAlpha.Serializable;
using WolframAlpha.Serializable.ResultType;
using WolframAlpha.Utilities;

#endregion

namespace WolframAlpha
{

    public abstract class WolframAlphaQuery
    {
        public const string MainURL = "http://api.wolframalpha.com/v1/query.jsp";
        private const string _substitutionKey = "&substitution=";
        private const string _podTitleKey = "&podtitle=";

        #region Properties

        public IList<int> PodsAtIndexs { get; set; }

        public IList<string> PodsToInclude { get; set; }

        public IList<string> PodsToExclude { get; set; }

        public IList<string> Substitutions { get; set; }

        public IList<Assumption> Assumptions { get; set; }

        public IList<string> PodTitles { get; private set; }

        public string ApiKey
        {
            get
            {
                //WolframAlphaEngine.ApiKey;
                return Settings.Default.ApiKey;
            }
            //set { WolframAlphaEngine.ApiKey = value; }
        }

        public string Format { get; set; }
        public string Query { get; set; }
        public bool MoreOutput { get; set; }
        public bool IsAsync { get; set; }
        public bool AllowCaching { get; set; }
        public int TimeLimit { get; set; }

        public string Parameters
        {
            get
            {
                return string.Format(
                    "?appid={0}&moreoutput={1}&timelimit={2}&input={3}",
                    this.ApiKey, this.MoreOutput, this.TimeLimit,
                    string.Format("{0}{1}{2}{3}{4}", this.Query,

                    this.Assumptions.Count > 0
                    ? this.Assumptions.Select(a => a.ToString()).Aggregate((a, b) => a + b)
                    : string.Empty,

                    this.Substitutions.Count > 0
                    ? this.Substitutions.Aggregate((a, b) => string.Format("{0}{1}{0}{2}", _substitutionKey, a, b))
                    : string.Empty,

                    this.PodTitles.Count > 0
                    ? this.PodTitles.Aggregate((a, b) => string.Format("{0}{1}{0}{2}", _podTitleKey, a, b))
                    : string.Empty,

                    "&format=" + this.Format));
            }
        }

        #endregion

        #region Constructor

        protected WolframAlphaQuery(string query)
            : this()
        {
            this.Query = query;
        }

        protected WolframAlphaQuery()
        {
            this.Substitutions = new List<string>();
            this.PodTitles = new List<string>();
            this.Assumptions = new List<Assumption>();
            this.PodsAtIndexs = new List<int>();
            this.PodsToInclude = new List<string>();
            this.PodsToExclude = new List<string>();
        }

        #endregion

        #region Methods

        public void AddPodTitle(string podTitle)
        {
            var encodedPodTitle = HttpUtility.UrlEncode(podTitle);
            if (!this.PodTitles.Any(title
                => title.Equals(encodedPodTitle, StringComparison.CurrentCultureIgnoreCase)))
                this.PodTitles.Add(encodedPodTitle);
        }

        public void AddSubstitution(string substitution)
        {
            var encodedSubstitution = HttpUtility.UrlEncode(substitution);
            if (!this.Substitutions.Any(sub
                => sub.Equals(encodedSubstitution, StringComparison.CurrentCultureIgnoreCase)))
                this.Substitutions.Add(encodedSubstitution);
        }

        public void IncludePod(string podId)
        {
            throw new NotImplementedException();
        }

        public void ReturnPodsAtIndex(params int[] indexs)
        {
            throw new NotImplementedException();
        }

        public void ExcludePod(string podId)
        {
            throw new NotImplementedException();
        }

        #region Execute Overloads

        protected T _execute<T>(bool keepAlive, bool isAsync = false, bool moreOutput = false, bool allowCaching = false) where T : QueryResult
        {
            if (string.IsNullOrEmpty(Query))
                return null;

            this.IsAsync = isAsync;
            this.MoreOutput = moreOutput;
            this.AllowCaching = allowCaching;

            if (string.IsNullOrEmpty(this.ApiKey))
                throw new NullReferenceException("API key has not been specified");

            var request = (HttpWebRequest)WebRequest.Create(string.Format("{0}{1}", MainURL, this.Parameters));

            request.KeepAlive = keepAlive;

            using (var streamReader = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                var xdoc = XDocument.Parse(streamReader.ReadToEnd());


                var obj = SerializationUtility.Deserialize<T>(xdoc);
                obj.DefaultResult = xdoc;
                return obj;

            }
        }

        //public virtual T Execute<T>(bool keepAlive) where T : QueryResult
        //{
        //    return _execute<T>(keepAlive);
        //}

        //public virtual T Execute<T>(bool keepAlive, bool moreOutput) where T : QueryResult
        //{
        //    return _execute<T>(keepAlive, moreOutput: moreOutput);
        //}

        //public virtual T Execute<T>(bool keepAlive, bool moreOutput, bool allowCaching) where T : QueryResult
        //{
        //    return _execute<T>(keepAlive, moreOutput: moreOutput, allowCaching: allowCaching);
        //}

        #endregion

        #endregion

    }
}
