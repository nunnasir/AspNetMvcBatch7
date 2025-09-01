using StudentPortal.Models;

namespace StudentPortal.Repository
{
    public static class StudentRepository
    {
        private static List<Student> _students = new List<Student>
        {
            new Student {Id = 1, Name = "Nazrun Hasan", Email = "nhasan@email.com", Course ="Dotnet with C#", 23},
            new Student {Id = 2, Name = "Abdur Rahim"},
            new Student {Id = 3, Name = "Al Momen"},
        };

        public static List<Student> GetAll()
        {
            // Dat
            return _students;
        }

        public static void Add(Student student)
        {
            // da

            student.Id = _students.Max(s => s.Id) + 1;
            _students.Add(student);
        }

    }
}
