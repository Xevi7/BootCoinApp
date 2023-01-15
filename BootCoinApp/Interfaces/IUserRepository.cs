using BootCoinApp.Models;

namespace BootCoinApp.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAll();
        Task<IEnumerable<AppUser>> GetAllInternExceptIdAsync(string id, string sortTypes);
        Task<IEnumerable<AppUser>> SearchInternExceptIdAsync(string id, string search, string sortTypes);
        Task<AppUser> GetByIdAsync(string id);
        bool Update(AppUser user);
        bool save();
    }
}
