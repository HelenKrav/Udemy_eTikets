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


        public void Add(Actor actor)
        {
            _appDbContext.Actors.Add(actor);
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            return await _appDbContext.Actors.ToListAsync();
        }

        public Actor GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, Actor actor)
        {
            throw new System.NotImplementedException();
        }
    }
}
