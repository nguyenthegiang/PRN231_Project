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
        
        public string Path { get; set; }
        
        public string Description { get; set; }
       
        public string Duration { get; set; }
        
        public int Rated { get; set; }
        
        public string PublishedYear { get; set; }
        
        public string Country { get; set; }
        
        public string Image { get; set; }


    }
}
