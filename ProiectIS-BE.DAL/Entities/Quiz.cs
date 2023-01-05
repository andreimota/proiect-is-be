using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.DAL.Entities
{
    public class Quiz
    {
        public int Id { get; set; }

        public List<QuizQuestion> Questions { get; set; }
    }
}
