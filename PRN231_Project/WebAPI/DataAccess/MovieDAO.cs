using AutoMapper;
using AutoMapper.QueryableExtensions;
using BT2TrenLop.DTO;
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
        public static  List<Movie> GetMovies()
        {
            List<Movie> movies;
            try
            {
                using (var context = new MyDbContext())
                {
                   /* MapperConfiguration config;
                    config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));*/
                    movies = context.Movies.ToList();
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
