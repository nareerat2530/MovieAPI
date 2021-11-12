using Microsoft.EntityFrameworkCore;
using MovieProject.Data;
using MovieProject.Interfaces;
using MovieProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieProject.Repository
{
    public class ActorRepository : Repository<Actor>, IActorRepository
    {
        private readonly AppDbContext _context;
        public ActorRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AddNewActorAsync(Actor actor)
        {
            try
            {

                await _context.Actors.AddAsync(actor);
                return true;
            }
            catch
            {
                return false;
            }
        }



        public async Task<Actor> GetActorById(int id)
        {
            return await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<IList<Actor>> GetAllActorAsync()
        {
            return await _context.Actors.Include(c => c.ActorMovies).ToListAsync();
        }

        public bool RemoveActor(Actor actor)
        {
            try
            {
                _context.Actors.Remove(actor);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateActor(Actor actor)
        {
            try
            {
                _context.Actors.Update(actor);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
