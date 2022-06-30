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
        public List<UserDTO> GetListUsers() => UserDAO.GetUsers();

        public UserDTO GetUserById(int id) => UserDAO.GetUserById(id);

        public void SaveUser(User user) => UserDAO.SaveUser(user);

        public void UpdateUser(User user) => UserDAO.UpdateUser(user);

        public void DeleteUser(int id) => UserDAO.DeleteUser(id);
    }
}
