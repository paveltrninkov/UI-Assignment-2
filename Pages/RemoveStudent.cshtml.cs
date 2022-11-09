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
    public class RemoveStudentModel : PageModel
    {
        UIA2 RequestDirector = new();
        private bool Confirmation { get; set; }
        public string Message { get; set; }
        [BindProperty]
        [Required]
        [StringLength(10, ErrorMessage ="Student ID cannot be longer than 10")]
        public string StudentID { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            Confirmation = RequestDirector.RemoveStudent(StudentID);

            if (ModelState.IsValid)
            {
                if (Confirmation)
                {
                    Message = "Student Removed!";
                }
                else
                {
                    Message = "There was an error.";
                }
            } else
            {
                Message = "There was an error.";
            }
        }
    }
}
