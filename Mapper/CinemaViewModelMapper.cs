using MovieProject.Interfaces.IMapper;
using MovieProject.Models;

using MovieProject.ViewModels.Movie;
using System.Collections.Generic;
using System.Linq;

namespace MovieProject.Mapper
{
    public class CinemaViewModelMapper : ICinemaViewModelMapper
    {
        public List<CinemaViewModel> Map(IEnumerable<Cinema> cinemas)
        {
            return cinemas.Select(c => new CinemaViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,


            }).ToList();
        }

        public CinemaViewModel Map(Cinema cinema)
        {
            return new()
            {
                Id = cinema.Id,
                Name = cinema.Name,
                Description = cinema.Description,

            };
        }
    }



}
