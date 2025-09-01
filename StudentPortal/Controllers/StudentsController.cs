using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using StudentPortal.Repository;

namespace StudentPortal.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            var students = StudentRepository.GetAll();

            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            StudentRepository.Add(new Student
            {
                Name = student.Name,
                Email = student.Email,
                Course = student.Course,
                Age = student.Age
            });

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var student = StudentRepository.GetById(id);

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            StudentRepository.Update(student);

            return RedirectToAction("Index");
        }
    }
}
