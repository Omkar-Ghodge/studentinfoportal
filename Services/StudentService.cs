using StudentInfoPortal.Models;

namespace StudentInfoPortal.Services
{
    public class StudentService
    {
        private static List<Student> _students = new()
        {
            new Student { Id = 1, Name = "Alice Golmes", Branch = "Computer", Year = 3 },
            new Student { Id = 2, Name = "Aditya Naik", Branch = "IT", Year = 3 },
            new Student { Id = 3, Name = "Bob Vaz", Branch = "ETC", Year = 2 },
        };

        public List<Student> GetAll() => _students;

        public Student? GetById(int id) => _students.FirstOrDefault(s => s.Id == id);

        public void Add(Student student)
        {
            student.Id = _students.Max(s => s.Id) + 1;
            _students.Add(student);
        }

        public void Update(Student updated)
        {
            var existing = _students.FirstOrDefault(s => s.Id == updated.Id);
            if (existing == null) return;

            existing.Name = updated.Name;
            existing.Branch = updated.Branch;
            existing.Year = updated.Year;
        }

        public void Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student != null)
                _students.Remove(student);
        }
    }
}
