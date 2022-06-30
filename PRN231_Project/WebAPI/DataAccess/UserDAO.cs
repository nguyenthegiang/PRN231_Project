using AutoMapper;
using AutoMapper.QueryableExtensions;
using BT2TrenLop.DTO;
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
        public static List<UserDTO> GetUsers()
        {
            List<UserDTO> userDTOs;
            try
            {
                using (var context = new MyDbContext())
                {
                    MapperConfiguration config;
                    config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
                    userDTOs = context.Movies.ProjectTo<UserDTO>(config).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return userDTOs;
        }

        public static UserDTO GetUserById(int id)
        {
            UserDTO userDTO;
            try
            {
                using (var context = new MyDbContext())
                {
                    MapperConfiguration config;
                    config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
                    userDTO = context.Movies.ProjectTo<UserDTO>(config).SingleOrDefault(m => m.UserId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return userDTO;
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
                    var m = GetUserById(id);
                    var m1 = context.Users.SingleOrDefault(c => c.UserId == m.UserId);
                    context.Users.Remove(m1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
