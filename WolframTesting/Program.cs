using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolframTesting
{
    public class Program
    {
        private static void Main( string[] args )
        {
            var result = new WolframAlpha.GenericQuery("who is bugs bunny").Execute(WolframAlpha.QueryResultFormat.HTML,false,false,true,false);
        }
    }
}
