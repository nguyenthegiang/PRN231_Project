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
    }
}
