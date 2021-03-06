using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Role
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        [Required]
        [StringLength(500)]
        public string RoleName { get; set; }

        //one-to-many relationship
        public virtual ICollection<User> Users { get; set; }
    }
    public enum Roles
    {
        User = 1,
        Admin = 2
    }
}
