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

        public static List<Actor> GetActorsByMovieId(int id)
        {
            List<ActorMovieDTO> actormovies;
            List<Actor> actors;
            List<Actor> result = new List<Actor>();
            try
            {
                
                using (var context = new MyDbContext())
                {
                    MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile())); ;
                    IMapper mapper = config.CreateMapper();
                    actormovies = context.ActorMovies.Where(o => o.MovieId == id).ProjectTo<ActorMovieDTO>(config).ToList();
                    actors = context.Actors.ToList();
                    foreach(ActorMovieDTO o in actormovies)
                    {
                        foreach(Actor o2 in actors)
                        {
                            if(o.ActorId == o2.ActorId)
                            {
                                result.Add(o2);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;

        }
    }
}
