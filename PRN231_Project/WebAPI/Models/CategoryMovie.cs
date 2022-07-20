using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    //Many-to-many relationship
    public class CategoryMovie
    {
        //The ID represents the connection between Actor and Movie
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConnectionId { get; set; }

        public int CategoryId { get; set; }
        public int MovieId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
