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
    public class EnrollStudentModel : PageModel
    {
        UIA2 RequestDirector = new();
        private bool Confirmation { get; set; }
        public string Message { get; set; }

        [BindProperty]
        [Required]
        [StringLength(10, ErrorMessage ="Student ID cannot be longer than 10")]
        public string StudentID { get; set; }
        [BindProperty]
        [Required]
        [StringLength(25, ErrorMessage = "First Name cannot be longer than 25")]
        public string FirstName { get; set; }
        [BindProperty]
        [Required]
        [StringLength(25, ErrorMessage = "Last Name cannot be longer than 25")]
        public string LastName { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        [Required]
        [StringLength(50, ErrorMessage = "Program Code cannot be longer than 50")]
        public string ProgramCode { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            Student acceptedStudent = new Student()
            {
                StudentID = StudentID,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email
            };

            Confirmation = RequestDirector.EnrollStudent(acceptedStudent, ProgramCode);
            if (ModelState.IsValid)
            {
                if (Confirmation)
                {
                    Message = "Student Enrolled!";
                }
                else
                {
                    Message = "There was an error.";
                }
            }
            else
            {
                Message = "There was an error.";
            }
        }
    }
}
