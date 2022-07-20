using AutoMapper;
using WebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace WebAPI.DataAccess
{
    public class ActorDAO
    {
        public static List<Actor> GetActors()
        {
            List<Actor> actors;
            try
            {
                using (var context = new MyDbContext())
                {
                    actors = context.Actors.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return actors;
        }

        public static List<ActorMovie> GetActorsByMovieId(int id)
        {
            List<ActorMovie> actors;
            try
            {
                MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile())); ;
                IMapper mapper = config.CreateMapper();
                using (var context = new MyDbContext())
                {                   
                    actors = context.ActorMovies.ProjectTo<ActorMovieDTO>(config).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return actors;

        }
    }
}
