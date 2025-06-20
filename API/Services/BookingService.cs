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
                var seats = await _db.seats
                    .Where(s => bookingInputDto.seatIds.Contains(s.id))
                    .ToListAsync();

                var user = await _db.users
                    .Include(b => b.bookings)
                    .FirstOrDefaultAsync(u => u.id == bookingInputDto.userId);

                if (user == null)
                    return false;

                var showing = await _db.showings
                    .FirstOrDefaultAsync(s => s.id == bookingInputDto.showingId);

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
                    bookingDate = DateTime.Now,
                    price = bookingInputDto.price,
                    isCancelled = false,
                    userId = bookingInputDto.userId,
                    showingId = bookingInputDto.showingId,
                    seats = seats
                };

                await _db.bookings.AddAsync(booking);
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
                var seats = await _db.seats
                    .Where(s => bookingInputDto.seatIds.Contains(s.id))
                    .ToListAsync();
                
                var showing = await _db.showings
                    .FirstOrDefaultAsync(s => s.id == bookingInputDto.showingId);

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
                    bookingDate = DateTime.Now,
                    price = bookingInputDto.price,
                    isCancelled = false,
                    guestFirstName = bookingInputDto.GuestFirstName,
                    guestLastName = bookingInputDto.GuestLastName,
                    guestEmail = bookingInputDto.GuestEmail,
                    showingId = bookingInputDto.showingId,
                    seats = seats
                };

                await _db.guestBookings.AddAsync(booking);
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
            var booking = await _db.bookings
                .Include(s => s.seats)
                .FirstOrDefaultAsync(b => b.id == bookingId);

            if (booking == null || booking.isCancelled)
                return false;

            booking.isCancelled = true;

            foreach (var seat in booking.seats)
            {
                seat.isAvailable = true;
            }

            _db.bookings.Update(booking);
            _db.seats.UpdateRange(booking.seats);
            await _db.SaveChangesAsync();

            Console.WriteLine("Booking cancelled");
            return true;
        }
        
        public async Task<List<BookingOutputDto>> GetAllBookings()
        {
            var bookings =  await _db.bookings
                .Include(s => s.showing)
                .Include(u => u.user)
                .Include(seats => seats.seats)
                .ToListAsync();
            
            var bookingOutputDtos = new List<BookingOutputDto>();

            foreach (var booking in bookings)
            {
                bookingOutputDtos.Add(new BookingOutputDto
                {
                    id = booking.id,
                    bookingDate = booking.bookingDate,
                    price = booking.price,
                    isCancelled = booking.isCancelled,
                    userId = booking.userId,
                    showingId = booking.showingId,
                    
                    seats = booking.seats.Select(s => new ShowingSeatDto
                    {
                        id = s.id,
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
            var booking = await _db.bookings
                .Include(s => s.showing)
                .Include(u => u.user)
                .Include(seats => seats.seats)
                .FirstOrDefaultAsync(s => s.id == id);

            return new BookingOutputDto
            {
                id = booking.id,
                bookingDate = booking.bookingDate,
                price = booking.price,
                isCancelled = booking.isCancelled,
                userId = booking.userId,
                showingId = booking.showingId,
                    
                seats = booking.seats.Select(s => new ShowingSeatDto
                {
                    id = s.id,
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
            var bookings =  await _db.bookings
                .Include(s => s.showing)
                .Include(u => u.user)
                .Include(seats => seats.seats)
                .Where(b => userId == b.userId)
                .OrderBy(s => s.showing.date)
                .ToListAsync();
            
            var bookingOutputDtos = new List<BookingOutputDto>();

            foreach (var booking in bookings)
            {
                bookingOutputDtos.Add(new BookingOutputDto
                {
                    id = booking.id,
                    bookingDate = booking.bookingDate,
                    price = booking.price,
                    isCancelled = booking.isCancelled,
                    userId = booking.userId,
                    showingId = booking.showingId,
                    
                    seats = booking.seats.Select(s => new ShowingSeatDto
                    {
                        id = s.id,
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