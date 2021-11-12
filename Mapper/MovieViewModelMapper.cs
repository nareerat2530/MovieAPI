using MovieProject.Interfaces.IMapper;
using MovieProject.Models;
using MovieProject.ViewModels.Movie;
using System.Collections.Generic;
using System.Linq;

namespace MovieProject.Mapper
{
    public class MovieViewModelMapper : IMovieViewModelMapper
    {
        //public List<MovieViewModel> Map(IEnumerable<Movie> movies)
        //{
        //    return movies.Select(m => new MovieViewModel()
        //    {

        //        Id = m.Id,
        //        Name = m.Name,
        //        Description = m.Description,
        //        Price = m.Price,
        //        StartDate = m.StartDate,
        //        EndDate = m.EndDate,
              
        //        ProducerId = (int)m.ProducerId,
        //        CinemaId = (int)m.CinemaId,
        //    }).ToList();
        //}
        public List<GetAllMovieViewModel> Map(IEnumerable<Movie> movies)
        {
            return movies.Select(movie => new GetAllMovieViewModel()
            {
                Id = movie.Id,
                Name = movie.Name,
                Description = movie.Description,
                Price = movie.Price,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                MovieCategory = movie.MovieCategory,
                ImageUrl = movie.ImageUrl,
                //Looking for ActorId
                ActorIds = movie.ActorMovies.Where(actorMovie => actorMovie.MovieId == movie.Id).Select(actorMovie => actorMovie.ActorId).ToList(),
               
                ProducerId = (int)movie.ProducerId,
                CinemaId = (int)movie.CinemaId,
            }).ToList();
          
           
        }
       



        public MovieViewModel Map(Movie movie )
        {
           var banan = new MovieViewModel()
            {
                Id = movie.Id,
                Name = movie.Name,
                Description = movie.Description,
                Price = movie.Price,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                ImageUrl = movie.ImageUrl,
                MovieCategory = movie.MovieCategory,
                ActorIds = movie.ActorMovies.Where(m => m.MovieId == movie.Id).Select(n => n.ActorId).ToList(),
                ProducerId = (int)movie.ProducerId,
                CinemaId = (int)movie.CinemaId,
            };

            return banan;
        }

       
        
    }
}
