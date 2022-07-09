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
using WebAPI.IRepository;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MyDbContext context;
        private MapperConfiguration config;
        private IMapper mapper;

        private IMovieRepository repository = new MovieRepository();

        public MovieController(MyDbContext _context)
        {
            context = _context;
            config = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            mapper = config.CreateMapper();
        }

        //Without Paging
       /* [HttpGet]
        public IActionResult GetAllMovie()
        {
            List<MovieDTO> movieDTOs;
            movieDTOs = context.Movies.ProjectTo<MovieDTO>(config).ToList();
            if (movieDTOs == null)
            {
                return NotFound(); //Response with status code: 404
            }
            return Ok(movieDTOs);
        }*/

        // With Paging
        /*[HttpGet]
        public IActionResult GetAllMoviePaging(int page=1)
        {
            List<MovieDTO> movieDTOs;
            movieDTOs = context.Movies.ProjectTo<MovieDTO>(config).Skip((page - 1) * 5).Take(5).ToList();
            if (movieDTOs == null)
            {
                return NotFound(); //Response with status code: 404
            }
            return Ok(movieDTOs);
        }*/

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovies(int page = 1) => repository.GetListMovies(page);

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var m = repository.GetMovieById(id);
            /*MovieDTO movieDTO;
            movieDTO = context.Movies.ProjectTo<MovieDTO>(config).FirstOrDefault(m => m.MovieId == id);*/
            if (m == null)
            {
                return NotFound(); //Response with status code: 404
            }
            return Ok(m);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            try
            {
                repository.SaveMovie(movie);           
                return Ok(movie);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("id")]
        public IActionResult UpdateMovie(int id, Movie movie)
        {
            try
            {
                var mTmp = repository.GetMovieById(id);
                
                if (mTmp == null)
                {
                    return NotFound();
                }
                repository.UpdateMovie(movie);
                return Ok(movie);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("id")]
        public IActionResult DeleteMovie(int id)
        {
            try
            {
                var m = repository.GetMovieById(id);
                if (m == null)
                {
                    return NotFound();
                }
                repository.DeleteMovie(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
