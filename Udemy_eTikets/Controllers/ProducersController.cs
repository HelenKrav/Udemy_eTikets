using Microsoft.AspNetCore.Mvc;

namespace Udemy_eTikets.Controllers
{
    public class ProducersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
