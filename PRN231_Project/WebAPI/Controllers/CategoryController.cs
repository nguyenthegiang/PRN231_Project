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
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyDbContext context;
        private MapperConfiguration config;
        private IMapper mapper;

        public CategoryController(MyDbContext _context)
        {
            context = _context;
            config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            mapper = config.CreateMapper();
        }

        [HttpGet]
        public IActionResult GetAllCategory()
        {
            List<CategoryDTO> categoryDTOs;
            categoryDTOs = context.Categories.ProjectTo<CategoryDTO>(config).ToList();
            if (categoryDTOs == null)
            {
                return NotFound(); //Response with status code: 404
            }
            return Ok(categoryDTOs);
        }
    }
}
