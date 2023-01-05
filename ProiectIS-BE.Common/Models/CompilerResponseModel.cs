using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.Common.Models
{
    public class CompilerResponseModel
    {
        public string Output { get; set; }
        public int StatusCode { get; set; }
        public string Memory { get; set; }
        public string CpuTime { get; set; }
    }
}
