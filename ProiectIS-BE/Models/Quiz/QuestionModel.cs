using ProiectIS_BE.DAL.Entities;

namespace ProiectIS_BE.Models.Quiz
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public List<AnswerModel> Answers { get; set; }
    }
}
