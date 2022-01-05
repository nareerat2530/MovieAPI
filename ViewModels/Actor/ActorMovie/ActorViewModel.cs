using System.Collections.Generic;

namespace MovieProject.ViewModels.Actor
{
    public class ActorViewModel
    {

        public int Id { get; set; }
        public string FullName { get; set; }
        public string ImageURL { get; set; }
        public string Bio { get; set; }
        public ICollection<Models.ActorMovie> ActorMovies { get; internal set; }
    }


}
