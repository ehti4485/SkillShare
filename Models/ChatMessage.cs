using System.ComponentModel.DataAnnotations;

namespace PakistaniTaskerPlatform.Models
{
    public enum MessageSender
    {
        Customer,
        Tasker,
        System
    }

    public class ChatMessage
    {
        public int Id { get; set; }
        
        [Required]
        public int BookingId { get; set; }
        
        [Required]
        public string Message { get; set; } = string.Empty;
        
        public MessageSender Sender { get; set; }
        
        public string SenderName { get; set; } = string.Empty;
        
        public DateTime Timestamp { get; set; } = DateTime.Now;
        
        public bool IsRead { get; set; } = false;
        
        public string MessageType { get; set; } = "text"; // text, image, location
    }
}

