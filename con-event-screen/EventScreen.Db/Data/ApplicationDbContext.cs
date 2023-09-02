using EventScreen.Db.Models;
using EventScreen.Db.Models.Settings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventScreen.Db.Data;

public class ApplicationDbContext : IdentityDbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
	}

	public static ApplicationDbContext Get()
	{
		var options = new DbContextOptionsBuilder<ApplicationDbContext>()
					.UseSqlite("DataSource=app.db").Options;
		return new ApplicationDbContext(options);
	}

	public new DbSet<ApplicationUser> Users { get; set; } = null!;

	public DbSet<ActiveSetting> ActiveSettings { get; set; } = null!;

	public DbSet<EventConfig> EventConfigs { get; set; } = null!;

	public DbSet<ApiSettings> ApiSettings { get; set; } = null!;

	public DbSet<Theme> Themes { get; set; } = null!;

	public DbSet<ThemeSettings> ThemeSettings { get; set; } = null!;

	public DbSet<MarqueeSettings> MarqueeSettings { get; set; } = null!;

	public DbSet<Screen> Screens { get; set; } = null!;

	public DbSet<ScreenSettings> ScreenSettings { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.Entity<ThemeSettings>().Navigation(x => x.CurrentTheme).AutoInclude();

		builder.Entity<ScreenSettings>().Navigation(x => x.Screens).AutoInclude();

		builder.Entity<ActiveSetting>().Navigation(x => x.ActiveConfig).AutoInclude();
		builder.Entity<EventConfig>().Navigation(x => x.EventScreens).AutoInclude();
		
		base.OnModelCreating(builder);
	}
}