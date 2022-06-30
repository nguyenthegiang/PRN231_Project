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
    public class CategoryDAO
    {
        public static List<CategoryDTO> GetCategories()
        {
            List<CategoryDTO> categoryDTOs;
            try
            {
                using (var context = new MyDbContext())
                {
                    MapperConfiguration config;
                    config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
                    categoryDTOs = context.Categories.ProjectTo<CategoryDTO>(config).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return categoryDTOs;
        }
    }
}
