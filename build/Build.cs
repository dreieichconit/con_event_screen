#region

using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

#endregion

class Build : NukeBuild
{
	static DotNetPublishSettings pubSettings;

	[Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
	readonly Configuration Configuration = Configuration.Release;

	[Solution] readonly Solution Solution;

	AbsolutePath SourceDirectory => RootDirectory / "source";

	AbsolutePath TestsDirectory => RootDirectory / "tests";

	AbsolutePath OutputDirectory => RootDirectory / "publish";

	Target Clean => _ => _
						.Before(Restore)
						.Executes(() =>
							{
								SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
								TestsDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
								EnsureCleanDirectory(OutputDirectory);
							}
						);

	Target Restore => _ => _
							.DependsOn(Clean)
							.Executes(() =>
								{
									DotNetRestore(s => s
										.SetProjectFile(Solution)
									);
								}
							);

	Target Compile => _ => _
							.DependsOn(Restore)
							.Executes(() =>
								{
									DotNetBuild(s => s
													.SetProjectFile(Solution)
													.SetConfiguration(Configuration)
													.EnableNoRestore()
									);
								}
							);

	Target Publish => _ => _
							.DependsOn(Compile)
							.Executes(() =>
								{
									DotNetPublish(s => s
													.SetOutput(OutputDirectory)
													.SetRuntime("ubuntu.20.04-x64")
													.SetConfiguration(Configuration.Release)
													.SetSelfContained(false)
													.SetPublishTrimmed(false)
									);

									// var rootPath = Path.Combine(Solution.Directory, "WebUI", "ApiDb.db");
									//
									// CopyFile(rootPath, Path.Combine(rootPath, OutputDirectory, "ApiDb.db"), FileExistsPolicy.Overwrite);
								}
							);

	Target Upload => _ => _
						.DependsOn(Publish)
						.Executes(() =>
							{
								UploadHelper.UploadBuild(OutputDirectory);
								UploadHelper.RestartApp();
							}
						);

	/// Support plugins are available for:
	/// - JetBrains ReSharper        https://nuke.build/resharper
	/// - JetBrains Rider            https://nuke.build/rider
	/// - Microsoft VisualStudio     https://nuke.build/visualstudio
	/// - Microsoft VSCode           https://nuke.build/vscode
	public static int Main() => Execute<Build>(x => x.Upload);
}