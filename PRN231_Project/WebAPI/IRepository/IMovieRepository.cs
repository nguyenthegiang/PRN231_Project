using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.IRepository
{
    public interface IMovieRepository
    {
        List<Movie> Paging5Movies(int page);
        List<Movie> Paging10Movie(int page);
        Movie GetMovieById(int id);
        void SaveMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int id);
    }
}
