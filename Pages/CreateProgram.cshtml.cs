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
    public class CreateProgramModel : PageModel
    {
        UIA2 RequestDirector = new();
        private bool Confirmation{ get; set; }
        public string Message { get; set; }
        [BindProperty]
        [Required]
        [StringLength(10, ErrorMessage ="Maximum Length is 10")]
        public string ProgramCode { get; set; }
        [BindProperty]
        [Required]
        [StringLength(60, ErrorMessage ="Masimum Length is 60")]
        public string Description { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            Confirmation = RequestDirector.AddProgram(ProgramCode, Description);
            if (ModelState.IsValid)
            {
                if (Confirmation)
                {
                    Message = "Program Created!";
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
