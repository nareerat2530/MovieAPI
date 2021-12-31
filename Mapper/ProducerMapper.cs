using MovieProject.Interfaces.IMapper;
using MovieProject.Models;
using MovieProject.ViewModels.Producer;

namespace MovieProject.Mapper
{
    public class ProducerMapper : IProducerMapper
    {
        public Producer Map(ProducerViewModel model)
        {
            return new()
            {
                Id = model.Id,
                FullName = model.FullName,
                ImageURL = model.ImageURL,
                Bio = model.Bio
            };
        }

        public Producer Map(PostProducerViewModel model, Producer producer)
        {

            producer.FullName = model.FullName;
            producer.ImageURL = model.ImageURL;
            producer.Bio = model.Bio;
            return producer;
        }

        public Producer Map(PostProducerViewModel model)
        {
            return new()
            {

                FullName = model.FullName,
                ImageURL = model.ImageURL,
                Bio = model.Bio
            };
        }
    }
}
