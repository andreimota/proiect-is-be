using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.DAL.Entities
{
    public class Paragraph
    {
        public int Id { get; set; }
        public string TextSection { get; set; }
        public string CodeSection { get; set; }
        public int Order { get; set; }
    }
}
