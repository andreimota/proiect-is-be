namespace ProiectIS_BE.Models.Article
{
    public class ParagraphModel
    {
        public int Id { get; set; }
        public string TextSection { get; set; }
        public string? CodeSection { get; set; }
        public int Order { get; set; }
    }
}
