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

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
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

        public void Update(int id, Actor actor)
        {
            throw new System.NotImplementedException();
        }
    }
}
