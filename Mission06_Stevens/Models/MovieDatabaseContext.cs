using Microsoft.EntityFrameworkCore;

namespace Mission06_Stevens.Models;

public class MovieDatabaseContext : DbContext
{
    public MovieDatabaseContext(DbContextOptions<MovieDatabaseContext> options) : base(options)
    {
    }
    
    public DbSet<movie> movies { get; set; }
}