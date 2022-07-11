using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Authentication
{
    public interface IAuthenticationManager
    {
        string Authenticate(UserDTO user);
    }
}
