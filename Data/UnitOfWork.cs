using MovieProject.Data;
using MovieProject.Interfaces;
using System.Threading.Tasks;

namespace MovieProject.Repository
{
    public class UnitOfWork : IUnitOfwork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IActorRepository ActorRepository => new ActorRepository(_context);
        public IMovieRepository MovieRepository => new MovieRepository(_context);
        public ICinemaRepository CinemaRepository => new CinemaRepository(_context);
        public IProducerRerository ProducerRerository => new ProducerRepository(_context);
        public IActorMovieRepository ActorMovieRepository => new ActorMovieRepository(_context);



        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
