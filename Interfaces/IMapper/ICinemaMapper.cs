using MovieProject.Models;
using MovieProject.ViewModels.Cinema;
using MovieProject.ViewModels.Movie;

namespace MovieProject.Interfaces.IMapper
{
    public interface ICinemaMapper
    {
        Cinema Map(CinemaViewModel model);
        Cinema Map(PostCinemaViewModel model, Cinema cimena);
        Cinema Map(PostCinemaViewModel model);


    }
}
