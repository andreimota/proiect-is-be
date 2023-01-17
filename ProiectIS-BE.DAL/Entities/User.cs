using ProiectIS_BE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public byte[]? Avatar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public ICollection<Course> Courses { get; set; }
        public List<UserCourses> CourseUsers { get; set; }

        public ICollection<Exercise> Exercises { get; set; }
        public List<UserExercises> UserExercises { get; set; }
    }
}
