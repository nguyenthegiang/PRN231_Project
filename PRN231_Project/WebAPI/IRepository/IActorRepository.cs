using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.IRepository
{
    public interface IActorRepository
    {
        List<Actor> GetListActors();
        List<Actor> GetActorsByMovieId(int id);
    }
}
