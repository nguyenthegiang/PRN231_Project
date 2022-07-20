using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO.Request
{
    public class SignupRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string Username { get; set; }
    }
}
