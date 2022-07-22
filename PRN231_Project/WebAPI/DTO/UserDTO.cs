using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        [JsonIgnore]
        public string FacebookUID { get; set; }

        [JsonIgnore]
        public bool IsFacebookUser { get; set; }

        public string Token { get; set; }

        public virtual RoleDTO Role { get; set; }
    }
}
