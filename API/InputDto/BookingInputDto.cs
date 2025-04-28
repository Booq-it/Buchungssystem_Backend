using API.OutputDto;

namespace API.InputDto
{
    public class BookingInputDto
    {
        public int userId { get; set; }
        public int showingId { get; set; }
        
        public ICollection<int> seatIds { get; set; } 
    }
}
