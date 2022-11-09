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
    public class FindProgramModel : PageModel
    {
        UIA2 RequestDirector = new();
        public List<Student> Students { get; set; } = new();
        public string ProgramDescription { get; set; }
        Domain.Program ActiveProgram = new();
        [BindProperty]
        [Required]
        [StringLength(10, ErrorMessage ="Program Code cannot be longer than 10")]
        public string ProgramCode { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            ActiveProgram = RequestDirector.FindProgram(ProgramCode);
            ProgramDescription = ActiveProgram.Description;
            Students = ActiveProgram.EnrolledStudents;
        }
    }
}
