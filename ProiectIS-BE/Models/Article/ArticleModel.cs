using ProiectIS_BE.DAL.Entities;

namespace ProiectIS_BE.Models.Article
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }

        public List<ParagraphModel> Paragraphs { get; set; }
    }
}
