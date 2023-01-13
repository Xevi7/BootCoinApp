using BootCoinApp.Data;
using BootCoinApp.Interfaces;
using BootCoinApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace BootCoinApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) 
        { 
            _context = context;
        }

        public async Task<IEnumerable<AppUser>> GetAll()
        {
            return await _context.Users.Include(i => i.Group).Include(i => i.Position).ToListAsync();
        }

        public async Task<IEnumerable<AppUser>> GetAllInternExceptIdAsync(string id)
        {
            return await (from user in _context.Users
                          join userRole in _context.UserRoles
                          on user.Id equals userRole.UserId
                          join role in _context.Roles
                          on userRole.RoleId equals role.Id
                          where role.Name == "user"
                          select user)
                          .Include(i => i.Group)
                          .Include(i => i.Position)
                          .ToListAsync();
        }

        public async Task<AppUser> GetByIdAsync(string id)
        {
            return await _context.Users.Include(i => i.Group).Include(i => i.Position).FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
