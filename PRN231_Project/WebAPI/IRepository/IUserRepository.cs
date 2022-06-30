using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.IRepository
{
    public interface IUserRepository
    {
        List<UserDTO> GetListUsers();
        UserDTO GetUserById(int id);
        void SaveUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
