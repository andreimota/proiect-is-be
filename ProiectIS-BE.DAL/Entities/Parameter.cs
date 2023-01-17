using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.DAL.Entities
{
    public class Parameter : IComparable<Parameter>
    {
        public int Id { get; set; }
        public int ParameterNumber { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }

        public int CompareTo(Parameter other)
        {
            return ParameterNumber.CompareTo(other.ParameterNumber);
        }
    }
}
