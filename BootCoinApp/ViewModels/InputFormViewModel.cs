using BootCoinApp.Models;
using System.ComponentModel.DataAnnotations;

namespace BootCoinApp.ViewModels
{
    public class InputFormViewModel
    {
        public IEnumerable<Event> events { get; set; }
        public IEnumerable<Activeness> activenesses { get; set; }
        [Required]
        public string receiverId { get; set; }
        [Required]
        public int amount { get; set; }
        [Required(ErrorMessage = "Please choose the event category")]
        public string eventId { get; set; }
        [Required(ErrorMessage = "Please choose the activeness level")]
        public string activenessId { get; set; }
    }
}
