using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieProject.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
