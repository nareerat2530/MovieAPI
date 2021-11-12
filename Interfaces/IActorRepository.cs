using MovieProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieProject.Interfaces
{
    public interface IActorRepository : IRepository<Actor>
    {
        Task<IList<Actor>> GetAllActorAsync();
        Task<Actor> GetActorById(int id);
        Task<bool> AddNewActorAsync(Actor actor);
        bool UpdateActor(Actor actor);
        bool RemoveActor(Actor actor);

    }
}
