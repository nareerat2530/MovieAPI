using MovieProject.Models;
using System.Threading.Tasks;

namespace MovieProject.Interfaces
{
    public interface IActorMovieRepository
    {
        Task<bool> AddNewActorToMovie(ActorMovie actormovie);
        Task<ActorMovie> CheckIfActorWithMovieExist(int movieId, int actorId);


    }
}
