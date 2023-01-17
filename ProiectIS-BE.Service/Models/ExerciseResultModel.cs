using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.Service.Models
{
    public class ExerciseResultModel
    {
        public ExerciseResultModel(int score, string testOutput)
        {
            Score = score;
            TestOutput = testOutput;
        }

        public int Score { get; set; }
        public string TestOutput { get; set; }
    }
}
