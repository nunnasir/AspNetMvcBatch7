using Microsoft.AspNetCore.Mvc;

namespace ProductInfo.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
