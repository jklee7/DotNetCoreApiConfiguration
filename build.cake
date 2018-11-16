#tool "nuget:?package=GitVersion.CommandLine"

// Target - The task you want to start. Runs the Default task if not specified.
var target = Argument("Target", "Default");
var configuration = Argument("Configuration", "Release");

Task("GitVersion")
	.Does(() =>
	{
		var gitversion = GitVersion().SemVer;
		Information(gitversion);
	});

Task("Clean")
	.Does(() =>
	{
	  DotNetCoreClean(".");
	  CleanDirectory("./artifacts");
	});

Task("Restore")
	.Does(() =>
	{
		DotNetCoreRestore();
	});

Task("Build")
	.Does(() =>
	{
		DotNetCoreBuild(".",
			new DotNetCoreBuildSettings()
			{
				Configuration = configuration
			});
	});

Task("Publish")
	.Does(() =>
	{
		DotNetCorePublish("./", new DotNetCorePublishSettings
		{
			OutputDirectory = "./artifacts/"
		});
	});

Task("Default")
	.IsDependentOn("GitVersion")
	.IsDependentOn("Clean")
	.IsDependentOn("Restore")
	.IsDependentOn("Publish");

Task("CleanOnly")
	.IsDependentOn("Clean");

RunTarget(target);