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
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> GetListCategories() => CategoryDAO.GetCategories();
    }
}
