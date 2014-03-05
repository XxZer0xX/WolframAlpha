#region Referencing

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using WolframAlpha.Utilities;
using WolframAlpha.XmlSerializable;

#endregion

namespace WolframAlpha
{
    public class WolframAlphaEngine
    {
        public static string ApiKey 
        {
            get { return Settings.Default.ApiKey; }
            //set; 
        }
        public QueryResult QueryResult { get; private set; }
        public WolframAlphaValidationResult ValidationResult { get; private set; }

        public WolframAlphaEngine() 
        {
            //todo
        }

        public WolframAlphaValidationResult ValidateQuery(WolframAlphaQuery query)
        {
            return this._getHttpResponse<WolframAlphaValidationResult>(query);
        }

        public QueryResult LoadResponse(WolframAlphaQuery query)
        {
            return this._getHttpResponse<QueryResult>(query);
        }

        private T _getHttpResponse<T>(WolframAlphaQuery query)
        {
            if (string.IsNullOrEmpty(query.ApiKey) && string.IsNullOrEmpty(ApiKey))
                throw new NullReferenceException("API key has not been specified");

            if (query.IsAsync && !query.Format.Equals(QueryResultFormat.HTML))
                throw new Exception("Query format must be \"HTML\" for aysnc operations.");

            var request = (HttpWebRequest)WebRequest.Create(string.Format("{0}{1}", WolframAlphaQuery.MainURL, query.Parameters));

            request.KeepAlive = true;

            using (var streamReader = new StreamReader(request.GetResponse().GetResponseStream()))

                return SerializationUtility.Deserialize<T>(XDocument.Load(streamReader.ReadToEnd()));
        }

        #region not needed

        public WolframAlphaValidationResult ValidateQuery(string response)
        {
            throw new NotImplementedException();
        }

        public WolframAlphaValidationResult ValidateQuery(XDocument xmlResponse)
        {
            return SerializationUtility.Deserialize<WolframAlphaValidationResult>(xmlResponse);
        }

        /// <summary>
        ///     Not needed??
        /// </summary>
        public QueryResult LoadResponse(string response)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Not needed??
        /// </summary>
        public QueryResult LoadResponse(XDocument xmlResponse)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}


