using BootCoinApp.Data;
using BootCoinApp.Interfaces;
using BootCoinApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BootCoinApp.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _context;
        public GroupRepository(ApplicationDbContext context) 
        { 
            _context = context;
        }

        public async Task<IEnumerable<Group>> GetAll()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task<Group> GetByIdAsync(int id)
        {
            return await _context.Groups.Include(i => i.users).FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
