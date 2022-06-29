using AutoMapper;
using AutoMapper.QueryableExtensions;
using BT2TrenLop.DTO;
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
        public static  List<MovieDTO> GetMovies()
        {
            List<MovieDTO> movieDTOs;
            try
            {
                using (var context = new MyDbContext())
                {
                    MapperConfiguration config;
                    config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
                    movieDTOs = context.Movies.ProjectTo<MovieDTO>(config).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return movieDTOs;
        }

        public static MovieDTO GetMovieById(int id)
        {
            MovieDTO movieDTO;
            try
            {
                using (var context = new MyDbContext())
                {
                    MapperConfiguration config;
                    config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
                    movieDTO = context.Movies.ProjectTo<MovieDTO>(config).SingleOrDefault(m => m.MovieId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return movieDTO;
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
