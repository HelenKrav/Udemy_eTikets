using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy_eTikets.Models;

namespace Udemy_eTikets.Data.Services
{
    public class ActorService : IActorService
    {
        private readonly AppDbContext _appDbContext;

        public ActorService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task  AddAsync(Actor actor)
        {
           await _appDbContext.Actors.AddAsync(actor);
           await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _appDbContext.Actors.FirstOrDefaultAsync(a => a.Id == id);
            _appDbContext.Actors.Remove(result);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            return await _appDbContext.Actors.ToListAsync();
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var result = await  _appDbContext.Actors.FirstOrDefaultAsync(a=>a.Id == id);
            return result;
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            _appDbContext.Update(newActor);
            await _appDbContext.SaveChangesAsync();

            return newActor;
        }
    }
}
