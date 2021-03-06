using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.DataAccess
{
    public class UserDAO
    {
        public static List<User> GetUsers()
        {
            List<User> users;
            try
            {
                using (var context = new MyDbContext())
                {
                    users = context.Users.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return users;
        }

        public static User GetUserById(int id)
        {
            User user;
            try
            {
                using (var context = new MyDbContext())
                {
                    user = context.Users.SingleOrDefault(u => u.UserId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return user;
        }

        public static UserDTO GetUserByFacebookUID(string facebookUID)
        {
            UserDTO user;
            try
            {
                using (var context = new MyDbContext())
                {
                    MapperConfiguration config = new MapperConfiguration(
                       cfg => cfg.AddProfile(new MapperProfile()));
                    user = context.Users.Where(u =>
                        u.IsFacebookUser && u.FacebookUID == facebookUID
                    )
                    .ProjectTo<UserDTO>(config)
                    .FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return user;
        }

        public static List<User> GetUserByName(string name)
        {
            List<User> users;
            try
            {
                using (var context = new MyDbContext())
                {
                    users = context.Users.Where(u => u.Username.Contains(name)).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return users;
        }
        public static List<User> GetUserByEmail(string email)
        {
            List<User> users;
            try
            {
                using (var context = new MyDbContext())
                {
                    users = context.Users.Where(u => u.Email == email).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return users;
        }

        public static void SaveUser(User user)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateUser(User user)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Entry<User>(user).State =
                        Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.Entry(user).Property(x => x.FacebookUID).IsModified = false;
                    context.Entry(user).Property(x => x.IsFacebookUser).IsModified = false;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteUser(int id)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var u = GetUserById(id);
                    context.Users.Remove(u);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /***********Authentication***********/
        public static UserDTO Login(string email, string password)
        {
            UserDTO User = null;
            try
            {
                using var db = new MyDbContext();
                MapperConfiguration config = new MapperConfiguration(
                    cfg => cfg.AddProfile(new MapperProfile()));
                User = db.Users.Where(u =>
                    EF.Functions.Like(u.Email, email)
                    && u.Password.Equals(password)
                ).ProjectTo<UserDTO>(config).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return User;
        }
    }
}
