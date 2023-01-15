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

        public async Task<IEnumerable<AppUser>> GetAllInternExceptIdAsync(string id, string sortTypes)
        {
            var users = (from user in _context.Users
                               join userRole in _context.UserRoles
                                 on user.Id equals userRole.UserId
                               join role in _context.Roles
                                 on userRole.RoleId equals role.Id
                               where role.Name == "user"
                               where user.Id != id
                               select user)
                          .Include(i => i.Group)
                          .Include(i => i.Position);

            if (sortTypes.Equals("BootCoin"))
            {
                return await users.OrderBy(i => i.BootCoin)
                            .ThenBy(i => i.PositionId)
                            .ToListAsync();
            }
            else if(sortTypes.Equals("FullName ASC"))
            {
                return await users.OrderBy(i => i.FullName)
                            .ThenBy(i => i.PositionId)
                            .ToListAsync();
            }
            else if(sortTypes.Equals("FullName DESC"))
            {
                return await users.OrderByDescending(i => i.FullName)
                            .ThenBy(i => i.PositionId)
                            .ToListAsync();
            }
            else
            {
                return await users.OrderBy(i => i.GroupId)
                            .ThenBy(i => i.PositionId)
                            .ToListAsync();
            }
        }

        public async Task<IEnumerable<AppUser>> SearchInternExceptIdAsync(string id, string search, string sortTypes)
        {
            var users = (from user in _context.Users
                         join userRole in _context.UserRoles
                           on user.Id equals userRole.UserId
                         join role in _context.Roles
                           on userRole.RoleId equals role.Id
                         where role.Name == "user"
                         where user.Id != id
                         select user)
                          .Where(i => i.FullName.Contains(search))
                          .Include(i => i.Group)
                          .Include(i => i.Position);

            if (sortTypes.Equals("BootCoin"))
            {
                return await users.OrderBy(i => i.BootCoin)
                            .ThenBy(i => i.PositionId)
                            .ToListAsync();
            }
            else if (sortTypes.Equals("FullName ASC"))
            {
                return await users.OrderBy(i => i.FullName)
                            .ThenBy(i => i.PositionId)
                            .ToListAsync();
            }
            else if (sortTypes.Equals("FullName DESC"))
            {
                return await users.OrderByDescending(i => i.FullName)
                            .ThenBy(i => i.PositionId)
                            .ToListAsync();
            }
            else
            {
                return await users.OrderBy(i => i.GroupId)
                            .ThenBy(i => i.PositionId)
                            .ToListAsync();
            }
        }

        public async Task<AppUser> GetByIdAsync(string id)
        {
            return await _context.Users.Include(i => i.Group).Include(i => i.Position).FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Update(AppUser user)
        {
            _context.Update(user);
            return save();
        }

        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
