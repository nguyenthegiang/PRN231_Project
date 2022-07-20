using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO
{
    public class ActorMovieDTO
    {
        public int ConnectionId { get; set; }

        public int ActorId { get; set; }
        public int MovieId { get; set; }
    }
}
