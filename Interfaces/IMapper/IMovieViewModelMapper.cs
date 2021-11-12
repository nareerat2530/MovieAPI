using MovieProject.Models;
using MovieProject.ViewModels.Movie;
using System.Collections.Generic;

namespace MovieProject.Interfaces.IMapper
{
    public interface IMovieViewModelMapper
    {
        //List<MovieViewModel> Map(IEnumerable<Movie> movies);
        MovieViewModel Map(Movie movie);

        List<GetAllMovieViewModel> Map(IEnumerable<Movie> movie);
    }
}
