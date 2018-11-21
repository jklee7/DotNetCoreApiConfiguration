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
	  CleanDirectory("./publish");
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

Task("Test")
	.Does(() =>
	{
		var projects = GetFiles("./Tests/**/*.csproj");
		foreach(var project in projects)
        {
            Information("Testing project " + project);
            DotNetCoreTest(
                project.ToString(),
                new DotNetCoreTestSettings()
                {
                    Configuration = configuration,
                    NoBuild = true,
                    ArgumentCustomization = args => args.Append("--no-restore"),
                });
        }
	});

Task("Publish")
	.Does(() =>
	{
		DotNetCorePublish("./WebApplication1", new DotNetCorePublishSettings
		{
			OutputDirectory = "./publish/"
		});
	});

Task("CompressToZip")
	.Does(() =>
	{
		var gitversion = GitVersion().SemVer;
		ZipCompress("./publish", $"./artifacts/artifact-{gitversion}.zip");
	});

Task("Default")
	.IsDependentOn("Clean")
	.IsDependentOn("Restore")
	.IsDependentOn("Build")
	.IsDependentOn("Test")
	.IsDependentOn("Publish");

Task("CleanOnly")
	.IsDependentOn("Clean");

RunTarget(target);