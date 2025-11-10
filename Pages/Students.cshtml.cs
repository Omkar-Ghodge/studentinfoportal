using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentInfoPortal.Models;
using StudentInfoPortal.Services;

namespace StudentInfoPortal.Pages
{
    public class StudentsModel : PageModel
    {
        private readonly StudentService _service;

        public StudentsModel(StudentService service)
        {
            _service = service;
        }

        public List<Student> Students { get; set; } = new();

        public void OnGet()
        {
            Students = _service.GetAll();
        }

        public IActionResult OnPostDelete(int id)
        {
            _service.Delete(id);
            return RedirectToPage();
        }
    }
}
