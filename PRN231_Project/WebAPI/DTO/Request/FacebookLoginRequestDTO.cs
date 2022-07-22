using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO.Request
{
    public class FacebookLoginRequestDTO
    {
        public string Email { get; set; }
        public string FacebookUID { get; set; }
        public string Name { get; set; }
    }
}
