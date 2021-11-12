using MovieProject.Models;
using MovieProject.ViewModels.Actor;
using System.Collections.Generic;

namespace MovieProject.Interfaces
{
    public interface IActorViewModelMapper
    {
        List<ActorViewModel> Map(IEnumerable<Actor> actor);
        ActorViewModel Map(Actor actor);

    }
}
