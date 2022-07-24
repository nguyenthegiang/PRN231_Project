using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.Authentication;
using WebAPI.DTO;
using WebAPI.DTO.Request;
using WebAPI.Helper;
using WebAPI.IRepository;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository repository;
        private IAuthenticationManager authentication;
        private readonly MyDbContext context;
        private MapperConfiguration config;
        private IMapper mapper;

        public UserController(IUserRepository repository, IAuthenticationManager authentication, MyDbContext _context)
        {
            this.repository = repository;
            this.authentication = authentication;
            context = _context;
            config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            mapper = config.CreateMapper();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<User>> GetUsers()
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

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetUserById(int id)
        {
            UserDTO userDTO;
            userDTO = context.Users.Include(u => u.Role).ProjectTo<UserDTO>(config)
                .FirstOrDefault(u1 => u1.UserId == id);
            //var u = repository.GetUserById(id);

            if (userDTO == null)
            {
                return NotFound(); //Response with status code: 404
            }

            return Ok(userDTO);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddUser([FromBody] User user)
        {
            try
            {
                user.Password = Hashing.Encrypt(user.Password);
                repository.SaveUser(user);
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("id")]
        [Authorize]
        public IActionResult UpdateUser(int id, User user)
        {
            try
            {
                var uTmp = repository.GetUserById(id);

                if (uTmp == null)
                {
                    return NotFound();
                }
                uTmp.Email = user.Email;
                uTmp.Username = user.Username;
                if (user.RoleId != 0)
                    uTmp.RoleId = user.RoleId;
                repository.UpdateUser(uTmp);
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("id")]
        [Authorize(Roles="Admin")]
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

        // Search by Name
        [HttpGet("search")]
        [Authorize(Roles = "Admin")]
        public IActionResult Search(string name)
        {
            List<UserDTO> userDTOs;
            userDTOs = context.Users.Include(p => p.Role).Where(u => u.Username.Contains(name))
                .ProjectTo<UserDTO>(config).ToList();

            if (userDTOs == null)
            {
                return NotFound(); // Response with status code: 404
            }

            return Ok(userDTOs);
        }

        /********Authentication********/
        [HttpPost("login")]
        public IActionResult Login(LoginRequestDTO request)
        {
            try
            {
                UserDTO user = null;
                user = repository.Login(request.Email, request.Password);
                var token = authentication.Authenticate(user);
                if (token == null)
                    return Unauthorized();
                user.Token = token;
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("signup")]
        public IActionResult Signup(SignupRequestDTO request)
        {
            try
            {
                if (request.Password != request.RePassword)
                    return BadRequest("Password does not match!");
                
                if (repository.GetUserByEmail(request.Email).Count > 0)
                    return Conflict("This email has been used!");

                User user = new User { 
                    Email = request.Email, 
                    RoleId = (int)Roles.User, 
                    Username = request.Username, 
                    Password = Hashing.Encrypt(request.Password)
                };
                repository.SaveUser(user);
                UserDTO userDTO = null;
                userDTO = repository.Login(request.Email, request.Password);
                var token = authentication.Authenticate(userDTO);
                if (token == null)
                    return Unauthorized();
                userDTO.Token = token;
                return Ok(userDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login/fb")]
        public IActionResult FacebookLogin(FacebookLoginRequestDTO request)
        {
            try
            {
                UserDTO existed = repository.GetUserByFacebookUID(request.FacebookUID);
                if (existed == null)
                {
                    User user = new User
                    {
                        Email = request.Email,
                        IsFacebookUser = true,
                        FacebookUID = request.FacebookUID,
                        RoleId = (int)Roles.User,
                        Username = request.Name,
                        Password = Hashing.Encrypt(request.FacebookUID)
                    };
                    repository.SaveUser(user);
                }
                UserDTO userDTO = null;
                userDTO = repository.LoginByFacebook(request.FacebookUID);
                var token = authentication.Authenticate(userDTO);
                if (token == null)
                    return Unauthorized();
                userDTO.Token = token;
                return Ok(userDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("forgot_password")]
        public IActionResult ForgotPasswordReset([FromBody] ForgotPasswordRequestDTO request)
        {
            try
            {
                User user = repository.GetUserByEmail(request.Email).FirstOrDefault();
                if (user == null) return NotFound();
                if (request.Password != request.RePassword)
                {
                    return Conflict("Password must match!");
                }
                user.Password = Hashing.Encrypt(request.Password);
                repository.UpdateUser(user);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("change_password")]
        [Authorize]
        public IActionResult ChangePassword([FromBody] ChangePasswordRequestDTO request)
        {
            try
            {
                User user = repository.GetUserById(request.UserId);
                if (user == null) return NotFound();
                string hashedPassword = Hashing.Encrypt(request.CurrentPassword);
                if (hashedPassword != user.Password)
                    return Conflict("Password Incorrect!");
                if (request.NewPassword != request.RePassword)
                {
                    return Conflict("Password must match!");
                }
                user.Password = Hashing.Encrypt(request.NewPassword);
                repository.UpdateUser(user);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /********Authentication********/
        [HttpPost("autho")]
        public IActionResult Auth()
        {
            Task.Run(() => Helper.MailService.Instance.SendEmail("32f353b3-389b-4eae-87e8-b3fb9b299589@mailslurp.com", "test", "header"));
            return Ok();
        }
    }
}
