using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.IRepository
{
    public interface ICategoryRepository
    {
        List<CategoryDTO> GetListCategories();
    }
}
