using ProiectIS_BE.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.DAL.Entities
{
    public class UserCourses
    {
        public int Id { get; set; }
          
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public DateTime StartedAt { get; set; }
        public int Points { get; set; }
    }
}
