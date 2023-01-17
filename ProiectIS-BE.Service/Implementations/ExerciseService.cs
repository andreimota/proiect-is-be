using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using ProiectIS_BE.Common.Implementations;
using ProiectIS_BE.Common.Interfaces;
using ProiectIS_BE.Common.Models;
using ProiectIS_BE.DAL.Entities;
using ProiectIS_BE.Data;
using ProiectIS_BE.Service.CompilingStrategies;
using ProiectIS_BE.Service.Interfaces;
using ProiectIS_BE.Service.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.Service.Implementations
{
    public class ExerciseService : IExerciseService
    {
        private readonly CodeAppContext _dbContext;
        private readonly ICompilerService _compilerService;
        private readonly IConfiguration _configuration;

        public ExerciseService(CodeAppContext dbContext, ICompilerService compilerService, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _compilerService = compilerService;
            _configuration = configuration;
        }

        public ICollection<Exercise> GetExercises()
        {
            var exerciseList = _dbContext.Set<Exercise>().ToList();

            return exerciseList;
        }

        public Exercise GetExercise(int exerciseId)
        {
            var exercise = _dbContext.Set<Exercise>()
                .Include(e => e.TestCases)
                .Where(e => e.Id == exerciseId)
                .FirstOrDefault();

            return exercise;
        }

        public async Task<ExerciseResultModel> TestExercise(int userId, int exerciseId, string inputCode)
        {
            var exercise = _dbContext.Set<Exercise>()
                .Include(e => e.TestCases)
                    .ThenInclude(e => e.Parameters)
                .Where(e => e.Id == exerciseId)
                .FirstOrDefault();

            if (exercise == null)
                throw new NullReferenceException("Exercise could not be found.");

            var testsInfo = await GradeExercise(exercise, inputCode);

            var userScore = _dbContext
                .Set<UserExercises>()
                .Where(ue => ue.UserId == userId && ue.ExerciseId == exerciseId)
                .FirstOrDefault();

            if(userScore == null)
            {
                _dbContext.Set<UserExercises>().Add(new UserExercises(userId, exerciseId, testsInfo.Score));
            }
            else
            {
                userScore.Score = userScore.Score < testsInfo.Score ? testsInfo.Score : userScore.Score;
            }

            _dbContext.SaveChanges();

            return testsInfo;
        }

        private async Task<ExerciseResultModel> GradeExercise(Exercise exercise, string inputCode)
        {
            var strategy = GetStrategyByTechnology(exercise.Technology);

            var testingCode = strategy.PrepareCode(exercise.TestCases, inputCode);
            var requestModel = new CompilerRequestModel(
                _configuration["JDoodle:ClientId"],
                _configuration["JDoodle:ClientSecret"],
                GetLanguageByTechnology(exercise.Technology),
                testingCode,
                "0"
            );
            var compilerResult = await _compilerService.GetCodeExecutionResponse(requestModel);

            var testLines = compilerResult.Output.Split('\n').ToList();
            testLines.RemoveAt(testLines.Count - 1);

            return GetResult(exercise.TestCases, testLines);
        }

        private ExerciseResultModel GetResult(ICollection<TestCase> testCases, IEnumerable<string> testResults)
        {
            var score = 0;
            var output = "";

            foreach (string testResult in testResults)
            {
                int x = 0;
                (int? testNumber, string? result) = GetTestNumberAndResult(testResult);

                if (testNumber == null || result == null)
                {
                    output += "COMPILE ERROR\n";
                }
                else
                {
                    var testCaseResult = testCases.Where(t => t.TestNumber == testNumber).FirstOrDefault().Result;
                    if (CodeParser.RemoveWhiteSpaces(testCaseResult) == CodeParser.RemoveWhiteSpaces(result))
                    {
                        score += (int)Math.Round(100.0f / testCases.Count);

                        output += testResult + "   Expected: " + testCaseResult + "  Correct!\n";
                    }
                    else
                    {
                        output += testResult + "   Expected: " + testCaseResult + "  Incorrect.\n";
                    }
                }
            }

            return new ExerciseResultModel(score, String.Join('\n', output.Split('\n').Take(3)));
        }

        private (int?, string?) GetTestNumberAndResult(string testResult)
        {
            var firstSplit = testResult.Split(":");

            if (firstSplit.Length < 2) return (null, null);xx

            if (firstSplit[0].Split(" ").Length < 2) return (null, null);
            else if (firstSplit[1].Split(" ").Length < 1) return (null, null);
            else {
                int? testNumber = null;
                try
                {
                    testNumber = Int32.Parse(testResult.Split(":")[0].Split(' ')[1]);
                } catch(Exception) {

                }

                return (
                    testNumber,
                    testResult.Split(":")[1].Trim().Split(' ')[0]
                );
            }
        }

        private ICompileStrategy GetStrategyByTechnology(string technology)
        {
            switch(technology)
            {
                case "Python": return new PythonCompileStrategy();
                case "JavaScript": return new JavaScriptCompileStrategy();
                default: return null;
            }
        }

        private string GetLanguageByTechnology(string technology)
        {
            switch(technology)
            {
                case "Python": return "python3";
                case "JavaScript": return "nodejs";
                default: return "";
            }
        }
    }
}
