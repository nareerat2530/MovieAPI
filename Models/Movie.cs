using MovieProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieProject.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        [ForeignKey("CinemaId")]
        public int? CinemaId { get; set; }
        public Cinema Cinema { get; set; }

        [ForeignKey("ProducerId")]
        public int? ProducerId { get; set; }
        public Producer Producer { get; set; }
        public ICollection<ActorMovie> ActorMovies { get; set; }
    }
}
