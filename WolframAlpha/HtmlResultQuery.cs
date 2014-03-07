using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using WolframAlpha.Serializable.ResultType;

namespace WolframAlpha
{
    public class HtmlResultQuery : WolframAlphaQuery
    {
        public HtmlResult Execute()
        {
            var result = base._execute<HtmlResult>(false);
            if (result.DefaultResult.Root != null)
                result.Value = result.DefaultResult.Root.Value;
            return result;
        }

        public HtmlResultQuery(string query)
            : base(query)
        {
            Format = QueryResultFormat.HTML;
        }
    }
}
