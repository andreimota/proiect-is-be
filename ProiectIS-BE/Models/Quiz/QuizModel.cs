namespace ProiectIS_BE.Models.Quiz
{
    public class QuizModel
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string Title { get; set; }

        public List<QuestionModel> Questions { get; set; }
    }
}
