using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Movie
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }

        [Required]
        [StringLength(500)]
        public string MovieName { get; set; }
        
        //path to location of video of movie
        public string VideoPath { get; set; }
        
        public string Description { get; set; }
       
        //Duration in minutes
        public int Duration { get; set; }
        
        //age allowed for movie
        public int Rated { get; set; }
        
        public int PublishedYear { get; set; }
        
        public string Country { get; set; }
        
        //path to location of poster of movie
        public string ImagePath { get; set; }

        //many-to-many relationship
        public virtual ICollection<ActorMovie> ActorMovies { get; set; }

        //many-to-many relationship
        public virtual ICollection<CategoryMovie> CategoryMovie { get; set; }

    }
}
