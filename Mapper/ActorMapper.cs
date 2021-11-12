using MovieProject.Interfaces;
using MovieProject.Models;
using MovieProject.ViewModels;
using MovieProject.ViewModels.Actor;

namespace MovieProject.Mapper
{
    public class ActorMapper : IActorMapper
    {
        public Actor Map(ActorViewModel model)
        {

            return new()
            {
                Id = model.Id,
                FullName = model.FullName,
                ImageURL = model.ImageURL,
                Bio = model.Bio
            };
        }
        public Actor Map(PostViewModel model)
        {
            return new()
            {
                FullName = model.FullName,
                ImageURL = model.ImageURL,
                Bio = model.Bio
            };
        }


        public Actor Map(PostViewModel model, Actor actor)
        {

            actor.FullName = model.FullName;
            actor.ImageURL = model.ImageURL;
            actor.Bio = model.Bio;
            return actor;


        }



    }
}
