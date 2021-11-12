using System;
using System.Threading.Tasks;

namespace MovieProject.Interfaces
{
    public interface IUnitOfwork : IDisposable
    {
        IActorRepository ActorRepository { get; }
        IMovieRepository MovieRepository { get; }
        ICinemaRepository CinemaRepository { get; }
        IProducerRerository ProducerRerository { get; }
        IActorMovieRepository ActorMovieRepository { get; }
        Task<bool> Complete();
    }
}
