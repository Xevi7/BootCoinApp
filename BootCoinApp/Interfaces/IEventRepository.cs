using BootCoinApp.Models;

namespace BootCoinApp.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAll();
        bool save();
    }
}
