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
                    MapperConfiguration config1;
                    config1 = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
                    movieDTOs = context.Movies.ProjectTo<MovieDTO>(config1).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return movieDTOs;

        }
    }
}
