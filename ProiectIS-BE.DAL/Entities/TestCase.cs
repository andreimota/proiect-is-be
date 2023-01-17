using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.DAL.Entities
{
    public class TestCase : IComparable<TestCase>
    {
        public int Id { get; set; }
        public int TestNumber { get; set; }
        public string Result { get; set; }

        public ICollection<Parameter> Parameters { get; set; }

        public int CompareTo(TestCase? other)
        {
            return TestNumber.CompareTo(other.TestNumber);
        }
    }
}
