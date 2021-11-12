using MovieProject.Models;
using MovieProject.ViewModels.Movie;
using System.Collections.Generic;

namespace MovieProject.Interfaces.IMapper
{
    public interface ICinemaViewModelMapper
    {
        List<CinemaViewModel> Map(IEnumerable<Cinema> cinemas);
        CinemaViewModel Map(Cinema cinema);

    }
}
