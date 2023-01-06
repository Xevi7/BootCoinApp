using BootCoinApp.Models;

namespace BootCoinApp.ViewModels
{
    public class IndexHomeViewModel
    {
        public AppUser currentUser { get; set; }
        public IEnumerable<AppUser> users { get; set;}
        public int usersCount;
    }
}
