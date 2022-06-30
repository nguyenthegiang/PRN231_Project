using AutoMapper;
using AutoMapper.QueryableExtensions;
using BT2TrenLop.DTO;
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
        public static User Login(string email, string password)
        {
            User User = null;
            try
            {
                using var db = new MyDbContext();
                MapperConfiguration config = new MapperConfiguration(
                    cfg => cfg.AddProfile(new MapperProfile()));
                User = db.Users.Where(u =>
                    EF.Functions.Like(u.Email, email)
                    && u.Password.Equals(password)
                ).ProjectTo<User>(config).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return User;
        }
    }
}
