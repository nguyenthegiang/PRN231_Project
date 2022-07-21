using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.IRepository;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IRoleRepository repository;

        public RoleController(IRoleRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Role>> GetRoles() => repository.GetRoles();

        [HttpGet("/GetRolesById/{id}")]
        public ActionResult<Role> GetRoleById(int id) => repository.GetRoleById(id);
    }
}
