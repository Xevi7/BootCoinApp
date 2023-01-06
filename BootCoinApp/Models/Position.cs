using System.ComponentModel.DataAnnotations;

namespace BootCoinApp.Models
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        public string PositionName { get; set; }
        public ICollection<AppUser> users { get; set; }
    }
}
