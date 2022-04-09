using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Udemy_eTikets.Data;

namespace Udemy_eTikets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ProducersController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await _appDbContext.Producers.OrderBy(p=>p.FullName).ToListAsync();

            return View(allProducers);
        }
    }
}
