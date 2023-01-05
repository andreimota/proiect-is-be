using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.DAL.Entities
{
    public class QuizQuestion
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public List<QuizAnswer> Answers { get; set; }
    }
}
