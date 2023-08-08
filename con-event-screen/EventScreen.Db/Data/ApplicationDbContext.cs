using EventScreen.Db.Models;
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
	
	public DbSet<ApplicationUser> Users { get; set; }
}