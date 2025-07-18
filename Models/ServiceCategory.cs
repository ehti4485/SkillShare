using System.ComponentModel.DataAnnotations;

namespace PakistaniTaskerPlatform.Models
{
    public class ServiceCategory
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty; // English name
        
        [Required]
        public string UrduName { get; set; } = string.Empty; // Roman Urdu name
        
        public string Description { get; set; } = string.Empty;
        
        public string Icon { get; set; } = string.Empty; // Font Awesome icon class
        
        public List<string> CommonTasks { get; set; } = new List<string>();
        
        public decimal BasePrice { get; set; } // Base price in PKR
        
        public bool IsActive { get; set; } = true;
    }
}

