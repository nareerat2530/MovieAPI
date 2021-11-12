using Microsoft.EntityFrameworkCore;
using MovieProject.Data;
using MovieProject.Interfaces;
using MovieProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProject.Repository
{
    public class ActorMovieRepository : Repository<ActorMovie>, IActorMovieRepository
    {
        private readonly AppDbContext _context;
        public ActorMovieRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> AddNewActorToMovie(ActorMovie actormovie)
        {
            try
            {
                await _context.ActorMovies.AddAsync(actormovie);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ActorMovie> CheckIfActorWithMovieExist(int movieId, int actorId)
        {
            var getAllActorMovie = await _context.ActorMovies.ToListAsync();
            var toCheck = getAllActorMovie.FirstOrDefault(am => am.ActorId == actorId && am.MovieId == movieId);

            return toCheck;

        }










    }
}
