using System.ComponentModel.DataAnnotations;

namespace PakistaniTaskerPlatform.Models
{
    public class Tasker
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty; // Pakistani names
        
        public string ProfilePicture { get; set; } = string.Empty;
        
        [Required]
        public string City { get; set; } = string.Empty; // Karachi, Lahore, etc.
        
        [Required]
        public string Area { get; set; } = string.Empty; // Specific area within city
        
        public string PhoneNumber { get; set; } = string.Empty;
        
        public List<int> ServiceCategoryIds { get; set; } = new List<int>();
        
        public List<string> Skills { get; set; } = new List<string>(); // Skill tags
        
        public decimal HourlyRate { get; set; } // Rate in PKR
        
        public double Rating { get; set; } = 0.0; // 0-5 rating
        
        public int TotalJobs { get; set; } = 0;
        
        public int CompletedJobs { get; set; } = 0;
        
        public string Bio { get; set; } = string.Empty; // Brief description in Roman Urdu
        
        public bool IsAvailable { get; set; } = true;
        
        public bool IsVerified { get; set; } = false;
        
        public DateTime JoinedDate { get; set; } = DateTime.Now;
        
        public List<string> Languages { get; set; } = new List<string> { "Urdu", "English" };
        
        public string Experience { get; set; } = string.Empty; // e.g., "2 saal ka tajurba"
    }
}

