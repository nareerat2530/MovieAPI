using MovieProject.Models;
using System.Threading.Tasks;

namespace MovieProject.Interfaces
{
    public interface IActorMovieRepository
    {
        Task<bool> AddNewActorToMovie(ActorMovie actorMovie);
        Task<ActorMovie> CheckIfActorWithMovieExist(int movieId, int actorId);


    }
}
