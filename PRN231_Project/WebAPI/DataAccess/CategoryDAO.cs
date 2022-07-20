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
    public class CategoryDAO
    {
        public static List<Category> GetCategories()
        {
            List<Category> categories;
            try
            {
                using (var context = new MyDbContext())
                {
                  
                    categories = context.Categories.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return categories;
        }

        public static List<Category> GetCategoriesByMovieId(int id)
        {
            List<CategoryMovieDTO> categoryMovieDTOs;
            List<Category> categories;
            List<Category> result = new List<Category>();
            try
            {

                using (var context = new MyDbContext())
                {
                    MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile())); ;
                    IMapper mapper = config.CreateMapper();
                    categoryMovieDTOs = context.CategoryMovie.Where(o => o.MovieId == id).ProjectTo<CategoryMovieDTO>(config).ToList();
                    categories = context.Categories.ToList();
                    foreach (CategoryMovieDTO o in categoryMovieDTOs)
                    {
                        foreach (Category o2 in categories)
                        {
                            if (o.CategoryId == o2.CategoryId)
                            {
                                result.Add(o2);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return result;

        }
    }
}
