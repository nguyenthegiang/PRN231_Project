using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebAPI.Models
{
    public class MyDbContext : DbContext
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
            //Read JSON File -> ConnectionString
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DBContext"));
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            /*************Data Seed*************/
            //************Role
            optionsBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "User" },
                new Role { RoleId = 2, RoleName = "Admin" }
            );

            //************User
            optionsBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Email = "admin@gmail.com",
                    Username = "admin",
                    Password = Helper.Hashing.Encrypt("admin"),
                    RoleId = 2
                },
                new User
                {
                    UserId = 2,
                    Email = "buingochuyen17462@gmail.com",
                    Username = "Huyen",
                    Password = Helper.Hashing.Encrypt("huyen"),
                    RoleId = 1
                },
                new User
                {
                    UserId = 3,
                    Email = "nguyenthe.giang.775@gmail.com",
                    Username = "Giang",
                    Password = Helper.Hashing.Encrypt("giang"),
                    RoleId = 1
                },
                new User
                {
                    UserId = 4,
                    Email = "thong21145@gmail.com",
                    Username = "Thong",
                    Password = Helper.Hashing.Encrypt("thong"),
                    RoleId = 1
                }
            );

            //************Category
            optionsBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Marvel"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Action & Adventure"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Sci-Fi & Fantasy"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Comedy"
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "20th Century Fox"
                },
                new Category
                {
                    CategoryId = 6,
                    CategoryName = "Family"
                },
                new Category
                {
                    CategoryId = 7,
                    CategoryName = "Insect"
                },
                new Category
                {
                    CategoryId = 8,
                    CategoryName = "Blood"
                },
                new Category
                {
                    CategoryId = 9,
                    CategoryName = "Robot"
                }
            );

            //************Actor
            optionsBuilder.Entity<Actor>().HasData(
                new Actor
                {
                    ActorId = 1,
                    ActorName = "Robert Downey Jr"
                },
                new Actor
                {
                    ActorId = 2,
                    ActorName = "Paul Rudd"
                },
                new Actor
                {
                    ActorId = 3,
                    ActorName = "Scarlett Johansson"
                },
                new Actor
                {
                    ActorId = 4,
                    ActorName = "Chadwick Boseman"
                },
                new Actor
                {
                    ActorId = 5,
                    ActorName = "Chris Evans"
                },
                new Actor
                {
                    ActorId = 6,
                    ActorName = "Anthony Mackie"
                },
                new Actor
                {
                    ActorId = 7,
                    ActorName = "John Favreau"
                },
                new Actor
                {
                    ActorId = 8,
                    ActorName = "Stan Lee"
                },
                new Actor
                {
                    ActorId = 9,
                    ActorName = "Gwyneth Paltrow"
                }
            );

            optionsBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    MovieName = "Iron Man",
                    VideoPath = "Video/IronMan.mp4",
                    Description = "Very cool",
                    Duration = 120,
                    Rated = 12,
                    PublishedYear = 2001,
                    Country = "America",
                    ImagePath = "Image/IronMan.jpg"
                },
                new Movie
                {
                    MovieId = 2,
                    MovieName = "Spider Man",
                    VideoPath = "Video/SpiderMan.mp4",
                    Description = "Very good",
                    Duration = 120,
                    Rated = 12,
                    PublishedYear = 2001,
                    Country = "America",
                    ImagePath = "Image/SpiderMan.jpg"
                },
                new Movie
                {
                    MovieId = 3,
                    MovieName = "Ant Man",
                    VideoPath = "Video/AntMan.mp4",
                    Description = "So cool",
                    Duration = 120,
                    Rated = 12,
                    PublishedYear = 2001,
                    Country = "America",
                    ImagePath = "Image/AntMan.jpg"
                },
                new Movie
                {
                    MovieId = 4,
                    MovieName = "Black Panther",
                    VideoPath = "Video/BlackPanther.mp4",
                    Description = "So cool",
                    Duration = 120,
                    Rated = 12,
                    PublishedYear = 2001,
                    Country = "America",
                    ImagePath = "Image/BlackPanther.jpg"
                },
                new Movie
                {
                    MovieId = 5,
                    MovieName = "Black Widow",
                    VideoPath = "Video/BlackWidow.mp4",
                    Description = "So cool",
                    Duration = 120,
                    Rated = 12,
                    PublishedYear = 2001,
                    Country = "America",
                    ImagePath = "Image/BlackWidow.jpg"
                },
                new Movie
                {
                    MovieId = 6,
                    MovieName = "Captain America",
                    VideoPath = "Video/CaptainAmerica.mp4",
                    Description = "So cool",
                    Duration = 120,
                    Rated = 12,
                    PublishedYear = 2001,
                    Country = "America",
                    ImagePath = "Image/CaptainAmerica.jpg"
                },
                new Movie
                {
                    MovieId = 7,
                    MovieName = "Captain Marvel",
                    VideoPath = "Video/CaptainMarvel.mp4",
                    Description = "So cool",
                    Duration = 120,
                    Rated = 12,
                    PublishedYear = 2001,
                    Country = "America",
                    ImagePath = "Image/CaptainMarvel.jpg"
                },
                new Movie
                {
                    MovieId = 8,
                    MovieName = "Doctor Strange",
                    VideoPath = "Video/DoctorStrange.mp4",
                    Description = "So cool",
                    Duration = 120,
                    Rated = 12,
                    PublishedYear = 2001,
                    Country = "America",
                    ImagePath = "Image/DoctorStrange.jpg"
                },
                new Movie
                {
                    MovieId = 9,
                    MovieName = "Hulk",
                    VideoPath = "Video/Hulk.mp4",
                    Description = "So cool",
                    Duration = 120,
                    Rated = 12,
                    PublishedYear = 2001,
                    Country = "America",
                    ImagePath = "Image/Hulk.jpg"
                }, new Movie
                {
                    MovieId = 10,
                    MovieName = "Scarlet Witch",
                    VideoPath = "Video/ScarletWitch.mp4",
                    Description = "So cool",
                    Duration = 120,
                    Rated = 12,
                    PublishedYear = 2001,
                    Country = "America",
                    ImagePath = "Image/ScarletWitch.jpg"
                }
            );
        }
    }
}

