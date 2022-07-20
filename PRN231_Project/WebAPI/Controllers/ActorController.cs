using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Authentication;
using WebAPI.DTO;
using WebAPI.IRepository;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private IActorRepository repository;

        public ActorController(IActorRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Actor>> GetActors() => repository.GetListActors();

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Actor>> GetActorByMoiveId(int id) => repository.GetActorsByMovieId(id);
    }
}
