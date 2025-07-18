using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PakistaniTaskerPlatform.Models;
using PakistaniTaskerPlatform.Services;

namespace PakistaniTaskerPlatform.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly DataService _dataService;

    public List<ServiceCategory> ServiceCategories { get; set; } = new();
    public List<string> Cities { get; set; } = new();

    public IndexModel(ILogger<IndexModel> logger, DataService dataService)
    {
        _logger = logger;
        _dataService = dataService;
    }

    public void OnGet()
    {
        ServiceCategories = _dataService.GetServiceCategories();
        Cities = _dataService.GetPakistaniCities();
    }
}
