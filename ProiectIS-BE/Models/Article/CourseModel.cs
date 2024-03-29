﻿using ProiectIS_BE.Models.User;

namespace ProiectIS_BE.Models.Article
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string Technology { get; set; }
        public DateTime PublishedAt { get; set; }
        public int? QuizId { get; set; }

        public string AuthorName { get; set; }
        public IEnumerable<ArticleModel> Articles { get; set; }
    }
}
