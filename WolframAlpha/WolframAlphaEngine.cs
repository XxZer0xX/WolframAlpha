using System;
using System.IO;
using System.Net;
using System.Web;
using System.Xml.Linq;
using WolframAlpha.Utilities;

namespace WolframAlpha
{
    public class WolframAlphaEngine
    {
        public static string ApiKey 
        {
            get { return WolframAlpha.Settings.Default.ApiKey; }
            //set; 
        }
        public WolframAlphaQueryResult QueryResult { get; private set; }
        public WolframAlphaValidationResult ValidationResult { get; private set; }

        public WolframAlphaEngine() 
        {
            //todo
        }

        public WolframAlphaValidationResult ValidateQuery(WolframAlphaQuery query)
        {
            return _getHttpResponse<WolframAlphaValidationResult>(query);
        }

        public WolframAlphaQueryResult LoadResponse(WolframAlphaQuery query)
        {
            return _getHttpResponse<WolframAlphaQueryResult>(query);
        }

        private T _getHttpResponse<T>(WolframAlphaQuery query)
        {
            if (string.IsNullOrEmpty(query.ApiKey) && string.IsNullOrEmpty(ApiKey))
                throw new NullReferenceException("API key has not been specified");

            if (query.IsAsync && !query.Format.Equals(WolframAlphaQueryFormat.HTML))
                throw new Exception("Query format must be \"HTML\" for aysnc operations.");

            var request = (HttpWebRequest)WebRequest.Create(string.Format("", WolframAlphaQuery.MainURL, query.FullQueryString));

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
        public WolframAlphaQueryResult LoadResponse(string response)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Not needed??
        /// </summary>
        public WolframAlphaQueryResult LoadResponse(XDocument xmlResponse)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}


