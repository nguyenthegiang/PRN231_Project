using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DataAccess;
using WebAPI.DTO;
using WebAPI.IRepository;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        public List<MovieDTO> GetListMovies() => MovieDAO.GetMovies();

        public MovieDTO GetMovieById(int id) => MovieDAO.GetMovieById(id);
    }
}
