using MovieProject.Interfaces;
using MovieProject.Models;
using MovieProject.ViewModels.Actor;
using System.Collections.Generic;
using System.Linq;

namespace MovieProject.Mapper
{
    public class ActorViewModelMapper : IActorViewModelMapper
    {
        public List<ActorViewModel> Map(IEnumerable<Actor> actors)
        {
            return actors.Select(a => new ActorViewModel
            {
                Id = a.Id,
                FullName = a.FullName,
                ImageURL = a.ImageURL,
                Bio = a.Bio,
                ActorMovies = a.ActorMovies

            }).ToList();




        }

        public ActorViewModel Map(Actor actor)
        {
            return new()
            {
                Id = actor.Id,
                Bio = actor.Bio,
                ImageURL = actor.ImageURL,
                FullName = actor.FullName

            };
        }
    }
}
