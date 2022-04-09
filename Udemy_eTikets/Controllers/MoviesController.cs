using Microsoft.AspNetCore.Mvc;

namespace Udemy_eTikets.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
