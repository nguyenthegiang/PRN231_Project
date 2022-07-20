using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.DTO
{
    public class MapperProfile :Profile
    {
        public MapperProfile()
        {
            CreateMap<Movie, MovieDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Role, RoleDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<ActorMovie, ActorMovieDTO>();
            CreateMap<CategoryMovie, CategoryMovieDTO>();
        }
    }
}
