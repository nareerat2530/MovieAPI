using MovieProject.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.ViewModels.Movie
{
    public class GetAllMovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }
        public List<int> ActorIds { get; set; }
        public int ProducerId { get; set; }
        public int CinemaId { get; set; }
    }
}
