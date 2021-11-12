using MovieProject.Models;
using MovieProject.ViewModels.Actor.ActorMovie;
using MovieProject.ViewModels.Movie;

namespace MovieProject.Interfaces
{
    public interface IMovieMapper
    {
        Movie Map(MovieViewModel model);
        Movie Map(PostMovieViewModel model);
        Movie Map(PostMovieViewModel model, Movie movie);
        Movie Map(UpdateMovieViewmodel model, Movie movie);

    }
}
