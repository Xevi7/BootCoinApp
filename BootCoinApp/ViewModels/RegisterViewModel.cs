using BootCoinApp.Models;
using System.ComponentModel.DataAnnotations;

namespace BootCoinApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public IEnumerable<Group> groupList;
        [Required]
        public IEnumerable<Position> positionList;
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Group field is required.")]
        public string GroupId { get; set; }
        [Required(ErrorMessage = "The Position field is required.")]
        public string PositionId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
