using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_Assignment_2.Domain
{
    public class Program
    {
        public string ProgramCode { get; set; }
        public string Description { get; set; }
        public readonly List<Student> _enrolledStudents = new();

        public List<Student> EnrolledStudents
        {
            get { return _enrolledStudents; }
        }
    }
}
