using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.DataAccess
{
    public class MovieDAO
    {
        //Get List Movies for Client

        public static List<Movie> GetAll()
        {
            List<Movie> movies;
            try
            {
                using (var context = new MyDbContext())
                {
                    movies = context.Movies.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return movies;
        }
        public static List<Movie> GetMoviesByCategory(int catId)
        {
            List<CategoryMovie> cateMovies;
            List<Movie> movies = new List<Movie>();
            try
            {
                using (var context = new MyDbContext())
                {
                    cateMovies = context.CategoryMovie.Where(c => c.CategoryId == catId).ToList();
                    foreach (var c in cateMovies)
                    {
                        movies.Add(context.Movies.FirstOrDefault(m => m.MovieId == c.MovieId));
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return movies;
        }

        public static  List<Movie> Paging5Movies(int page)
        {
            List<Movie> movies;
            try
            {
                using (var context = new MyDbContext())
                {
                    movies = context.Movies.Skip((page - 1) * 5).Take(5).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return movies;
        }

        //Get List Movies for Admin
        public static List<Movie> Paging10Movie(int page)
        {
            List<Movie> movies;
            try
            {
                using (var context = new MyDbContext())
                {
                    movies = context.Movies.Skip((page - 1) * 10).Take(10).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return movies;
        }

        public static Movie GetMovieById(int id)
        {
            Movie movie;
            try
            {
                using (var context = new MyDbContext())
                {
                    movie = context.Movies.SingleOrDefault(m => m.MovieId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return movie;
        }

        public static void SaveMovie(Movie movie)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Movies.Add(movie);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateMovie(Movie movie)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry<Movie>(movie).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteMovie(int id)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var m = GetMovieById(id);
                    var m1 = context.Movies.SingleOrDefault(c => c.MovieId == m.MovieId);
                    context.Movies.Remove(m1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
