using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
        public List<Mark> Marks { get; set; } = new List<Mark>();
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}
