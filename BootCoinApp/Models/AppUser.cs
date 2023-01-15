using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BootCoinApp.Models
{
    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; }
        public int? BootCoin { get; set; }
        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public Group Group { get; set; }
        [ForeignKey("Position")]
        public int PositionId { get; set; }
        public Position Position { get; set; }

    }
}
