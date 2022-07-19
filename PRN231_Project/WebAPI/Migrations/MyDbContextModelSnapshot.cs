﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Models;

namespace WebAPI.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Models.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActorName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("ActorId");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            ActorId = 1,
                            ActorName = "Robert Downey Jr"
                        },
                        new
                        {
                            ActorId = 2,
                            ActorName = "Paul Rudd"
                        },
                        new
                        {
                            ActorId = 3,
                            ActorName = "Scarlett Johansson"
                        },
                        new
                        {
                            ActorId = 4,
                            ActorName = "Chadwick Boseman"
                        },
                        new
                        {
                            ActorId = 5,
                            ActorName = "Chris Evans"
                        },
                        new
                        {
                            ActorId = 6,
                            ActorName = "Anthony Mackie"
                        },
                        new
                        {
                            ActorId = 7,
                            ActorName = "John Favreau"
                        },
                        new
                        {
                            ActorId = 8,
                            ActorName = "Stan Lee"
                        },
                        new
                        {
                            ActorId = 9,
                            ActorName = "Gwyneth Paltrow"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.ActorMovie", b =>
                {
                    b.Property<int>("ConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("ConnectionId");

                    b.HasIndex("ActorId");

                    b.HasIndex("MovieId");

                    b.ToTable("ActorMovies");
                });

            modelBuilder.Entity("WebAPI.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Marvel"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Action & Adventure"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Sci-Fi & Fantasy"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Comedy"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "20th Century Fox"
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryName = "Family"
                        },
                        new
                        {
                            CategoryId = 7,
                            CategoryName = "Insect"
                        },
                        new
                        {
                            CategoryId = 8,
                            CategoryName = "Blood"
                        },
                        new
                        {
                            CategoryId = 9,
                            CategoryName = "Robot"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.CategoryMovie", b =>
                {
                    b.Property<int>("ConnectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("ConnectionId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MovieId");

                    b.ToTable("CategoryMovie");
                });

            modelBuilder.Entity("WebAPI.Models.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("PublishedYear")
                        .HasColumnType("int");

                    b.Property<int>("Rated")
                        .HasColumnType("int");

                    b.Property<string>("VideoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            Country = "America",
                            Description = "Iron Man is a superhero appearing in American comic books published by Marvel Comics. The character was co-created by writer and editor Stan Lee, developed by scripter Larry Lieber, and designed by artists Don Heck and Jack Kirby. The character made his first appearance in Tales of Suspense #39 (cover dated March 1963), and received his own title in Iron Man #1 (May 1968). Also in 1963, the character founded the Avengers alongside Thor, Ant-Man, Wasp and the Hulk.",
                            Duration = 126,
                            ImagePath = "IronMan.jpg",
                            MovieName = "Iron Man",
                            PublishedYear = 2008,
                            Rated = 10,
                            VideoPath = "Video/IronMan.mp4"
                        },
                        new
                        {
                            MovieId = 2,
                            Country = "America",
                            Description = "Spider-Man: No Home is a 2021 American superhero film based on the Marvel Comics character Peter Parker, co-produced by Columbia Pictures and Marvel Studios and distributed by Sony Pictures Releasing",
                            Duration = 148,
                            ImagePath = "SpiderMan.jpg",
                            MovieName = "Spider Man: No way home",
                            PublishedYear = 2021,
                            Rated = 13,
                            VideoPath = "Video/SpiderMan.mp4"
                        },
                        new
                        {
                            MovieId = 3,
                            Country = "America",
                            Description = "Ant-Man is a 2015 American superhero film based on the Marvel Comics characters of the same name: Scott Lang and Hank Pym. Produced by Marvel Studios and distributed by Walt Disney Studios Motion Pictures, it is the 12th installment in the Marvel Cinematic Universe film series.",
                            Duration = 118,
                            ImagePath = "AntMan.jpg",
                            MovieName = "Ant Man",
                            PublishedYear = 2015,
                            Rated = 9,
                            VideoPath = "Video/AntMan.mp4"
                        },
                        new
                        {
                            MovieId = 4,
                            Country = "America",
                            Description = "Black Panther: Black Panther is an American film based on the Marvel Comics superhero character of the same name, produced by Marvel Studios and distributed by Walt Disney Studios Motion Pictures.",
                            Duration = 135,
                            ImagePath = "BlackPanther.jpg",
                            MovieName = "Black Panther",
                            PublishedYear = 2018,
                            Rated = 12,
                            VideoPath = "Video/BlackPanther.mp4"
                        },
                        new
                        {
                            MovieId = 5,
                            Country = "America",
                            Description = "Black Widow is an American superhero film based on the Marvel Comics character of the same name, produced by Marvel Studios and distributed by Walt Disney Studios Motion Pictures. Black Widow is the 24th film in the Marvel Cinematic Universe.",
                            Duration = 133,
                            ImagePath = "BlackWidow.jpg",
                            MovieName = "Black Widow",
                            PublishedYear = 2021,
                            Rated = 15,
                            VideoPath = "Video/BlackWidow.mp4"
                        },
                        new
                        {
                            MovieId = 6,
                            Country = "America",
                            Description = "Captain America: The First Avenger is a 2011 American superhero film based on the Marvel Comics character Captain America. Produced by Marvel Studios and released by Paramount Pictures, it is the fifth film in the Marvel Cinematic Universe.",
                            Duration = 124,
                            ImagePath = "CaptainAmerica.jpg",
                            MovieName = "Captain America",
                            PublishedYear = 2011,
                            Rated = 14,
                            VideoPath = "Video/CaptainAmerica.mp4"
                        },
                        new
                        {
                            MovieId = 7,
                            Country = "America",
                            Description = "Captain Marvel is a 2019 American superhero film based on the Marvel Comics character Carol Danvers. Produced by Marvel Studios and distributed by Walt Disney Studios Motion Pictures, the work is the 21st film in the Marvel Cinematic Universe.",
                            Duration = 124,
                            ImagePath = "CaptainMarvel.jpg",
                            MovieName = "Captain Marvel",
                            PublishedYear = 2019,
                            Rated = 14,
                            VideoPath = "Video/CaptainMarvel.mp4"
                        },
                        new
                        {
                            MovieId = 8,
                            Country = "America",
                            Description = "The Ultimate Wizard in the Chaos Multiverse is an American superhero film due out in 2022, based on the Marvel Comics character Doctor Strange.",
                            Duration = 126,
                            ImagePath = "DoctorStrange.jpg",
                            MovieName = "Doctor Strange in the Multiverse of Madness",
                            PublishedYear = 2022,
                            Rated = 16,
                            VideoPath = "Video/DoctorStrange.mp4"
                        },
                        new
                        {
                            MovieId = 9,
                            Country = "America",
                            Description = "Hulk (also known as The Hulk) is a 2003 American superhero film based on the Marvel Comics character of the same name, directed by Ang Lee and written by James Schamus, Michael France, and John Turman from a story by Schamus. It stars Eric Bana as Bruce Banner/Hulk, alongside Jennifer Connelly, Sam Elliott, Josh Lucas, and Nick Nolte. The film explores Bruce Banner's origins. After a lab accident involving gamma radiation, he transforms into a giant, green-skinned creature known as the Hulk whenever stressed or emotionally provoked. The United States military pursues him, and he clashes with his biological father, who has dark plans for his son.",
                            Duration = 120,
                            ImagePath = "Hulk.jpg",
                            MovieName = "The Hulk",
                            PublishedYear = 2003,
                            Rated = 15,
                            VideoPath = "Video/Hulk.mp4"
                        },
                        new
                        {
                            MovieId = 10,
                            Country = "America",
                            Description = "WandaVision is an American television miniseries written by Jac Schaeffer for the Disney+ streaming service, based on the Marvel Comics characters Wanda Maximoff / Scarlet Witch and Vision.",
                            Duration = 129,
                            ImagePath = "ScarletWitch.jpg",
                            MovieName = "WandaVision",
                            PublishedYear = 2021,
                            Rated = 18,
                            VideoPath = "Video/ScarletWitch.mp4"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            RoleName = "User"
                        },
                        new
                        {
                            RoleId = 2,
                            RoleName = "Admin"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "admin@gmail.com",
                            Password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
                            RoleId = 2,
                            Username = "admin"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "buingochuyen17462@gmail.com",
                            Password = "00ab9b0c4e58c5e0b039cc4f5213bfd41c2d4e00211b618bae67cc33a32e73d0",
                            RoleId = 1,
                            Username = "Huyen"
                        },
                        new
                        {
                            UserId = 3,
                            Email = "nguyenthe.giang.775@gmail.com",
                            Password = "054f29cb6d48ccea661d6108fdcdd0a2f1d40b0141ba25fc9c684a1da873499b",
                            RoleId = 1,
                            Username = "Giang"
                        },
                        new
                        {
                            UserId = 4,
                            Email = "thong21145@gmail.com",
                            Password = "7710e1b184cbc633d23324649f6f50c0650df3d2bbf939ed9e60763bd9610921",
                            RoleId = 1,
                            Username = "Thong"
                        });
                });

            modelBuilder.Entity("WebAPI.Models.ActorMovie", b =>
                {
                    b.HasOne("WebAPI.Models.Actor", "Actor")
                        .WithMany("ActorMovies")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.Movie", "Movie")
                        .WithMany("ActorMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("WebAPI.Models.CategoryMovie", b =>
                {
                    b.HasOne("WebAPI.Models.Category", "Category")
                        .WithMany("CategoryMovies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAPI.Models.Movie", "Movie")
                        .WithMany("CategoryMovie")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("WebAPI.Models.User", b =>
                {
                    b.HasOne("WebAPI.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WebAPI.Models.Actor", b =>
                {
                    b.Navigation("ActorMovies");
                });

            modelBuilder.Entity("WebAPI.Models.Category", b =>
                {
                    b.Navigation("CategoryMovies");
                });

            modelBuilder.Entity("WebAPI.Models.Movie", b =>
                {
                    b.Navigation("ActorMovies");

                    b.Navigation("CategoryMovie");
                });

            modelBuilder.Entity("WebAPI.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
