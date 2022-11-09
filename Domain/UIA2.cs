using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI_Assignment_2.TechnicalServices;

namespace UI_Assignment_2.Domain
{
    public class UIA2
    {
        public bool EnrollStudent(Student acceptedStudent, string programCode)
        {
            bool Confirmation = false;

            Students StudentManager = new();

            Confirmation = StudentManager.AddStudent(acceptedStudent, programCode);

            return Confirmation;
        }
        public bool AddProgram(string programCode, string description)
        {
            bool Confirmation = false;

            Programs ProgramManager = new();

            Confirmation = ProgramManager.AddProgram(programCode, description);

            return Confirmation;
        }
        public Student FindStudent(string studentID)
        {
            Student EnrolledStudent = new();

            Students StudentManager = new();

            EnrolledStudent = StudentManager.GetStudent(studentID);

            return EnrolledStudent;
        }

        public bool ModifyStudent(Student enrolledStudent)
        {
            bool Confirmation = false;

            Students StudentManager = new();

            Confirmation = StudentManager.UpdateStudent(enrolledStudent);

            return Confirmation;
        }

        public bool RemoveStudent(string studentID)
        {
            bool Confirmation = false;

            Students StudentManager = new();

            Confirmation = StudentManager.DeleteStudent(studentID);

            return Confirmation;
        }

        public Program FindProgram(string programCode)
        {
            Program ActiveProgram;

            Programs ProgramManager = new();

            ActiveProgram = ProgramManager.GetProgram(programCode);

            return ActiveProgram;
        }
    }
}
