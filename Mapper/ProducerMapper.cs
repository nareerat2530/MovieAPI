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

            producer.FullName = producer.FullName;
            producer.ImageURL = producer.ImageURL;
            producer.Bio = producer.Bio;
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
