using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using WolframAlpha.Serializable.ResultType;

namespace WolframAlpha
{
    public class XmlResultQuery: WolframAlphaQuery
    {
        public QueryResult Execute()
        {
             return base._execute<QueryResult>( false );
        }
    }
}
