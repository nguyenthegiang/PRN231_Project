using AutoMapper;
using AutoMapper.QueryableExtensions;
using BT2TrenLop.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.IRepository;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private ICategoryRepository repository = new CategoryRepository();

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDTO>> GetCategories() => repository.GetListCategories();

        /*[HttpGet]
        public IActionResult GetAllCategory()
        {
            List<CategoryDTO> categoryDTOs;
            categoryDTOs = context.Categories.ProjectTo<CategoryDTO>(config).ToList();
            if (categoryDTOs == null)
            {
                return NotFound(); //Response with status code: 404
            }
            return Ok(categoryDTOs);
        }*/
    }
}
