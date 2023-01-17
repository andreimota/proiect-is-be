using ProiectIS_BE.Common.Implementations;
using ProiectIS_BE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.Service.CompilingStrategies
{
    public class JavaScriptCompileStrategy : ICompileStrategy
    {
        public string PrepareCode(ICollection<TestCase> testCases, string inputCode)
        {
            var finalCode = inputCode + "\n\n\n";

            var functionName = inputCode.Split(" ")[1].Split("(")[0];

            var sortedTestCases = testCases.ToList();
            sortedTestCases.Sort();

            foreach (var testCase in sortedTestCases)
            {
                var parameters = testCase.Parameters.Select(p => p.Value).ToList();
                parameters.Sort();

                var functionCall = CodeParser.GenerateFunctionCall(functionName, parameters);

                finalCode +=
                    $"console.log(\"Test {testCase.TestNumber}: \", " +
                    $"{functionCall}, " +
                    $"\"Tested for {functionCall}\")\n";
            }

            return finalCode;
        }
    }
}
