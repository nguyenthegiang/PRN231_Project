using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Token { get; set; }

        public virtual RoleDTO Role { get; set; }
    }
}
