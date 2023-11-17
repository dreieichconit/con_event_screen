namespace Screen.Services.Interfaces.Auth;

public interface IPasswordService
{
	public bool Login(string password);
}