using Microsoft.EntityFrameworkCore;
using ProiectIS_BE.DAL.Entities;
using ProiectIS_BE.Data;
using ProiectIS_BE.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.Service.Implementations
{
    public class ArticleService : IArticleService
    {
        private readonly CodeAppContext _dbContext;

        public ArticleService(CodeAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Article> GetArticles()
        {
            return _dbContext.Set<Article>();
        }
    }
}
