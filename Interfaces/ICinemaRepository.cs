using MovieProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieProject.Interfaces
{
    public interface ICinemaRepository
    {
        Task<IList<Cinema>> GetAllCinemaAsync();
        Task<Cinema> GetCinemaByIdAsync(int id);
        Task<bool> AddNewCinemaAsync(Cinema cinema);
        bool UpdateCinema(Cinema cinema);
        bool RemoveCinema(Cinema cinema);
    }
}
