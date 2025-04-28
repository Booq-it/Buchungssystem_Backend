using API.OutputDto;

namespace API.InputDto
{
    public class BookingOutputDto
    {
        public int id { get; set; }
        public DateTime bookingDate { get; set; }
        public double price { get; set; }
        public bool isCancelled { get; set; }
        public int userId { get; set; }
        public int showingId { get; set; }
        
        public ICollection<ShowingSeatDto> seats { get; set; } 
    }
}