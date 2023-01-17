namespace ProiectIS_BE.Models.User
{
    public class UserCourseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Technology { get; set; }
        public string Difficulty { get; set; }
        public byte[] Image { get; set; }
        public int Points { get; set; }
        public int QuizTotalPoints { get; set; }
    }
}
