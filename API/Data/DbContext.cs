using API.Models;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace API.Data;

public class BackendDbContext : DbContext
{
    public BackendDbContext(DbContextOptions<BackendDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<CinemaRoom> CinemaRooms { get; set; }
    public DbSet<ShowingSeat> Seats { get; set; }
    public DbSet<Showing> Showings { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    
}
