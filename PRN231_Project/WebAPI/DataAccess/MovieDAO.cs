using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.DataAccess
{
    public class MovieDAO
    {
        public static List<Movie> GetMovies()
        {
            var listMovies = new List<Movie>();
            try
            {
                using (var context = new MyDbContext())
                {
                    listMovies = context.Movies.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listMovies;
        }
    }
}
