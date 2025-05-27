using API.Data;
using API.InputDto;
using API.Models;
using API.OutputDto;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public interface IBookingService
    {
        public Task<bool> MakeBooking(BookingInputDto bookingInputDto);
        public Task<bool> MakeGuestBooking(GuestBookingInput bookingInputDto);
        public Task<bool> CancelBooking(int bookingId);
        public Task<List<BookingOutputDto>> GetAllBookings();
        public Task<BookingOutputDto> GetBookingById(int id);
        public Task<List<BookingOutputDto>> GetBookingsByUserId(int userId);
    }

    public class BookingService : IBookingService
    {
        private readonly BackendDbContext _db;

        public BookingService(BackendDbContext db)
        {
            _db = db;
        }

        public async Task<bool> MakeBooking(BookingInputDto bookingInputDto)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                var seats = await _db.Seats
                    .Where(s => bookingInputDto.seatIds.Contains(s.Id))
                    .ToListAsync();

                var user = await _db.Users
                    .Include(b => b.Bookings)
                    .FirstOrDefaultAsync(u => u.Id == bookingInputDto.userId);

                if (user == null)
                    return false;

                var showing = await _db.Showings
                    .FirstOrDefaultAsync(s => s.Id == bookingInputDto.showingId);

                if (showing == null)
                    return false;

                foreach (var seat in seats)
                {
                    if (!seat.isAvailable)
                        return false;

                    seat.isAvailable = false;
                }

                var booking = new Booking
                {
                    BookingDate = DateTime.Now,
                    price = bookingInputDto.price,
                    isCancelled = false,
                    UserId = bookingInputDto.userId,
                    ShowingId = bookingInputDto.showingId,
                    Seats = seats
                };

                await _db.Bookings.AddAsync(booking);
                await _db.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                Console.WriteLine($"Error during booking: {e.Message}");
                return false;
            }

            return true;
        }

        public async Task<bool> MakeGuestBooking(GuestBookingInput bookingInputDto)
        {
            using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                var seats = await _db.Seats
                    .Where(s => bookingInputDto.seatIds.Contains(s.Id))
                    .ToListAsync();
                
                var showing = await _db.Showings
                    .FirstOrDefaultAsync(s => s.Id == bookingInputDto.showingId);

                if (showing == null)
                    return false;

                foreach (var seat in seats)
                {
                    if (!seat.isAvailable)
                        return false;

                    seat.isAvailable = false;
                }

                var booking = new GuestBooking()
                {
                    BookingDate = DateTime.Now,
                    Price = bookingInputDto.price,
                    IsCancelled = false,
                    GuestFirstName = bookingInputDto.GuestFirstName,
                    GuestLastName = bookingInputDto.GuestLastName,
                    GuestEmail = bookingInputDto.GuestEmail,
                    ShowingId = bookingInputDto.showingId,
                    Seats = seats
                };

                await _db.GuestBookings.AddAsync(booking);
                await _db.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                Console.WriteLine($"Error during guest booking: {e.Message}");
                return false;
            }

            return true;
        }

    public async Task<bool> CancelBooking(int bookingId)
        {
            var booking = await _db.Bookings
                .Include(s => s.Seats)
                .FirstOrDefaultAsync(b => b.Id == bookingId);

            if (booking == null || booking.isCancelled)
                return false;

            booking.isCancelled = true;

            foreach (var seat in booking.Seats)
            {
                seat.isAvailable = true;
            }

            _db.Bookings.Update(booking);
            _db.Seats.UpdateRange(booking.Seats);
            await _db.SaveChangesAsync();

            Console.WriteLine("Booking cancelled");
            return true;
        }
        
        public async Task<List<BookingOutputDto>> GetAllBookings()
        {
            var bookings =  await _db.Bookings
                .Include(s => s.Showing)
                .Include(u => u.User)
                .Include(seats => seats.Seats)
                .ToListAsync();
            
            var bookingOutputDtos = new List<BookingOutputDto>();

            foreach (var booking in bookings)
            {
                bookingOutputDtos.Add(new BookingOutputDto
                {
                    id = booking.Id,
                    bookingDate = booking.BookingDate,
                    price = booking.price,
                    isCancelled = booking.isCancelled,
                    userId = booking.UserId,
                    showingId = booking.ShowingId,
                    
                    seats = booking.Seats.Select(s => new ShowingSeatDto
                    {
                        id = s.Id,
                        seatRow = s.seatRow,
                        seatNumber = s.seatNumber,
                        type = s.type,
                        additionalPrice = s.additionalPrice,
                        isAvailable = s.isAvailable
                    }).ToList()
                    
                });
            }

            return bookingOutputDtos;
        }
        
        public async Task<BookingOutputDto> GetBookingById(int id)
        {
            var booking = await _db.Bookings
                .Include(s => s.Showing)
                .Include(u => u.User)
                .Include(seats => seats.Seats)
                .FirstOrDefaultAsync(s => s.Id == id);

            return new BookingOutputDto
            {
                id = booking.Id,
                bookingDate = booking.BookingDate,
                price = booking.price,
                isCancelled = booking.isCancelled,
                userId = booking.UserId,
                showingId = booking.ShowingId,
                    
                seats = booking.Seats.Select(s => new ShowingSeatDto
                {
                    id = s.Id,
                    seatRow = s.seatRow,
                    seatNumber = s.seatNumber,
                    type = s.type,
                    additionalPrice = s.additionalPrice,
                    isAvailable = s.isAvailable
                }).ToList()
            };
        }

        public async Task<List<BookingOutputDto>> GetBookingsByUserId(int userId)
        {
            var bookings =  await _db.Bookings
                .Include(s => s.Showing)
                .Include(u => u.User)
                .Include(seats => seats.Seats)
                .Where(b => userId == b.UserId)
                .OrderBy(s => s.Showing.date)
                .ToListAsync();
            
            var bookingOutputDtos = new List<BookingOutputDto>();

            foreach (var booking in bookings)
            {
                bookingOutputDtos.Add(new BookingOutputDto
                {
                    id = booking.Id,
                    bookingDate = booking.BookingDate,
                    price = booking.price,
                    isCancelled = booking.isCancelled,
                    userId = booking.UserId,
                    showingId = booking.ShowingId,
                    
                    seats = booking.Seats.Select(s => new ShowingSeatDto
                    {
                        id = s.Id,
                        seatRow = s.seatRow,
                        seatNumber = s.seatNumber,
                        type = s.type,
                        additionalPrice = s.additionalPrice,
                        isAvailable = s.isAvailable
                    }).ToList()
                    
                });
            }

            return bookingOutputDtos;
        }
    }
    
}