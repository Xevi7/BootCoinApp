using BootCoinApp.Models;

namespace BootCoinApp.Interfaces
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetAll();
        Task<Group> GetByIdAsync(int id);
        bool save();
    }
}
