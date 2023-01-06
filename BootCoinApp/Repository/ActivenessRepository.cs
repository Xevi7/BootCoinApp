using BootCoinApp.Data;
using BootCoinApp.Interfaces;
using BootCoinApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BootCoinApp.Repository
{
    public class ActivenessRepository : IActivenessRepository
    {
        private readonly ApplicationDbContext _context;
        public ActivenessRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Activeness>> GetAll()
        {
            return await _context.Activenesses.ToListAsync();
        }

        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
