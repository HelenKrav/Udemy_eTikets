using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Udemy_eTikets.Data;

namespace Udemy_eTikets.Controllers
{
    public class ActorsController : Controller
    {

        private readonly AppDbContext _appDbContext;

        public ActorsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            var data = _appDbContext.Actors.ToList();

            return View();
        }
    }
}
