using MyCRM.Models;

namespace MyCRM.ViewModels
{
    public class ChatMessageViewModel
    {
        public string? Sender { get; set; }
        public string? Recipient { get; set; }
        public string? Message { get; set; }
        public string? Created { get; set; }
    }
}
