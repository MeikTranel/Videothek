#addin nuget:?package=Cake.Incubator
#tool "nuget:https://api.nuget.org/v3/index.json?package=GitVersion.CommandLine&version=3.6.2"

#load "./build/Directories.cake"
#load "./build/Settings.cake"

DirectoryPath baseOutDir = DirectoryPath.FromString("./out");
BuildDirectories Directories;
BuildSettings Settings;
GitVersion Version;

Setup(ctx =>
{
   Version = GitVersion();
   Directories = new BuildDirectories(baseOutDir,Version);
   Settings = new BuildSettings();
});

Task("Restore-Dependencies")
.Does(() => {
    NuGetRestore("./src/Videothek.sln");
});

Task("Compile")
.IsDependentOn("Restore-Dependencies")
.Does(() => {
   MSBuild(
       "./src/Videothek.sln",
       new MSBuildSettings(){
           BinaryLogger = new MSBuildBinaryLogSettings() {
               Enabled = true,
               FileName = Directories.LogOutputDirectory + "/MSBuild.binlog"
           },
           ToolVersion = MSBuildToolVersion.VS2017,
           Configuration = Settings.Configuration,
           PlatformTarget = Settings.PlatformTarget
       }
    );
});

Task("Publish")
.IsDependentOn("Compile")
.Does(() => {
    var ProjectsToBePublished = new CustomProjectParserResult[]{
        ParseProject("./src/Videothek.Terminal/Videothek.Terminal.csproj",Settings.Configuration)
    };
    foreach(var project in ProjectsToBePublished){
        CopyDirectory(project.OutputPath,Directories.BinaryOutputDirectory.Combine(project.AssemblyName));
    }
});

RunTarget("Publish");