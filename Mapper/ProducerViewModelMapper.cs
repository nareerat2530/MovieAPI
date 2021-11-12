using MovieProject.Interfaces.IMapper;
using MovieProject.Models;
using MovieProject.ViewModels.Producer;
using System.Collections.Generic;
using System.Linq;

namespace MovieProject.Mapper
{
    public class ProducerViewModelMapper : IProducerViewModelMapper
    {
        public List<ProducerViewModel> Map(IEnumerable<Producer> producers)
        {
            return producers.Select(p => new ProducerViewModel
            {
                Id = p.Id,
                FullName = p.FullName,
                ImageURL = p.ImageURL,
                Bio = p.Bio,

            }).ToList();
        }

        public ProducerViewModel Map(Producer producer)
        {
            return new()
            {
                Id = producer.Id,
                FullName = producer.FullName,
                ImageURL = producer.ImageURL,
                Bio = producer.Bio,
            };
        }
    }
}
