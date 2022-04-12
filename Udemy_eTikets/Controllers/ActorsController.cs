using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Udemy_eTikets.Data;
using Udemy_eTikets.Data.Services;

namespace Udemy_eTikets.Controllers
{
    public class ActorsController : Controller
    {

        private readonly IActorService _service;

        public ActorsController(IActorService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allActors = await _service.GetAll();

            return View(allActors);
        }
    }
}
