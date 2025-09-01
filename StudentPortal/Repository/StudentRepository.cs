using StudentPortal.Models;

namespace StudentPortal.Repository
{
    public static class StudentRepository
    {
        private static List<Student> _students = new List<Student>
        {
            new Student {Id = 1, Name = "Nazrun Hasan", Email = "nhasan@email.com", Course ="Dotnet with C#", Age = 23},
            new Student {Id = 2, Name = "Abdur Rahim", Email = "nhasan@email.com", Course ="Blazor with C#", Age = 21},
            new Student {Id = 3, Name = "Al Momen", Email = "alMomen@email.com", Course ="WEB API with C#", Age = 25},
        };

        public static List<Student> GetAll()
        {
            // Dat
            return _students;
        }

        public static Student GetById(int id)
        {
            var existing = _students.FirstOrDefault(x => x.Id == id);

            return existing;
        }

        public static void Add(Student student)
        {
            student.Id = _students.Max(s => s.Id) + 1;
            _students.Add(student);
        }

        public static void Update(Student student)
        {
            var existing = _students.FirstOrDefault(x => x.Id == student.Id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Student with Id={student.Id} not found.");
            }

            existing.Name = student.Name;
            existing.Email = student.Email;
            existing.Course = student.Course;
            existing.Age = student.Age;
        }

        public static bool Delete(int id)
        {

            var st = _students.FirstOrDefault(x => x.Id == id);
            if (st == null) return false;
            _students.Remove(st);
            return true;
        }

    }
}
