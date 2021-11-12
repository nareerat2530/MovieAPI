using MovieProject.Interfaces;
using MovieProject.Models;
using MovieProject.ViewModels.Actor.ActorMovie;
using MovieProject.ViewModels.Movie;

namespace MovieProject.Mapper
{
    public class MovieMapper : IMovieMapper
    {




        public Movie Map(MovieViewModel model)
        {

            var movie = new Movie()
            {

                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                EndDate = model.EndDate,
                StartDate = model.StartDate,
                ImageUrl = model.ImageUrl,
                MovieCategory = model.MovieCategory,
                CinemaId = model.CinemaId,
                ProducerId = model.ProducerId



            };
            return movie;
        }
        public Movie Map(PostMovieViewModel model)
        {
            var movie = new Movie()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                EndDate = model.EndDate,
                StartDate = model.StartDate,
                ImageUrl = model.ImageUrl,
                MovieCategory = model.MovieCategory,
                CinemaId = model.CinemaId,
                ProducerId = model.ProducerId
            };
            return movie;
        }

        public Movie Map(PostMovieViewModel model, Movie movie)
        {
            movie.Name = model.Name;
            movie.Description = model.Description;
            movie.Price = model.Price;
            movie.StartDate = model.StartDate;
            movie.EndDate = model.EndDate;
            movie.ImageUrl = movie.ImageUrl;
            movie.CinemaId = model.CinemaId;
            movie.ProducerId = model.ProducerId;
            return movie;



        }

        public Movie Map(UpdateMovieViewmodel model, Movie movie)
        {
            movie.Name = model.Name;
            movie.Description = model.Description;
            movie.Price = model.Price;
            movie.StartDate = model.StartDate;
            movie.EndDate = model.EndDate;
            movie.ImageUrl = model.ImageUrl;
            movie.MovieCategory = model.MovieCategory;
            return movie;
        }
    }

}
