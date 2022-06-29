﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using BT2TrenLop.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MyDbContext context;
        private MapperConfiguration config;
        private IMapper mapper;

        public MovieController(MyDbContext _context)
        {
            context = _context;
            config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            mapper = config.CreateMapper();
        }

        [HttpGet]
        public IActionResult GetAllMovie()
        {
            List<MovieDTO> movieDTOs;
            movieDTOs = context.Movies.ProjectTo<MovieDTO>(config).ToList();
            if (movieDTOs == null)
            {
                return NotFound(); //Response with status code: 404
            }
            return Ok(movieDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetAllMovie(int id)
        {
            MovieDTO movieDTO;
            movieDTO = context.Movies.ProjectTo<MovieDTO>(config).FirstOrDefault(m => m.MovieId == id);
            if (movieDTO == null)
            {
                return NotFound(); //Response with status code: 404
            }
            return Ok(movieDTO);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            try
            {
                context.Movies.Add(movie);
                context.SaveChanges();
                return Ok(movie);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put(int id, Movie movie)
        {
            try
            {
                Movie movi = context.Movies.FirstOrDefault(m => m.MovieId == id);
                if (movi == null)
                {
                    return NotFound();
                }
                context.Entry<Movie>(movi).State = EntityState.Detached;
                context.Movies.Update(movie);
                context.SaveChanges();
                return Ok(movie);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
