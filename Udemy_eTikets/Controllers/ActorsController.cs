using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Udemy_eTikets.Data;
using Udemy_eTikets.Data.Services;
using Udemy_eTikets.Models;

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
            var allActors = await _service.GetAllAsync();

            return View(allActors);
        }

        //Get  Actors/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]  // Атрибут Bind позволяет установить выборочную привязку отдельных значений.
        public async Task<IActionResult> Create([Bind("ProfilePictureURL, FullName, Bio")] Actor actor) //[Bind("ProfilePictureURL, FullName, Bio")]
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }


        //Get actors/Details/1
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if(actorDetails == null)
            {
                return View("NotFound");
            }
            return View(actorDetails);
        }



        //Get  Actors/Edit/1
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }

            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ProfilePictureURL, FullName, Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }



        //Get  Actors/Delete/1
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }

            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

           
        }
    }
}
