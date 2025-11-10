using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentInfoPortal.Models;
using StudentInfoPortal.Services;

namespace StudentInfoPortal.Pages
{
    public class AddStudentModel : PageModel
    {
        private readonly StudentService _service;

        public AddStudentModel(StudentService service)
        {
            _service = service;
        }

        [BindProperty]
        public Student Student { get; set; } = new();

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _service.Add(Student);
            return RedirectToPage("/Students");
        }
    }
}
