namespace ProiectIS_BE.Models.Article
{
    public class CoursePreviewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishedAt { get; set; }
        public string Description { get; set; }
        public string Technology { get; set; }
        public string Difficulty { get; set; }
        public byte[] Image { get; set; }
    }
}
