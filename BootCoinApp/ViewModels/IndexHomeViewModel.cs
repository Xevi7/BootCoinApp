using BootCoinApp.Models;

namespace BootCoinApp.ViewModels
{
    public class IndexHomeViewModel
    {
        public Transaction latestMission { get; set; }
        public AppUser currentUser { get; set; }
        public IEnumerable<AppUser> users { get; set;}
        public int usersCount;
    }
}
