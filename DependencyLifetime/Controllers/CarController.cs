using Microsoft.AspNetCore.Mvc;

namespace DependencyLifetime.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly IEngine _engine;

        public CarController(
            IEngine engine)
        {
            _engine = engine;
        }

        public IActionResult Index()
        {
            return Ok(new
            {
                Result = _engine.Start()
            });
        }
    }
}
