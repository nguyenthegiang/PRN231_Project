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

        public Movie GetMovieById(int id) => MovieDAO.GetMovieById(id);

        public void SaveMovie(Movie movie) => MovieDAO.SaveMovie(movie);

        public void UpdateMovie(Movie movie) => MovieDAO.UpdateMovie(movie);
        public void DeleteMovie(int id) =>MovieDAO.DeleteMovie(id);
    }
}
