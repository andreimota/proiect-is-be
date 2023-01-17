using ProiectIS_BE.DAL.Entities;
using ProiectIS_BE.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.Service.CompilingStrategies
{
    public interface ICompileStrategy
    {
        string PrepareCode(ICollection<TestCase> testCases, string inputCode);
    }
}
