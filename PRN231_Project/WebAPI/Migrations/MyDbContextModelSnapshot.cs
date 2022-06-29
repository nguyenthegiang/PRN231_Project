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
                            CategoryName = "DC"
                        });
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

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublishedYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rated")
                        .HasColumnType("int");

                    b.HasKey("MovieId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            MovieName = "Iron Man",
                            Rated = 0
                        },
                        new
                        {
                            MovieId = 2,
                            MovieName = "Spider Man",
                            Rated = 0
                        },
                        new
                        {
                            MovieId = 3,
                            MovieName = "Ant Man",
                            Rated = 0
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
                        Email = "adminse1501@gmail.com",
                        Password = "admin",
                        RoleId = 2,
                        Username = "admin"
                    },
                    new
                    {
                        UserId = 2,
                        Email = "a@gmail.com",
                        Password = "aaa",
                        RoleId = 1,
                        Username = "a"
                    },
                    new
                    {
                        UserId = 3,
                        Email = "b@gmail.com",
                        Password = "bbb",
                        RoleId = 1,
                        Username = "b"
                    });
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

            modelBuilder.Entity("WebAPI.Models.Role", b =>
            {
                b.Navigation("Users");
            });
#pragma warning restore 612, 618
        }
    }
}
