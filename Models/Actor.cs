using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieProject.Models
{
    public class Actor
    {

        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string ImageURL { get; set; }
        public string Bio { get; set; }
        public ICollection<ActorMovie> ActorMovies { get; set; }

    }
}
