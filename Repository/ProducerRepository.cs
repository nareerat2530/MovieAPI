using Microsoft.EntityFrameworkCore;
using MovieProject.Data;
using MovieProject.Interfaces;
using MovieProject.Models;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;


namespace MovieProject.Repository
{
    public class ProducerRepository : Repository<Producer>, IProducerRerository
    {
        private readonly AppDbContext _context;
        public ProducerRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

       
        public async Task<bool> AddNewProducerAsync(Producer producer)
        {
            
            try
            {
                await _context.Producers.AddAsync(producer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<Producer>> GetAllProducerAsync()
        {
            return await _context.Producers.Include(c => c.Movies).ToListAsync();
        }

        public async Task<Producer> GetProducerById(int id)
        {
            return await _context.Producers.FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool RemoveProducer(Producer producer)
        {
            try
            {
                _context.Producers.Remove(producer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateProducer(Producer producer)
        {
            try
            {
                _context.Producers.Update(producer);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
