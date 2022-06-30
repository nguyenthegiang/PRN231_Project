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
using WebAPI.IRepository;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext context;
        private MapperConfiguration config;
        private IMapper mapper;

        private IUserRepository repository = new UserRepository();

        public UserController(MyDbContext _context)
        {
            context = _context;
            config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            mapper = config.CreateMapper();
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetUsers() => repository.GetListUsers();

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var u = repository.GetUserById(id);

            if (u == null)
            {
                return NotFound(); //Response with status code: 404
            }

            return Ok(u);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            try
            {
                repository.SaveUser(user);
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("id")]
        public IActionResult UpdateUser(int id, User user)
        {
            try
            {
                var uTmp = repository.GetUserById(id);

                if (uTmp == null)
                {
                    return NotFound();
                }

                repository.UpdateUser(user);
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("id")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var u = repository.GetUserById(id);

                if (u == null)
                {
                    return NotFound();
                }

                repository.DeleteUser(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
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
    }
}
