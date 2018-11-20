#tool "nuget:?package=GitVersion.CommandLine"
#addin "nuget:?package=SharpZipLib"
#addin "nuget:?package=Cake.Compression"

// Target - The task you want to start. Runs the Default task if not specified.
var target = Argument("Target", "Default");
var configuration = Argument("Configuration", "Release");

Task("Clean")
	.Does(() =>
	{
	  DotNetCoreClean(".");
	  CleanDirectory("./artifacts");
	  CleanDirectory("./build");
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
			OutputDirectory = "./build/"
		});
	});

Task("CompressToZip")
	.Does(() =>
	{
		var gitversion = GitVersion().SemVer;
		ZipCompress("./build", $"./artifacts/artifact-{gitversion}.zip");
	});

Task("Default")
	.IsDependentOn("Clean")
	.IsDependentOn("Restore")
	.IsDependentOn("Publish");

Task("CleanOnly")
	.IsDependentOn("Clean");

RunTarget(target);