using MovieProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieProject.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IList<Movie>> GetAllMovieAsync();
        Task<Movie> GetMoiveByIdAsync(int id);
        Task<List<Movie>> GetMoviesByActorIdAsync(int id);
        Task<bool> AddNewMoiveAsync(Movie movie);
        bool UpdateMovie(Movie movie);
        bool RemoveMovie(Movie movie);
    }
}
