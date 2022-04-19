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


        //Movies/Create
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


        //Movies/Edit/1
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if(movieDetails == null)
            {
                return View("NotFound");
            }

            var response = new NewMovieVM();
            response.Id = movieDetails.Id;
            response.Name = movieDetails.Name;
            response.Description = movieDetails.Description;
            response.ImageURL = movieDetails.ImageURL;
            response.StartDate = movieDetails.StartDate;
            response.EndDate = movieDetails.EndDate;
            response.Price = movieDetails.Price;
            response.MovieCategory = movieDetails.MovieCategory;
            response.CinemaId = movieDetails.CinemaId;
            response.ProducerId = movieDetails.ProducerId;
            response.ActorIds = movieDetails.Actors_Movies.Select(a=>a.ActorId).ToList();


            var movieDropsdownsData = await _service.GetNewMovieDropdownValues();

            ViewBag.Cinemas = new SelectList(movieDropsdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropsdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropsdownsData.Actors, "Id", "FullName");

            return View(response);
        }




        //Movies/Edit/1
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if(id!=movie.Id)
            {
                return View("NotFound");
            }

            if (!ModelState.IsValid)
            {
                var movieDropsdownsData = await _service.GetNewMovieDropdownValues();

                ViewBag.Cinemas = new SelectList(movieDropsdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropsdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropsdownsData.Actors, "Id", "FullName");
                return View(movie);
            }

            await _service.UpdateNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }


    }
}
