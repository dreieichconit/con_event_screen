#region

using System;
using System.Linq;
using Renci.SshNet;
using WinSCP;
using Session = WinSCP.Session;

#endregion

public class UploadHelper
{
	public static void UploadBuild(string path)
	{
		var sessionOptions = new SessionOptions
		{
			Protocol = Protocol.Sftp,
			HostName = Credentials.Host,
			SshHostKeyPolicy = SshHostKeyPolicy.GiveUpSecurityAndAcceptAny,
			UserName = Credentials.Username,
			SshPrivateKeyPath = Credentials.ScpKeyPath,
		};

		using var session = new Session();

		try
		{
			session.Open(sessionOptions);
			Console.WriteLine("Connected to {0}", Credentials.Host);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}

		var res = session.PutFilesToDirectory(
			path,
			Credentials.WorkingDirectory
		);

		Console.WriteLine($"Uploaded {res.Transfers.Count} files {res.IsSuccess}");
		if (!res.IsSuccess) Console.WriteLine(res.Failures.First().Message);
		Console.WriteLine(new string('#', 50));
	}

	public static void RestartApp()
	{
		var connectionInfo = new ConnectionInfo(
			Credentials.Host,
			Credentials.Port,
			Credentials.Username,
			new PrivateKeyAuthenticationMethod(Credentials.Username, new PrivateKeyFile(Credentials.SshKeyPath))
		);

		using var client = new SshClient(connectionInfo);

		client.Connect();
		Console.WriteLine("Connected to {0}", Credentials.Host);

		var killScreen = client.CreateCommand(Credentials.KillScreen);
		var restart = client.CreateCommand(Credentials.RestartScreen);

		killScreen.Execute();

		Console.WriteLine($"Executed Kill Screen with result: {killScreen.Result}");

		restart.Execute();

		Console.WriteLine($"Executed Restart with result: {restart.Result}");
	}
}