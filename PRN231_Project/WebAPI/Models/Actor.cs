using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Actor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ActorId { get; set; }

        [Required]
        [StringLength(500)]
        public string ActorName { get; set; }
    }
}
