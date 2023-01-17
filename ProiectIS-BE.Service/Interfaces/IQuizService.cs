using ProiectIS_BE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.Service.Interfaces
{
    public interface IQuizService
    {
        Quiz GetQuiz(int quizId);
        void UpdateUserScore(int userId, int courseId, int score);
        int GetCourseIdFromQuiz(int quizId);
    }
}
