using System;
using System.IO;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

class Build : NukeBuild
{
	/// Support plugins are available for:
	///   - JetBrains ReSharper        https://nuke.build/resharper
	///   - JetBrains Rider            https://nuke.build/rider
	///   - Microsoft VisualStudio     https://nuke.build/visualstudio
	///   - Microsoft VSCode           https://nuke.build/vscode
	static DotNetPublishSettings pubSettings;

	[Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
	readonly Configuration Configuration = Configuration.Release;

	[Solution] readonly Solution Solution;

	AbsolutePath SourceDirectory => RootDirectory / "source";

	AbsolutePath TestsDirectory => RootDirectory / "tests";

	AbsolutePath OutputDirectory => RootDirectory / "release";

	public static int Main() => Execute<Build>(x => x.Publish);

	Target Clean => _ => _
						.Before(Restore)
						.Executes(() =>
							{
								foreach (var path in SourceDirectory.GlobDirectories("**/bin", "**/obj"))
								{
									path.DeleteDirectory();
								}

								foreach (var path in TestsDirectory.GlobDirectories("**/bin", "**/obj"))
								{
									path.DeleteDirectory();
								}

								OutputDirectory.CreateOrCleanDirectory();
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
													.SetRuntime("ubuntu.18.04-x64")
													.SetConfiguration(global::Configuration.Release)
													.SetSelfContained(false)
													.SetPublishTrimmed(false)
									);

									var rootPath = Path.Combine(Solution.Directory, "con-event-screen", "ApiDb.db");

									CopyFile(rootPath, Path.Combine(rootPath, OutputDirectory, "ApiDb.db"),
										FileExistsPolicy.Overwrite
									);
								}
							);
}