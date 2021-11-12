using MovieProject.Models;
using MovieProject.ViewModels.Producer;
using System.Collections.Generic;

namespace MovieProject.Interfaces.IMapper
{
    public interface IProducerViewModelMapper
    {
        List<ProducerViewModel> Map(IEnumerable<Producer> producers);
        ProducerViewModel Map(Producer producer);
    }
}
