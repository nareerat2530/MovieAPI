using MovieProject.Models;
using MovieProject.ViewModels.Producer;

namespace MovieProject.Interfaces.IMapper
{
    public interface IProducerMapper
    {
        Producer Map(ProducerViewModel model);
        Producer Map(PostProducerViewModel model, Producer producer);
        Producer Map(PostProducerViewModel model);
    }
}
