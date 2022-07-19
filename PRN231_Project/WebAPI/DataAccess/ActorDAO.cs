using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.DataAccess
{
    public class ActorDAO
    {
        public static List<Actor> GetActors()
        {
            List<Actor> actors;
            try
            {
                MyDbContext context = new MyDbContext();
                actors = context.Actors.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return actors;
        }

        public static Actor GetActorByMovieId(int id)
        {
            Actor actor;
            try
            {
                using (var context = new MyDbContext())
                {
                    actor = context.Actors.SingleOrDefault(u => u.UserId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return actor;
        }
    }
}
