namespace ProiectIS_BE.Models.Article
{
    public class ArticlePreviewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Technology { get; set; }
        public byte[] Image { get; set; }
    }
}
