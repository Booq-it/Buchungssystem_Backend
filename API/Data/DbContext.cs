using API.Models;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace API.Data;

public class BackendDbContext : DbContext
{
    public BackendDbContext(DbContextOptions<BackendDbContext> options) : base(options) { }

    public DbSet<User> users { get; set; }
    public DbSet<CinemaRoom> cinemaRooms { get; set; }
    public DbSet<ShowingSeat> seats { get; set; }
    public DbSet<Showing> showings { get; set; }
    public DbSet<Movie> movies { get; set; }
    public DbSet<Booking> bookings { get; set; }
    public DbSet<GuestBooking> guestBookings { get; set; }
}
