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
        public List<Movie> GetAll() => MovieDAO.GetAll();
        public List<Movie> Paging5Movies(int page) => MovieDAO.Paging5Movies(page);

        public List<Movie> Paging10Movie(int page) => MovieDAO.Paging10Movie(page); 

        public Movie GetMovieById(int id) => MovieDAO.GetMovieById(id);

        public void SaveMovie(Movie movie) => MovieDAO.SaveMovie(movie);

        public void UpdateMovie(Movie movie) => MovieDAO.UpdateMovie(movie);
        public void DeleteMovie(int id) =>MovieDAO.DeleteMovie(id);

        public List<Movie> GetMoviesByCategory(int catid) => MovieDAO.GetMoviesByCategory(catid);
    }
}
