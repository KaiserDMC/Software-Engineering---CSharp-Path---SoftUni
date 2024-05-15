using System.ComponentModel.DataAnnotations;

namespace ChatApp.ViewModels.Chat
{
    public class MessageViewModel
    {
        [Required]
        public string Sender { get; set; }

        [Required]
        [MaxLength(500)]
        public string MessageText { get; set; }
    }
}