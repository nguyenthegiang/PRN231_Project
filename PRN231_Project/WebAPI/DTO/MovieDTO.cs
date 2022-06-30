using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTO
{
    public class MovieDTO
    {
       
        public int MovieId { get; set; }
        
        public string MovieName { get; set; }

        public string Path { get; set; }

        public string Description { get; set; }

        public string Duration { get; set; }

        public int Rated { get; set; }

        public string PublishedYear { get; set; }

        public string Country { get; set; }

        public string Image { get; set; }

        public virtual CategoryDTO Category { get; set; }

    }
}
