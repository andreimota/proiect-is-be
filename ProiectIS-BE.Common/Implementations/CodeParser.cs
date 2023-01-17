using ProiectIS_BE.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.Common.Implementations
{
    public static class CodeParser
    {
        public static string GenerateFunctionCall(string functionName, List<string> parameters)
        {
            string call = "";

            call = call + $"{functionName}(";

            foreach(var parameter in parameters)
            {
                call = call + $"{parameter}, ";
            }

            call = call.Remove( call.Length - 2 );
            call = call + ')';

            return call;
        }

        public static string RemoveWhiteSpaces(string text)
        {
            return String.Concat(text.Where(c => !Char.IsWhiteSpace(c)));
        }
    }
}
