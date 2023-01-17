using ProiectIS_BE.Common.Implementations;
using ProiectIS_BE.DAL.Entities;
using ProiectIS_BE.Service.Models;
using ProiectISBE.DAL.Migrations;

namespace ProiectIS_BE.Service.CompilingStrategies
{
    public class PythonCompileStrategy : ICompileStrategy
    {
        public string PrepareCode(ICollection<TestCase> testCases, string inputCode)
        {
            var finalCode = inputCode + "\n\n\n";

            var functionName = inputCode.Split(" ")[1].Split("(")[0];

            var sortedTestCases = testCases.ToList();
            sortedTestCases.Sort();

            foreach(var testCase in sortedTestCases)
            {
                var parameters = testCase.Parameters.Select(p => p.Value).ToList();
                parameters.Sort();

                var functionCall = CodeParser.GenerateFunctionCall(functionName, parameters);

                finalCode += 
                    $"print(\"Test {testCase.TestNumber}: \", " +
                    $"{functionCall}, " +
                    $"\"Tested for {functionCall}\")\n";
            }

            return finalCode;
        }
    }
}
