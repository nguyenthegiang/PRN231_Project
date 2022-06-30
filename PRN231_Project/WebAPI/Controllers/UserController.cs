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

        private IUserRepository repository;

        public UserController(MyDbContext _context, IUserRepository repo)
        {
            context = _context;
            repository = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers() => repository.GetListUsers();

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
            List<User> users;
            users = context.Users.Include(p => p.Role)
                .Where(p => p.Username.Contains(name)).ToList();

            if (users == null)
            {
                return NotFound(); // Response with status code: 404
            }

            return Ok(users);
        }
        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            try
            {
                User user = null;
                user = repository.Login(email, password);
                if (user == null)
                    return NotFound();
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
