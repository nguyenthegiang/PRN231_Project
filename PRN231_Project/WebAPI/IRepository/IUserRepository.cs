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
        UserDTO GetUserByFacebookUID(string uid);
        List<User> GetUserByName(string name);
        List<User> GetUserByEmail(string email);
        void SaveUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        UserDTO Login(string email, string rawPassword);
        UserDTO LoginByFacebook(string facebookUID);
    }
}
