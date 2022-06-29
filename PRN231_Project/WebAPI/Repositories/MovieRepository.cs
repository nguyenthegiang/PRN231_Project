using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DataAccess;
using WebAPI.IRepository;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        public List<Movie> GetListMovies() => MovieDAO.GetMovies();
    }
}
