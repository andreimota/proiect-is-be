using ProiectIS_BE.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.DAL.Entities
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string StartingCode { get; set; }

        public string Difficulty { get; set; }
        public string Technology { get; set; }

        public ICollection<TestCase> TestCases { get; set; }


        public ICollection<User> Users { get; set; }
        public List<UserExercises> UserExercises { get; set; }
    }
}
