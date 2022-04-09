using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> Index()
        {
            var allActors = await _appDbContext.Actors.OrderBy(a=>a.FullName).ToListAsync();

            return View(allActors);
        }
    }
}
