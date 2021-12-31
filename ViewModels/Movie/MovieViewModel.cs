using MovieProject.Data;
using MovieProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieProject.ViewModels.Movie
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }
        public List<int> ActorIds { get; set; }
        public int? ProducerId { get; set; }
        public int? CinemaId { get; set; }
    }
}
