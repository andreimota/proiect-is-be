using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.DAL.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Technology { get; set; }
        public byte[] Image { get; set; }

        public List<Paragraph> Paragraphs { get; set; }
    }
}
