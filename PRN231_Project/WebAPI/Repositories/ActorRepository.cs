using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DataAccess;
using WebAPI.IRepository;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class ActorRepository : IActorRepository
    {
        public List<Actor> GetListActors() => ActorDAO.GetActors();
    }
}
