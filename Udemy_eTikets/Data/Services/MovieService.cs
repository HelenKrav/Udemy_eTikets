using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Udemy_eTikets.Data.Base;
using Udemy_eTikets.Data.ViewModels;
using Udemy_eTikets.Models;

namespace Udemy_eTikets.Data.Services
{
    public class MovieService: EntityBaseRepository<Movie> , IMovieService
    {

        private readonly AppDbContext _appDbContext;


        public MovieService(AppDbContext appDbContext):base(appDbContext)
        {
                _appDbContext = appDbContext;
        }

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newMovie = new Movie();
            newMovie.Name = data.Name;
            newMovie.Description = data.Description;
            newMovie.StartDate = data.StartDate;
            newMovie.EndDate = data.EndDate;
            newMovie.ImageURL = data.ImageURL;
            newMovie.CinemaId = data.CinemaId;
            newMovie.ProducerId = data.ProducerId;
            newMovie.MovieCategory = data.MovieCategory;
            newMovie.Price = data.Price;

            await _appDbContext.Movies.AddAsync(newMovie);
            await _appDbContext.SaveChangesAsync();



            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie();
                newActorMovie.MovieId = newMovie.Id;
                newActorMovie.ActorId = actorId;

                await _appDbContext.Actors_Movies.AddAsync(newActorMovie);
            }
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = _appDbContext.Movies
                                                            .Include(c=>c.Cinema)
                                                            .Include(p=>p.Producer)
                                                            .Include(am=>am.Actors_Movies)
                                                            .ThenInclude(a=>a.Actor)
                                                            .FirstOrDefaultAsync(n=>n.Id == id);

            return await movieDetails;
        }

        public async Task<NewMovieDropdownVM> GetNewMovieDropdownValues()
        {
            var response = new NewMovieDropdownVM();
            response.Actors = await _appDbContext.Actors.OrderBy(n=>n.FullName).ToListAsync();
            response.Cinemas = await _appDbContext.Cinemas.OrderBy(c => c.Name).ToListAsync();
            response.Producers = await _appDbContext.Producers.OrderBy(n => n.FullName).ToListAsync();

            return response;
        }
    }
}
