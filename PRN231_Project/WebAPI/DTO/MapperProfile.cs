using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.Models;

namespace BT2TrenLop.DTO
{
    public class MapperProfile :Profile
    {
        public MapperProfile()
        {
            CreateMap<Movie, MovieDTO>();
            
        }
    }
}
