using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PakistaniTaskerPlatform.Models;
using PakistaniTaskerPlatform.Services;

namespace PakistaniTaskerPlatform.Pages;

public class BookingConfirmationModel : PageModel
{
    private readonly DataService _dataService;

    public Booking? Booking { get; set; }
    public Tasker? Tasker { get; set; }
    public ServiceCategory? ServiceCategory { get; set; }
    
    [BindProperty(SupportsGet = true)]
    public int BookingId { get; set; }

    public BookingConfirmationModel(DataService dataService)
    {
        _dataService = dataService;
    }

    public void OnGet()
    {
        Booking = _dataService.GetBooking(BookingId);
        
        if (Booking != null)
        {
            Tasker = _dataService.GetTasker(Booking.TaskerId);
            ServiceCategory = _dataService.GetServiceCategory(Booking.ServiceCategoryId);
            
            // Simulate automatic status updates
            if (Booking.Status == BookingStatus.Pending)
            {
                // In a real application, this would be handled by background services
                // For simulation, we'll update the status after a short delay
                Task.Run(async () =>
                {
                    await Task.Delay(5000); // Wait 5 seconds
                    Booking.Status = BookingStatus.Confirmed;
                    _dataService.UpdateBooking(Booking);
                    
                    // Add a system message to simulate worker contact
                    var systemMessage = new ChatMessage
                    {
                        BookingId = Booking.Id,
                        Message = $"Assalam-o-Alaikum! Main {Tasker?.Name} hun. Aapka booking confirm ho gaya hai. Main aap se jaldi contact karunga.",
                        Sender = MessageSender.Tasker,
                        SenderName = Tasker?.Name ?? "Worker"
                    };
                    _dataService.AddChatMessage(systemMessage);
                });
            }
        }
    }
}

