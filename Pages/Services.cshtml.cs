using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PakistaniTaskerPlatform.Models;
using PakistaniTaskerPlatform.Services;

namespace PakistaniTaskerPlatform.Pages;

public class ServicesModel : PageModel
{
    private readonly DataService _dataService;

    public List<Tasker> Taskers { get; set; } = new();
    public List<ServiceCategory> ServiceCategories { get; set; } = new();
    public List<string> Cities { get; set; } = new();
    
    [BindProperty(SupportsGet = true)]
    public string? SelectedCity { get; set; }
    
    [BindProperty(SupportsGet = true)]
    public int? SelectedCategoryId { get; set; }
    
    [BindProperty(SupportsGet = true)]
    public double? MinRating { get; set; }
    
    public ServiceCategory? SelectedCategory { get; set; }

    public ServicesModel(DataService dataService)
    {
        _dataService = dataService;
    }

    public void OnGet()
    {
        ServiceCategories = _dataService.GetServiceCategories();
        Cities = _dataService.GetPakistaniCities();
        
        // Get selected category
        if (SelectedCategoryId.HasValue)
        {
            SelectedCategory = _dataService.GetServiceCategory(SelectedCategoryId.Value);
        }
        
        // Filter taskers based on criteria
        Taskers = _dataService.GetTaskers();
        
        // Filter by city
        if (!string.IsNullOrEmpty(SelectedCity))
        {
            Taskers = Taskers.Where(t => t.City.Equals(SelectedCity, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        
        // Filter by category
        if (SelectedCategoryId.HasValue)
        {
            Taskers = Taskers.Where(t => t.ServiceCategoryIds.Contains(SelectedCategoryId.Value)).ToList();
        }
        
        // Filter by rating
        if (MinRating.HasValue)
        {
            Taskers = Taskers.Where(t => t.Rating >= MinRating.Value).ToList();
        }
        
        // Sort by rating (highest first)
        Taskers = Taskers.OrderByDescending(t => t.Rating).ThenByDescending(t => t.CompletedJobs).ToList();
    }
}

