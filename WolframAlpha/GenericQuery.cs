#region Referencing

using System.Linq;

#endregion

namespace WolframAlpha
{
    public class GenericQuery : WolframAlphaQuery
    {
        public GenericQuery(string query) : base(query) { } 
    }
}
