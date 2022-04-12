﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy_eTikets.Models;

namespace Udemy_eTikets.Data.Services
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAll();
        Actor GetById(int id);

        void Add(Actor actor);
        void Update(int id, Actor actor);
        void Delete(int id);

    }
}