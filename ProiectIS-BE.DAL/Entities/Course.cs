using ProiectIS_BE.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.DAL.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Description { get; set; }
        public string Technology { get; set; }
        public string Difficulty { get; set; }
        public byte[] Image { get; set; }

        public string AuthorName { get; set; }

        public int? QuizId { get; set; }
        public Quiz? Quiz { get; set; }
        public List<Article> Articles { get; set; }

        public ICollection<User> Users { get; set; }
        public List<UserCourses> CourseUsers { get; set; }
    }
}
