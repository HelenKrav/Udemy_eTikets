using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Udemy_eTikets.Data;

namespace Udemy_eTikets.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CinemasController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var allCinemas = await _appDbContext.Cinemas.ToListAsync();

            return View();
        }
    }
}
