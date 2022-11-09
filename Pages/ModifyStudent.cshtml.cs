using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI_Assignment_2.Domain;

namespace UI_Assignment_2.Pages
{
    public class ModifyStudentModel : PageModel
    {
        UIA2 RequestDirector = new();
        public static Student EnrolledStudent { get; set; } = new();
        public bool Confirmation { get; set; }
        public string Message { get; set; }
        [BindProperty]
        public string StudentID { get; set; }
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Submit { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            switch (Submit)
            {
                case "Find":
                    {
                        if (String.IsNullOrEmpty(StudentID))
                        {
                            EnrolledStudent = RequestDirector.FindStudent(StudentID);
                            StudentID = EnrolledStudent.StudentID;
                            FirstName = EnrolledStudent.FirstName;
                            LastName = EnrolledStudent.LastName;
                            Email = EnrolledStudent.Email;
                        }
                        else
                        {
                            Message = "StudentID cannot be null";
                        }
                        
                        break;
                    }
                case "Modify":
                    {
                        if (String.IsNullOrEmpty(FirstName) || String.IsNullOrEmpty(LastName) || String.IsNullOrEmpty(StudentID))
                        {
                            Message = "Student ID, First Name and Last Name are required.";
                        }
                        else
                        {
                            EnrolledStudent.FirstName = FirstName;
                            EnrolledStudent.LastName = LastName;
                            EnrolledStudent.Email = Email;
                            EnrolledStudent.StudentID = StudentID;
                            Confirmation = RequestDirector.ModifyStudent(EnrolledStudent);
                        }
                        
                        break;
                    }
            }
        }
    }
}

