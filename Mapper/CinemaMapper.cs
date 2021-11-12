using MovieProject.Interfaces.IMapper;
using MovieProject.Models;
using MovieProject.ViewModels.Cinema;
using MovieProject.ViewModels.Movie;

namespace MovieProject.Mapper
{
    public class CinemaMapper : ICinemaMapper
    {
        public Cinema Map(CinemaViewModel model)
        {
            return new()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };
        }

        public Cinema Map(PostCinemaViewModel model, Cinema cimena)
        {
            cimena.Id = cimena.Id;
            cimena.Name = model.Name;
            cimena.Description = model.Description;
            return cimena;
        }



        public Cinema Map(PostCinemaViewModel model)
        {
            return new()
            {

                Name = model.Name,
                Description = model.Description
            };
        }
    }
}
