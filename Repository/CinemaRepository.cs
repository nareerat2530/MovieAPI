using Microsoft.EntityFrameworkCore;
using MovieProject.Data;
using MovieProject.Interfaces;
using MovieProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieProject.Repository
{
    public class CinemaRepository : Repository<Cinema>, ICinemaRepository

    {
        private readonly AppDbContext _context;
        public CinemaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> AddNewCinemaAsync(Cinema cinema)
        {
            try
            {

                await _context.Cinemas.AddAsync(cinema);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<Cinema>> GetAllCinemaAsync()
        {
            return await _context.Cinemas.ToListAsync();
        }

        public async Task<Cinema> GetCinemaByIdAsync(int id)
        {
            return await _context.Cinemas.FirstOrDefaultAsync(c => c.Id == id);
        }

        public bool RemoveCinema(Cinema cinema)
        {
            try
            {

                _context.Cinemas.Remove(cinema);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCinema(Cinema cinema)
        {
            try
            {

                _context.Cinemas.Update(cinema);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
