using MovieProject.Data;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieProject.ViewModels.Actor.ActorMovie
{
    public class UpdateMovieViewmodel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]

        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }
    }
}
