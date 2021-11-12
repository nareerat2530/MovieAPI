using Microsoft.EntityFrameworkCore;
using MovieProject.Data;
using MovieProject.Interfaces;
using MovieProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository

    {
        private readonly AppDbContext _context;
        public MovieRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AddNewMoiveAsync(Movie movie)
        {
            try
            {

                await _context.Movies.AddAsync(movie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<Movie>> GetAllMovieAsync()
        {
            return await _context.Movies.Include(c => c.Producer).Include(c => c.Cinema).Include(c => c.ActorMovies).ToListAsync();


        }

        public async Task<Movie> GetMoiveByIdAsync(int id)
        {
            return await _context.Movies.Include(m => m.ActorMovies).FirstOrDefaultAsync(m => m.Id == id);
        }



        public async Task<List<Movie>> GetMoviesByActorIdAsync(int id)
        {
            var movie = await _context.Movies.ToListAsync();
            var actorMovie = await _context.ActorMovies.Where(am => am.ActorId == id).ToListAsync();
            var result = movie.Where(r => actorMovie.Any(am => am.MovieId == r.Id)).ToList();
            return result;
        }

        public bool RemoveMovie(Movie movie)
        {
            try
            {
                _context.Movies.Remove(movie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateMovie(Movie movie)
        {
            try
            {
                _context.Movies.Update(movie);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
