using MovieProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieProject.Interfaces
{
    public interface IProducerRerository
    {
        Task<IList<Producer>> GetAllProducerAsync();
        Task<Producer> GetProducerById(int id);
        Task<bool> AddNewProducerAsync(Producer producer);
        bool UpdateProducer(Producer producer);
        bool RemoveProducer(Producer producer);
    }
}
