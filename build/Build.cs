using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

class Build : NukeBuild
{
	/// Support plugins are available for:
	///   - JetBrains ReSharper        https://nuke.build/resharper
	///   - JetBrains Rider            https://nuke.build/rider
	///   - Microsoft VisualStudio     https://nuke.build/visualstudio
	///   - Microsoft VSCode           https://nuke.build/vscode
	public static int Main() => Execute<Build>(x => x.Publish);

	[Solution(GenerateProjects = true)]  
	readonly Solution Solution;

	[Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
	readonly Configuration Configuration = Configuration.Release;

	static AbsolutePath SourceDirectory => RootDirectory / "source";

	static AbsolutePath TestsDirectory => RootDirectory / "tests";

	static AbsolutePath OutputDirectory => RootDirectory / "release";

	Target Clean => targetDefinition
		=> targetDefinition
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

	Target Restore => targetDefinition
		=> targetDefinition
			.DependsOn(Clean)
			.Executes(() =>
				{
					DotNetRestore(s => s
						.SetProjectFile(Solution)
					);
				}
			);

	Target Compile => targetDefinition
		=> targetDefinition
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

	Target Publish => targetDefinition
		=> targetDefinition
			.DependsOn(Compile)
			.Executes(() =>
				{
					DotNetPublish(s => s
										.SetProject(Solution.Screen)
										.SetOutput(OutputDirectory)
										.SetConfiguration(Configuration.Release)
										.SetPublishSingleFile(true)
										.SetSelfContained(true)
										.SetPublishTrimmed(false)
					);
				}
			);
}