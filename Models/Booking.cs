using System.ComponentModel.DataAnnotations;

namespace PakistaniTaskerPlatform.Models
{
    public enum BookingStatus
    {
        Pending,
        Confirmed,
        InProgress,
        Completed,
        Cancelled
    }

    public enum BookingType
    {
        SameDay,
        Scheduled
    }

    public class Booking
    {
        public int Id { get; set; }
        
        [Required]
        public string CustomerName { get; set; } = string.Empty;
        
        [Required]
        public string CustomerPhone { get; set; } = string.Empty;
        
        public string CustomerAddress { get; set; } = string.Empty;
        
        [Required]
        public int TaskerId { get; set; }
        
        public Tasker? Tasker { get; set; }
        
        [Required]
        public int ServiceCategoryId { get; set; }
        
        public ServiceCategory? ServiceCategory { get; set; }
        
        [Required]
        public string TaskDescription { get; set; } = string.Empty; // In Roman Urdu
        
        public DateTime BookingDate { get; set; } = DateTime.Now;
        
        public DateTime ScheduledDate { get; set; }
        
        public TimeSpan EstimatedDuration { get; set; }
        
        public decimal EstimatedCost { get; set; }
        
        public decimal FinalCost { get; set; }
        
        public BookingStatus Status { get; set; } = BookingStatus.Pending;
        
        public BookingType Type { get; set; } = BookingType.SameDay;
        
        public string SpecialInstructions { get; set; } = string.Empty;
        
        public bool IsUrgent { get; set; } = false;
        
        public List<ChatMessage> Messages { get; set; } = new List<ChatMessage>();
        
        public Review? Review { get; set; }
    }
}

