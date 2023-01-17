using Microsoft.EntityFrameworkCore;
using ProiectIS_BE.DAL.Entities;
using ProiectIS_BE.Data;
using ProiectIS_BE.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.Service.Implementations
{
    public class QuizService : IQuizService
    {
        private readonly CodeAppContext _dbContext;

        public QuizService(CodeAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Quiz GetQuiz(int quizId)
        {
            var quiz = _dbContext.Set<Quiz>()
                .Include(q => q.Questions)
                    .ThenInclude(q => q.Answers)
                .Where(q => q.Id == quizId)
                .FirstOrDefault();

            return quiz;
        }

        public int GetCourseIdFromQuiz(int quizId)
        {
            return _dbContext.Set<Course>().Where(c => c.QuizId == quizId).FirstOrDefault().Id;
        }

        public void UpdateUserScore(int userId, int courseId, int score)
        {
            var userCourse = _dbContext.Set<UserCourses>()
                .Where(user => user.UserId == userId && user.CourseId == courseId)
                .FirstOrDefault();

            if (userCourse != null)
            {
                if(userCourse.Points < score) { 
                    userCourse.Points = score;

                    _dbContext.SaveChanges();
                }
            }
            else
            {
                throw new NullReferenceException("User score was not found");
            }
        }
    }
}
