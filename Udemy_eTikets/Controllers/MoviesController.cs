using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Udemy_eTikets.Data;

namespace Udemy_eTikets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public MoviesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await _appDbContext.Movies.ToListAsync();

            return View();
        }
    }
}
