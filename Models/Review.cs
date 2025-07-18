using System.ComponentModel.DataAnnotations;

namespace PakistaniTaskerPlatform.Models
{
    public class Review
    {
        public int Id { get; set; }
        
        [Required]
        public int BookingId { get; set; }
        
        public Booking? Booking { get; set; }
        
        [Required]
        public int TaskerId { get; set; }
        
        public Tasker? Tasker { get; set; }
        
        [Required]
        public string CustomerName { get; set; } = string.Empty;
        
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
        
        public string Comment { get; set; } = string.Empty; // In Roman Urdu
        
        public DateTime ReviewDate { get; set; } = DateTime.Now;
        
        public bool WouldRecommend { get; set; } = true;
        
        public List<string> Tags { get; set; } = new List<string>(); // e.g., "Punctual", "Professional", "Affordable"
        
        public bool IsVerified { get; set; } = true; // All reviews are verified in simulation
    }
}

