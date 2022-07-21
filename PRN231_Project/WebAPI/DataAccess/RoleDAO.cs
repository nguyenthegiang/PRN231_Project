using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.DataAccess
{
    public class RoleDAO
    {
        public static List<Role> GetRoles()
        {
            List<Role> roles;
            try
            {
                using (var context = new MyDbContext())
                {
                    roles = context.Roles.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return roles;
        }

        public static Role GetRoleById(int id)
        {
            Role role;
            try
            {
                using (var context = new MyDbContext())
                {
                    role = context.Roles.SingleOrDefault(r => r.RoleId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return role;
        }
    }
}
