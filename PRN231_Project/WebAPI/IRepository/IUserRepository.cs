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
        List<User> GetListUsers();
        User GetUserById(int id);
        List<User> GetUserByName(string name);
        void SaveUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        User Login(string email, string rawPassword);
    }
}
