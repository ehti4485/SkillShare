using PakistaniTaskerPlatform.Models;

namespace PakistaniTaskerPlatform.Services
{
    public class DataService
    {
        private static List<ServiceCategory> _serviceCategories = new();
        private static List<Tasker> _taskers = new();
        private static List<Booking> _bookings = new();
        private static List<Review> _reviews = new();
        private static List<Payment> _payments = new();
        private static List<ChatMessage> _chatMessages = new();
        
        static DataService()
        {
            InitializeData();
        }
        
        private static void InitializeData()
        {
            InitializeServiceCategories();
            InitializeTaskers();
            InitializeReviews();
        }
        
        private static void InitializeServiceCategories()
        {
            _serviceCategories = new List<ServiceCategory>
            {
                new ServiceCategory
                {
                    Id = 1,
                    Name = "Domestic Help",
                    UrduName = "Ghar ka Kaam",
                    Description = "Temporary maids for cleaning, dishwashing, and sweeping",
                    Icon = "fas fa-home",
                    CommonTasks = new List<string> { "Safai", "Bartan dhona", "Jhadu pocha", "Kapde dhona" },
                    BasePrice = 500
                },
                new ServiceCategory
                {
                    Id = 2,
                    Name = "Minor Repairs",
                    UrduName = "Chhoti Marammat",
                    Description = "Electric switch fixing, ceiling fan repair, water motor issues, leaking taps",
                    Icon = "fas fa-tools",
                    CommonTasks = new List<string> { "Switch repair", "Fan theek karna", "Motor repair", "Nal ka leak" },
                    BasePrice = 800
                },
                new ServiceCategory
                {
                    Id = 3,
                    Name = "Assembly & Fitting",
                    UrduName = "Assembling / Fitting",
                    Description = "Bed, cupboard, fan installation, curtain rod fixing",
                    Icon = "fas fa-screwdriver",
                    CommonTasks = new List<string> { "Bed lagana", "Cupboard fitting", "Fan installation", "Curtain rod" },
                    BasePrice = 1200
                },
                new ServiceCategory
                {
                    Id = 4,
                    Name = "Moving Help",
                    UrduName = "Local Moving Help",
                    Description = "Shifting furniture/items within home or floor-to-floor",
                    Icon = "fas fa-truck",
                    CommonTasks = new List<string> { "Furniture shift", "Saman uthana", "Floor change", "Room change" },
                    BasePrice = 1000
                },
                new ServiceCategory
                {
                    Id = 5,
                    Name = "Outdoor Work",
                    UrduName = "Outdoor / Roof Work",
                    Description = "Water tank cleaning, pigeon netting, solar panel wash",
                    Icon = "fas fa-sun",
                    CommonTasks = new List<string> { "Tank safai", "Pigeon net", "Solar panel wash", "Roof cleaning" },
                    BasePrice = 1500
                },
                new ServiceCategory
                {
                    Id = 6,
                    Name = "Digital Tasks",
                    UrduName = "Digital Tasks",
                    Description = "Setting up Wi-Fi routers, basic mobile/computer help, installing apps",
                    Icon = "fas fa-laptop",
                    CommonTasks = new List<string> { "WiFi setup", "Mobile help", "App install", "Computer basic" },
                    BasePrice = 600
                },
                new ServiceCategory
                {
                    Id = 7,
                    Name = "Emergency Help",
                    UrduName = "Emergency Helpers",
                    Description = "On-call electrician, plumber, or AC technician for quick fixes",
                    Icon = "fas fa-exclamation-triangle",
                    CommonTasks = new List<string> { "Bijli ka masla", "Pani ka masla", "AC repair", "Emergency fix" },
                    BasePrice = 2000
                }
            };
        }
        
        private static void InitializeTaskers()
        {
            var pakistaniCities = new[] { "Karachi", "Lahore", "Islamabad", "Rawalpindi", "Faisalabad", "Multan", "Hyderabad", "Peshawar", "Quetta", "Sialkot" };
            var karachiAreas = new[] { "Gulshan", "Clifton", "DHA", "Nazimabad", "North Nazimabad", "Malir", "Korangi", "Saddar", "Tariq Road", "Johar Town" };
            var lahoreAreas = new[] { "DHA", "Gulberg", "Model Town", "Johar Town", "Cantt", "Anarkali", "Liberty", "MM Alam Road", "Faisal Town", "Wapda Town" };
            
            _taskers = new List<Tasker>
            {
                new Tasker
                {
                    Id = 1,
                    Name = "Muhammad Ahmed",
                    City = "Karachi",
                    Area = "Gulshan-e-Iqbal",
                    PhoneNumber = "0300-1234567",
                    ServiceCategoryIds = new List<int> { 1, 2 },
                    Skills = new List<string> { "Safai expert", "Electrical basic", "Punctual" },
                    HourlyRate = 400,
                    Rating = 4.8,
                    TotalJobs = 156,
                    CompletedJobs = 148,
                    Bio = "5 saal ka tajurba hai ghar ki safai aur chhoti electrical problems mein",
                    IsVerified = true,
                    Experience = "5 saal ka tajurba"
                },
                new Tasker
                {
                    Id = 2,
                    Name = "Ali Hassan",
                    City = "Lahore",
                    Area = "DHA Phase 5",
                    PhoneNumber = "0321-9876543",
                    ServiceCategoryIds = new List<int> { 2, 3, 7 },
                    Skills = new List<string> { "Electrician", "Plumber", "Emergency service", "24/7 available" },
                    HourlyRate = 800,
                    Rating = 4.9,
                    TotalJobs = 203,
                    CompletedJobs = 195,
                    Bio = "Professional electrician aur plumber. Emergency calls bhi leta hun",
                    IsVerified = true,
                    Experience = "8 saal ka tajurba"
                },
                new Tasker
                {
                    Id = 3,
                    Name = "Fatima Bibi",
                    City = "Karachi",
                    Area = "Clifton",
                    PhoneNumber = "0333-5555555",
                    ServiceCategoryIds = new List<int> { 1 },
                    Skills = new List<string> { "House cleaning", "Dishwashing", "Laundry", "Reliable" },
                    HourlyRate = 350,
                    Rating = 4.7,
                    TotalJobs = 89,
                    CompletedJobs = 85,
                    Bio = "Ghar ki safai mein expert hun. Bharosa aur imaandari se kaam karti hun",
                    IsVerified = true,
                    Experience = "3 saal ka tajurba"
                },
                new Tasker
                {
                    Id = 4,
                    Name = "Usman Khan",
                    City = "Islamabad",
                    Area = "F-10",
                    PhoneNumber = "0345-7777777",
                    ServiceCategoryIds = new List<int> { 3, 4 },
                    Skills = new List<string> { "Furniture assembly", "Moving expert", "Heavy lifting", "Careful handling" },
                    HourlyRate = 600,
                    Rating = 4.6,
                    TotalJobs = 67,
                    CompletedJobs = 63,
                    Bio = "Furniture assembly aur moving ka kaam karta hun. Saman ko sambhal kar rakhta hun",
                    IsVerified = true,
                    Experience = "4 saal ka tajurba"
                },
                new Tasker
                {
                    Id = 5,
                    Name = "Rashid Ahmed",
                    City = "Karachi",
                    Area = "North Nazimabad",
                    PhoneNumber = "0300-8888888",
                    ServiceCategoryIds = new List<int> { 5 },
                    Skills = new List<string> { "Roof work", "Tank cleaning", "Height work", "Safety expert" },
                    HourlyRate = 900,
                    Rating = 4.5,
                    TotalJobs = 45,
                    CompletedJobs = 42,
                    Bio = "Roof aur height ka kaam karta hun. Tank cleaning aur pigeon netting specialist",
                    IsVerified = true,
                    Experience = "6 saal ka tajurba"
                },
                new Tasker
                {
                    Id = 6,
                    Name = "Zain Ali",
                    City = "Lahore",
                    Area = "Gulberg",
                    PhoneNumber = "0322-9999999",
                    ServiceCategoryIds = new List<int> { 6 },
                    Skills = new List<string> { "IT support", "WiFi setup", "Mobile help", "Computer repair" },
                    HourlyRate = 500,
                    Rating = 4.8,
                    TotalJobs = 78,
                    CompletedJobs = 75,
                    Bio = "Computer aur mobile ki problems solve karta hun. WiFi setup specialist",
                    IsVerified = true,
                    Experience = "2 saal ka tajurba"
                }
            };
        }
        
        private static void InitializeReviews()
        {
            _reviews = new List<Review>
            {
                new Review
                {
                    Id = 1,
                    TaskerId = 1,
                    CustomerName = "Ayesha Khan",
                    Rating = 5,
                    Comment = "Bahut acha kaam kiya. Time pe aaya aur safai bhi perfect thi",
                    Tags = new List<string> { "Punctual", "Professional", "Clean work" }
                },
                new Review
                {
                    Id = 2,
                    TaskerId = 2,
                    CustomerName = "Imran Sheikh",
                    Rating = 5,
                    Comment = "Emergency mein call kiya tha. Jaldi aaya aur problem solve kar di",
                    Tags = new List<string> { "Quick response", "Expert", "Reliable" }
                },
                new Review
                {
                    Id = 3,
                    TaskerId = 3,
                    CustomerName = "Sadia Malik",
                    Rating = 4,
                    Comment = "Acha kaam kiya lekin thoda late ayi thi",
                    Tags = new List<string> { "Good work", "Honest" }
                }
            };
        }
        
        // Service Categories
        public List<ServiceCategory> GetServiceCategories() => _serviceCategories;
        
        public ServiceCategory? GetServiceCategory(int id) => _serviceCategories.FirstOrDefault(c => c.Id == id);
        
        // Taskers
        public List<Tasker> GetTaskers() => _taskers;
        
        public List<Tasker> GetTaskersByCategory(int categoryId) => 
            _taskers.Where(t => t.ServiceCategoryIds.Contains(categoryId) && t.IsAvailable).ToList();
        
        public List<Tasker> GetTaskersByCity(string city) => 
            _taskers.Where(t => t.City.Equals(city, StringComparison.OrdinalIgnoreCase) && t.IsAvailable).ToList();
        
        public List<Tasker> GetTaskersByCategoryAndCity(int categoryId, string city) =>
            _taskers.Where(t => t.ServiceCategoryIds.Contains(categoryId) && 
                               t.City.Equals(city, StringComparison.OrdinalIgnoreCase) && 
                               t.IsAvailable).ToList();
        
        public Tasker? GetTasker(int id) => _taskers.FirstOrDefault(t => t.Id == id);
        
        // Bookings
        public List<Booking> GetBookings() => _bookings;
        
        public Booking? GetBooking(int id) => _bookings.FirstOrDefault(b => b.Id == id);
        
        public int CreateBooking(Booking booking)
        {
            booking.Id = _bookings.Count > 0 ? _bookings.Max(b => b.Id) + 1 : 1;
            _bookings.Add(booking);
            return booking.Id;
        }
        
        public void UpdateBooking(Booking booking)
        {
            var existingBooking = _bookings.FirstOrDefault(b => b.Id == booking.Id);
            if (existingBooking != null)
            {
                var index = _bookings.IndexOf(existingBooking);
                _bookings[index] = booking;
            }
        }
        
        // Reviews
        public List<Review> GetReviews() => _reviews;
        
        public List<Review> GetReviewsForTasker(int taskerId) => 
            _reviews.Where(r => r.TaskerId == taskerId).ToList();
        
        public void AddReview(Review review)
        {
            review.Id = _reviews.Count > 0 ? _reviews.Max(r => r.Id) + 1 : 1;
            _reviews.Add(review);
            
            // Update tasker rating
            var tasker = GetTasker(review.TaskerId);
            if (tasker != null)
            {
                var taskerReviews = GetReviewsForTasker(review.TaskerId);
                tasker.Rating = taskerReviews.Average(r => r.Rating);
            }
        }
        
        // Chat Messages
        public List<ChatMessage> GetChatMessages(int bookingId) => 
            _chatMessages.Where(m => m.BookingId == bookingId).OrderBy(m => m.Timestamp).ToList();
        
        public void AddChatMessage(ChatMessage message)
        {
            message.Id = _chatMessages.Count > 0 ? _chatMessages.Max(m => m.Id) + 1 : 1;
            _chatMessages.Add(message);
        }
        
        // Payments
        public List<Payment> GetPayments() => _payments;
        
        public Payment? GetPaymentByBookingId(int bookingId) => 
            _payments.FirstOrDefault(p => p.BookingId == bookingId);
        
        public void AddPayment(Payment payment)
        {
            payment.Id = _payments.Count > 0 ? _payments.Max(p => p.Id) + 1 : 1;
            _payments.Add(payment);
        }
        
        // Utility methods
        public List<string> GetPakistaniCities() => 
            new List<string> { "Karachi", "Lahore", "Islamabad", "Rawalpindi", "Faisalabad", "Multan", "Hyderabad", "Peshawar", "Quetta", "Sialkot" };
        
        public List<string> GetAreasForCity(string city)
        {
            return city.ToLower() switch
            {
                "karachi" => new List<string> { "Gulshan-e-Iqbal", "Clifton", "DHA", "Nazimabad", "North Nazimabad", "Malir", "Korangi", "Saddar", "Tariq Road", "Johar Town" },
                "lahore" => new List<string> { "DHA", "Gulberg", "Model Town", "Johar Town", "Cantt", "Anarkali", "Liberty", "MM Alam Road", "Faisal Town", "Wapda Town" },
                "islamabad" => new List<string> { "F-6", "F-7", "F-8", "F-10", "F-11", "G-6", "G-7", "G-8", "G-9", "G-10" },
                _ => new List<string> { "City Center", "Main Area", "Commercial Area", "Residential Area" }
            };
        }
    }
}

