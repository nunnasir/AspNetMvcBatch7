using Microsoft.AspNetCore.Mvc;
using OstadFirstMVC.Models;

namespace OstadFirstMVC.Controllers
{
    //Movies/List
    //Movies/Details/1

    public class MoviesController : Controller
    {
        public IActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Movie movie)
        {
            if (ModelState.IsValid)
            {
                return View(movie);
            }

            return View();
        }



        public FileResult DownloadFile()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", "books.jpeg");
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            
            return File(fileBytes, "image/jpeg", "books.jpeg");
        }


        public JsonResult GetData()
        {
            return Json(new { Name = "Naisr", Age = 30 });
        }



        public IActionResult RedirectExample()
        {
            return Redirect("https://google.com");
        }


        public string TestAction()
        {
            return "Test Data";
        }



        //[Route("BanglaMovie/Index")]
        public IActionResult List()
        {
            Movie movie = GetMovie();

            return View(movie);
        }

        //[Route("BanglaMovie/Details/{id:int}/{category}")]
        //[Route("movies/{id:int}")]
        public IActionResult Details(int id, string category)
        {
            Movie movie = GetMovie();

            return Content($"Movie Details with id: {id}, with category: {category}");
        }

        private Movie GetMovie()
        {
            return new Movie
            {
                Id = 1,
                Name = "Animal"
            };
        }
    }
}
