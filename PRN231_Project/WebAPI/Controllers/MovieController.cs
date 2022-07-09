using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.IRepository;
using WebAPI.Models;
using WebAPI.Repositories;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private IMovieRepository repository;

        public MovieController(IMovieRepository repository, IWebHostEnvironment hostingEnvironment)
        {
            this.repository = repository;
            _hostingEnvironment = hostingEnvironment;
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

        /**************Client: Paging Movies & Watch Movie**************/
        //Paging List Movies
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Paging10Movie(int page = 1) => repository.Paging10Movie(page);

        //Function [Watch Video]
        [HttpGet("GetVideoContent")]
        public async Task<IActionResult> WatchMovie(int videoId)
        {
            Movie movie = repository.GetMovieById(videoId);
            string path = Path.Combine(_hostingEnvironment.WebRootPath, movie.VideoPath);
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 65536, FileOptions.Asynchronous | FileOptions.SequentialScan))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            //enableRangeProcessing = true
            return File(memory, "application/octet-stream", Path.GetFileName(path), true);
        }

        /**************Admin: CRUD Movie**************/
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Paging5Movie(int page = 1) => repository.GetListMovies(page);


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
