using System.ComponentModel.DataAnnotations;

namespace PakistaniTaskerPlatform.Models
{
    public enum PaymentMethod
    {
        Cash,
        JazzCash,
        EasyPaisa,
        BankTransfer,
        Card
    }

    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed,
        Refunded
    }

    public class Payment
    {
        public int Id { get; set; }
        
        [Required]
        public int BookingId { get; set; }
        
        public Booking? Booking { get; set; }
        
        [Required]
        public decimal Amount { get; set; }
        
        public PaymentMethod Method { get; set; } = PaymentMethod.Cash;
        
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
        
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        
        public string TransactionId { get; set; } = string.Empty;
        
        public string PaymentReference { get; set; } = string.Empty;
        
        public decimal ServiceFee { get; set; } = 0; // Platform fee
        
        public decimal TaskerAmount { get; set; } = 0; // Amount tasker receives
        
        public string Notes { get; set; } = string.Empty;
        
        public bool IsRefundable { get; set; } = true;
    }
}

