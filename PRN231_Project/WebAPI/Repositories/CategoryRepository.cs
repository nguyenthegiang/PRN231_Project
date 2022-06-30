using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DataAccess;
using WebAPI.DTO;
using WebAPI.IRepository;

namespace WebAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<CategoryDTO> GetListCategories() => CategoryDAO.GetCategories();
    }
}
