using System;
using System.Globalization;
using System.Linq;

namespace WolframAlpha.Utilities
{
    public static class Util
    {
        public static bool ContainsCaseIgnore(this string str, string part)
        {
            var compInfo = CultureInfo.CurrentUICulture.CompareInfo;
            return compInfo.IndexOf(str, part, CompareOptions.IgnoreCase) > 0;
        }

        public static string RemoveParameterHeader(string parameter)
        {
            if (!parameter.Contains('='))
                throw new Exception("Malformed uri parameter", new Exception(string.Format(parameter)));
            return parameter.Remove(0, parameter.IndexOf('='));
        }
    }

}
