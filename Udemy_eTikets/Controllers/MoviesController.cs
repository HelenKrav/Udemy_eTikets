using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Udemy_eTikets.Data;
using Udemy_eTikets.Data.Services;
using Udemy_eTikets.Models;

namespace Udemy_eTikets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _service;

        public MoviesController(IMovieService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(m=>m.Cinema);

            return View(allMovies);
        }


        //Get   Movies/Details/Id
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            return View(movieDetails);
        }

        //Movies/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var movieDropsdownsData = await _service.GetNewMovieDropdownValues();

            ViewBag.Cinemas = new SelectList(movieDropsdownsData.Cinemas, "Id", "Name");

            ViewBag.Producers = new SelectList(movieDropsdownsData.Producers, "Id", "FullName");

            ViewBag.Actors = new SelectList(movieDropsdownsData.Actors, "Id", "FullName");

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if(!ModelState.IsValid)
            {
                var movieDropsdownsData = await _service.GetNewMovieDropdownValues();

                ViewBag.Cinemas = new SelectList(movieDropsdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropsdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropsdownsData.Actors, "Id", "FullName");
                return View(movie);
            }

            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
