using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebAPI.Models
{
    public class MyDbContext: DbContext
    {
        public MyDbContext()
        {
        }
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DBContext"));
        }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            optionsBuilder.Entity<Movie>().HasData(
                new Movie { MovieId = 1, MovieName = "Iron Man" },
                new Movie { MovieId = 2, MovieName = "Spider Man" },
                new Movie { MovieId = 3, MovieName = "Ant Man" }
            );

            optionsBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Marvel" },
                new Category { CategoryId = 2, CategoryName = "DC" }              
            );

            optionsBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "User" },
                new Role { RoleId = 2, RoleName = "Admin" }
            );

            optionsBuilder.Entity<User>().HasData(
                new User { UserId = 1, Email = "adminse1501@gmail.com", Username = "admin", Password = "admin", RoleId = 2 },
                new User { UserId = 2, Email = "a@gmail.com", Username = "a", Password = "aaa", RoleId = 1 },
                new User { UserId = 3, Email = "b@gmail.com", Username = "b", Password = "bbb", RoleId = 1 }
            );
        }
    }
}

