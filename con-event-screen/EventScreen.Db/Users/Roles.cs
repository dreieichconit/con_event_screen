namespace EventScreen.Db.Users;

public class Roles
{
	public static string GlobalAdministrator => "GlobalAdmin";
    
	public static string Administrator => "Administrator";
    
	public static string[] RoleArray => new[]
	{
		GlobalAdministrator,
		Administrator,
	};
}