using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace EventScreen.Db.Models;

public class ApplicationUser : IdentityUser
{
	public string FirstName { get; set; }

	public string LastName { get; set; }

	[NotMapped] public bool New { get; set; } = false;
}