using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OstadFirstMVC.Execptions;
using OstadFirstMVC.Models;

namespace OstadFirstMVC.Controllers
{
    //Movies/List
    //Movies/Details/1

    //[Authorize(Roles = "Admin")]
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

            if (string.IsNullOrEmpty(movie.Name))
            {
                return View();
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
            try
            {
                string name = null;
                int length = name.Length;
            }
            catch (Exception e)
            {


                throw new Exception("Custom Error Message: An error occurred in List action.", e);
            }
            

            List<Movie> movies = GetMovies();

            return View(movies);
        }

        //[Route("BanglaMovie/Details/{id:int}/{category}")]
        //[Route("movies/{id:int}")]
        public IActionResult Details(int id)
        {
            //Movie? movie = GetMovie();
            Movie? movie = null;

            if (movie == null)
                throw new NotFoundException("This Id Is not Valid");



            return View(movie);
        }

        private Movie GetMovie()
        {
            return new Movie
            {
                Id = 1,
                Name = "Animal",
                genre = "Action"
            };
        }

        private List<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Movie 1", genre = "Action" },
                new Movie { Id = 2, Name = "Movie 2", genre = "Comedy" },
                new Movie { Id = 3, Name = "Movie 3", genre = "Drama" }
            };
        }
    }
}
