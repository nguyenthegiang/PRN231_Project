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
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<ActorMovie> ActorMovies { get; set; }
        public virtual DbSet<CategoryMovie> CategoryMovie { get; set; }

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

            //************Movie
            optionsBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    MovieName = "Iron Man",
                    VideoPath = "Video/IronMan.mp4",
                    Description = "Iron Man is a superhero appearing in American comic books published by Marvel Comics. The character was co-created by writer and editor Stan Lee, developed by scripter Larry Lieber, and designed by artists Don Heck and Jack Kirby. The character made his first appearance in Tales of Suspense #39 (cover dated March 1963), and received his own title in Iron Man #1 (May 1968). Also in 1963, the character founded the Avengers alongside Thor, Ant-Man, Wasp and the Hulk.",
                    Duration = 126,
                    Rated = 10,
                    PublishedYear = 2008,
                    Country = "America",
                    ImagePath = "IronMan.jpg"
                },
                new Movie
                {
                    MovieId = 2,
                    MovieName = "Spider Man: No way home",
                    VideoPath = "Video/SpiderMan.mp4",
                    Description = "Spider-Man: No Home is a 2021 American superhero film based on the Marvel Comics character Peter Parker, co-produced by Columbia Pictures and Marvel Studios and distributed by Sony Pictures Releasing",
                    Duration = 148,
                    Rated = 13,
                    PublishedYear = 2021,
                    Country = "America",
                    ImagePath = "SpiderMan.jpg"
                },
                new Movie
                {
                    MovieId = 3,
                    MovieName = "Ant Man",
                    VideoPath = "Video/AntMan.mp4",
                    Description = "Ant-Man is a 2015 American superhero film based on the Marvel Comics characters of the same name: Scott Lang and Hank Pym. Produced by Marvel Studios and distributed by Walt Disney Studios Motion Pictures, it is the 12th installment in the Marvel Cinematic Universe film series.",
                    Duration = 118,
                    Rated = 9,
                    PublishedYear = 2015,
                    Country = "America",
                    ImagePath = "AntMan.jpg"
                },
                new Movie
                {
                    MovieId = 4,
                    MovieName = "Black Panther",
                    VideoPath = "Video/BlackPanther.mp4",
                    Description = "Black Panther: Black Panther is an American film based on the Marvel Comics superhero character of the same name, produced by Marvel Studios and distributed by Walt Disney Studios Motion Pictures.",
                    Duration = 135,
                    Rated = 12,
                    PublishedYear = 2018,
                    Country = "America",
                    ImagePath = "BlackPanther.jpg"
                },
                new Movie
                {
                    MovieId = 5,
                    MovieName = "Black Widow",
                    VideoPath = "Video/BlackWidow.mp4",
                    Description = "Black Widow is an American superhero film based on the Marvel Comics character of the same name, produced by Marvel Studios and distributed by Walt Disney Studios Motion Pictures. Black Widow is the 24th film in the Marvel Cinematic Universe.",
                    Duration = 133,
                    Rated = 15,
                    PublishedYear = 2021,
                    Country = "America",
                    ImagePath = "BlackWidow.jpg"
                },
                new Movie
                {
                    MovieId = 6,
                    MovieName = "Captain America",
                    VideoPath = "Video/CaptainAmerica.mp4",
                    Description = "Captain America: The First Avenger is a 2011 American superhero film based on the Marvel Comics character Captain America. Produced by Marvel Studios and released by Paramount Pictures, it is the fifth film in the Marvel Cinematic Universe.",
                    Duration = 124,
                    Rated = 14,
                    PublishedYear = 2011,
                    Country = "America",
                    ImagePath = "CaptainAmerica.jpg"
                },
                new Movie
                {
                    MovieId = 7,
                    MovieName = "Captain Marvel",
                    VideoPath = "Video/CaptainMarvel.mp4",
                    Description = "Captain Marvel is a 2019 American superhero film based on the Marvel Comics character Carol Danvers. Produced by Marvel Studios and distributed by Walt Disney Studios Motion Pictures, the work is the 21st film in the Marvel Cinematic Universe.",
                    Duration = 124,
                    Rated = 14,
                    PublishedYear = 2019,
                    Country = "America",
                    ImagePath = "CaptainMarvel.jpg"
                },
                new Movie
                {
                    MovieId = 8,
                    MovieName = "Doctor Strange in the Multiverse of Madness",
                    VideoPath = "Video/DoctorStrange.mp4",
                    Description = "The Ultimate Wizard in the Chaos Multiverse is an American superhero film due out in 2022, based on the Marvel Comics character Doctor Strange.",
                    Duration = 126,
                    Rated = 16,
                    PublishedYear = 2022,
                    Country = "America",
                    ImagePath = "DoctorStrange.jpg"
                },
                new Movie
                {
                    MovieId = 9,
                    MovieName = "The Hulk",
                    VideoPath = "Video/Hulk.mp4",
                    Description = "Hulk (also known as The Hulk) is a 2003 American superhero film based on the Marvel Comics character of the same name, directed by Ang Lee and written by James Schamus, Michael France, and John Turman from a story by Schamus. It stars Eric Bana as Bruce Banner/Hulk, alongside Jennifer Connelly, Sam Elliott, Josh Lucas, and Nick Nolte. The film explores Bruce Banner's origins. After a lab accident involving gamma radiation, he transforms into a giant, green-skinned creature known as the Hulk whenever stressed or emotionally provoked. The United States military pursues him, and he clashes with his biological father, who has dark plans for his son.",
                    Duration = 120,
                    Rated = 15,
                    PublishedYear = 2003,
                    Country = "America",
                    ImagePath = "Hulk.jpg"
                }, new Movie
                {
                    MovieId = 10,
                    MovieName = "WandaVision",
                    VideoPath = "Video/ScarletWitch.mp4",
                    Description = "WandaVision is an American television miniseries written by Jac Schaeffer for the Disney+ streaming service, based on the Marvel Comics characters Wanda Maximoff / Scarlet Witch and Vision.",
                    Duration = 129,
                    Rated = 18,
                    PublishedYear = 2021,
                    Country = "America",
                    ImagePath = "ScarletWitch.jpg"
                }
            );
        }
    }
}

