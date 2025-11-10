using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentInfoPortal.Models;
using StudentInfoPortal.Services;

namespace StudentInfoPortal.Pages
{
    public class EditStudentModel : PageModel
    {
        private readonly StudentService _service;

        public EditStudentModel(StudentService service)
        {
            _service = service;
        }

        [BindProperty]
        public Student Student { get; set; } = new();

        public IActionResult OnGet(int id)
        {
            var student = _service.GetById(id);
            if (student == null)
                return RedirectToPage("/Students");

            Student = student;
            return Page();
        }

        public IActionResult OnPost()
        {
            _service.Update(Student);
            return RedirectToPage("/Students");
        }
    }
}
