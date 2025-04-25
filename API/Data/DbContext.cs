using API.Models;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace API.Data;

public class BackenDbContext : DbContext
{
    public BackenDbContext(DbContextOptions<BackenDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}
