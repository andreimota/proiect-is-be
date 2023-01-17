using Microsoft.EntityFrameworkCore;
using ProiectIS_BE.DAL.Entities;
using ProiectIS_BE.Data;
using ProiectIS_BE.Data.Entities;
using ProiectIS_BE.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.Service.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly CodeAppContext _dbContext;

        public CourseService(CodeAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Course GetCourse(int courseId, int userId)
        {
            var userCourses = new UserCourses();

            var course = _dbContext.Set<Course>()
                .Include(entity => entity.Articles)
                    .ThenInclude(entity => entity.Paragraphs)
                .Where(course => course.Id == courseId)
                .FirstOrDefault();

            if(course == null)
            {
                throw new NullReferenceException("Article could not be found.");
            }

            if (!_dbContext.Set<UserCourses>().Where(uc => uc.UserId == userId && uc.CourseId == courseId).Any())
            {
                userCourses.UserId = userId;
                userCourses.CourseId = courseId;
                userCourses.StartedAt = DateTime.Now;
                userCourses.Points = 0;

                _dbContext.Add(userCourses);

                _dbContext.SaveChanges();
            }

            return course;
        }

        public IEnumerable<Course> GetCourses()
        {
            return _dbContext.Set<Course>();
        }
    }
}
