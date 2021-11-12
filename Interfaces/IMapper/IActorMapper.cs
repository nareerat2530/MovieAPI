using MovieProject.Models;
using MovieProject.ViewModels;
using MovieProject.ViewModels.Actor;

namespace MovieProject.Interfaces
{
    public interface IActorMapper
    {
        Actor Map(ActorViewModel model);
        Actor Map(PostViewModel model);

        Actor Map(PostViewModel model, Actor actor);




    }
}
