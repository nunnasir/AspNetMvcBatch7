using Microsoft.AspNetCore.Mvc;

namespace DependencyLifetime.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DependencyDemoController : ControllerBase
    {
        private readonly TransiantOperation _transiantOperation1;
        private readonly ScopedOperation _scopedOperation1;
        private readonly SingleTonOperation _singleTonOperation1;

        private readonly TransiantOperation _transiantOperation2;
        private readonly ScopedOperation _scopedOperation2;
        private readonly SingleTonOperation _singleTonOperation2;

        public DependencyDemoController(
            TransiantOperation transiantOperation1,
            ScopedOperation scopedOperation1,
            SingleTonOperation singleTonOperation1,

            TransiantOperation transiantOperation2,
            ScopedOperation scopedOperation2,
            SingleTonOperation singleTonOperation2)
        {
            _transiantOperation1 = transiantOperation1;
            _scopedOperation1 = scopedOperation1;
            _singleTonOperation1 = singleTonOperation1;

            _transiantOperation2 = transiantOperation2;
            _scopedOperation2 = scopedOperation2;
            _singleTonOperation2 = singleTonOperation2;
        }

        public IActionResult Index()
        {
            return Ok(new
            {
                Transiant1 = _transiantOperation1.OperationId,
                Transiant2 = _transiantOperation2.OperationId,

                Scoped1 = _scopedOperation1.OperationId,
                Scoped2 = _scopedOperation2.OperationId,

                SingleTon1 = _singleTonOperation1.OperationId,
                SingleTon2 = _singleTonOperation2.OperationId
            });

        }
    }
}
