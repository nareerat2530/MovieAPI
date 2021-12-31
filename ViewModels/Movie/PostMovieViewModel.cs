using MovieProject.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieProject.ViewModels.Movie
{
    public class PostMovieViewModel
    {


        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }
        public int? ProducerId { get; set; }
        public int? CinemaId { get; set; }
        
     


    }
}
