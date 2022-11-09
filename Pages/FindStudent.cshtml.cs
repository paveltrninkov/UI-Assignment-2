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
    public class FindStudentModel : PageModel
    {
        UIA2 RequestDirector = new();
        Student AcceptedStudent = new();
        public string Message { get; set; }
        [BindProperty]
        [Required]
        [StringLength(10, ErrorMessage ="Student ID cannot be longer than 10 characters")]
        public string StudentID { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            AcceptedStudent = RequestDirector.FindStudent(StudentID);
            if (ModelState.IsValid)
            {
                Message = "Full Name: " + AcceptedStudent.FirstName + " " + AcceptedStudent.LastName + "Email: " + (AcceptedStudent.Email == null ? "N/A" : AcceptedStudent.Email) + "\n Program Code: " + AcceptedStudent.ProgramCode;
            }
            else
            {
                Message = "There was an error.";
            }
            
        }
    }
}
