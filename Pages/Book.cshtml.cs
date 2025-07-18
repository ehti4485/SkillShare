using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PakistaniTaskerPlatform.Models;
using PakistaniTaskerPlatform.Services;

namespace PakistaniTaskerPlatform.Pages;

public class BookModel : PageModel
{
    private readonly DataService _dataService;

    public Tasker? Tasker { get; set; }
    public List<ServiceCategory> ServiceCategories { get; set; } = new();
    
    [BindProperty(SupportsGet = true)]
    public int TaskerId { get; set; }

    public BookModel(DataService dataService)
    {
        _dataService = dataService;
    }

    public void OnGet()
    {
        Tasker = _dataService.GetTasker(TaskerId);
        ServiceCategories = _dataService.GetServiceCategories();
    }

    public IActionResult OnPost()
    {
        try
        {
            var booking = new Booking
            {
                CustomerName = Request.Form["CustomerName"]!,
                CustomerPhone = Request.Form["CustomerPhone"]!,
                CustomerAddress = Request.Form["CustomerAddress"]!,
                TaskerId = int.Parse(Request.Form["TaskerId"]!),
                ServiceCategoryId = int.Parse(Request.Form["ServiceCategoryId"]!),
                TaskDescription = Request.Form["TaskDescription"]!,
                ScheduledDate = DateTime.TryParse(Request.Form["ScheduledDate"], out var scheduledDate) ? scheduledDate : DateTime.Now.AddHours(2),
                EstimatedDuration = TimeSpan.FromHours(int.Parse(Request.Form["EstimatedHours"].FirstOrDefault() ?? "2")),
                IsUrgent = Request.Form["IsUrgent"].ToString().Contains("true"),
                SpecialInstructions = Request.Form["SpecialInstructions"]!,
                Type = Request.Form["BookingType"] == "Scheduled" ? BookingType.Scheduled : BookingType.SameDay,
                Status = BookingStatus.Pending
            };

            // Calculate estimated cost
            var tasker = _dataService.GetTasker(booking.TaskerId);
            if (tasker != null)
            {
                var hours = (int)booking.EstimatedDuration.TotalHours;
                var baseRate = tasker.HourlyRate * hours;
                var serviceFee = baseRate * 0.1m;
                var urgentFee = booking.IsUrgent ? baseRate * 0.2m : 0;
                booking.EstimatedCost = baseRate + serviceFee + urgentFee;
            }

            var bookingId = _dataService.CreateBooking(booking);
            
            return RedirectToPage("/BookingConfirmation", new { bookingId = bookingId });
        }
        catch (Exception ex)
        {
            // In a real application, you would log this error
            TempData["Error"] = "Booking mein problem hui hai. Please try again.";
            return Page();
        }
    }
}

