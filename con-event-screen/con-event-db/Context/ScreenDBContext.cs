using con_event_db.Models;
using Microsoft.EntityFrameworkCore;

namespace con_event_db.Context;

public class ScreenDbContext : DbContext
{
    public ScreenDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public static ScreenDbContext Get()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ScreenDbContext>();
        optionsBuilder.UseSqlite("Data Source=ApiDb.db");
        return new ScreenDbContext(optionsBuilder.Options);
    }
    
    public DbSet<Marquee> Marquees { get; set; }
}