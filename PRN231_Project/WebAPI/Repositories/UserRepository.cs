using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DataAccess;
using WebAPI.DTO;
using WebAPI.IRepository;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> GetListUsers() => UserDAO.GetUsers();

        public User GetUserById(int id) => UserDAO.GetUserById(id);
        public UserDTO GetUserByFacebookUID(string uid) => UserDAO.GetUserByFacebookUID(uid);
        public List<User> GetUserByName(string name) => UserDAO.GetUserByName(name);
        public List<User> GetUserByEmail(string email) => UserDAO.GetUserByEmail(email);

        public void SaveUser(User user) => UserDAO.SaveUser(user);

        public void UpdateUser(User user) => UserDAO.UpdateUser(user);

        public void DeleteUser(int id) => UserDAO.DeleteUser(id);

        public UserDTO Login(string email, string rawPassword)
        {
            //Encryption
            string hashedPassword = Helper.Hashing.Encrypt(rawPassword);
            return UserDAO.Login(email, hashedPassword);
        }

        public UserDTO LoginByFacebook(string facebookUID)
        {
            return UserDAO.GetUserByFacebookUID(facebookUID);
        }
    }
}
