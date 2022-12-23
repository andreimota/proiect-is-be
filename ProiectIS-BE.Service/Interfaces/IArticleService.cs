using ProiectIS_BE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.Service.Interfaces
{
    public interface IArticleService
    {
        IEnumerable<Article> GetArticles();
    }
}
