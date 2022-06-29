using AutoMapper;
using AutoMapper.QueryableExtensions;
using BT2TrenLop.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class UserController : ControllerBase
    {
        private readonly MyDbContext context;
        private MapperConfiguration config;
        private IMapper mapper;

        public UserController(MyDbContext _context)
        {
            context = _context;
            config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            mapper = config.CreateMapper();
        }

        // Get all 
        [HttpGet]
        public IActionResult GetAll()
        {
            List<UserDTO> userDTOs;
            userDTOs = context.Users.Include(p => p.Role)
                .ProjectTo<UserDTO>(config).ToList();

            if (userDTOs == null)
            {
                return NotFound(); // Response with status code: 404
            }

            return Ok(userDTOs);
        }

        // Get by id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            UserDTO userDTO;
            userDTO = context.Users.Include(p => p.Role).ProjectTo<UserDTO>(config)
                .FirstOrDefault(p1 => p1.UserId == id);

            if (userDTO == null)
            {
                return NotFound(); // Response with status code: 404
            }

            return Ok(userDTO);
        }

        // Search
        [HttpGet("search")]
        public IActionResult Search(string name)
        {
            List<UserDTO> userDTOs;
            userDTOs = context.Users.Include(p => p.Role)
                .Where(p => p.Username.Contains(name)).ProjectTo<UserDTO>(config).ToList();

            if (userDTOs == null)
            {
                return NotFound(); // Response with status code: 404
            }

            return Ok(userDTOs);
        }

        // Create
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // Delete
        [HttpDelete("id")]
        public IActionResult Detele(int id)
        {
            try
            {
                User u = context.Users.FirstOrDefault(u1 => u1.UserId == id);

                if (u == null)
                {
                    return NotFound();
                }

                context.Users.Remove(u);
                context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
