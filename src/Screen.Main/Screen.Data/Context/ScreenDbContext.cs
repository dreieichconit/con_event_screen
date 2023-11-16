using Microsoft.EntityFrameworkCore;
using Screen.Data.Models;

namespace Screen.Data.Context;

public class ScreenDbContext : DbContext
{
	public ScreenDbContext(DbContextOptions<ScreenDbContext> options) : base(options)
	{
		
	}

	public DbSet<Configuration> Configurations { get; set; } = null!;

	public DbSet<Marquee> Marquees { get; set; } = null!;

	public DbSet<Page> Pages { get; set; } = null!;

	public DbSet<Image> Images { get; set; } = null!;
}