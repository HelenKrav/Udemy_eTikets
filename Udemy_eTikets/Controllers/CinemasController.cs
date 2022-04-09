using Microsoft.AspNetCore.Mvc;

namespace Udemy_eTikets.Controllers
{
    public class CinemasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
