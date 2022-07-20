using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO
{
    public class CategoryMovieDTO
    {
        public int ConnectionId { get; set; }

        public int CategoryId { get; set; }
        public int MovieId { get; set; }
    }
}
