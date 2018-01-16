#tool "nuget:https://api.nuget.org/v3/index.json?package=GitVersion.CommandLine&version=3.6.2"

#addin "Cake.Incubator"

#load "./build/Settings.cake"
var target = Argument("target", "Package");
BuildSettings Settings;
Setup(ctx =>
{
    Settings = new BuildSettings(
       GitVersion(),
       DirectoryPath.FromString("./out")
    );
});

Task("AppVeyor-UpdateBuildVersion") 
.WithCriteria(() => BuildSystem.IsRunningOnAppVeyor) 
.Does(() => {
    Information($"Updating AppVeyor build version to {Settings.Version.SemVer}.");
    BuildSystem.AppVeyor.UpdateBuildVersion(Settings.Version.SemVer);
})
.OnError(exception =>
{  
    Debug(exception);
    Warning($"Build with version {Settings.Version.SemVer} already exists.");
    Information("Trying to update to fallback Version");
    BuildSystem.AppVeyor.UpdateBuildVersion(Settings.Version.InformationalVersion);
});

Task("Restore-Dependencies")
.IsDependentOn("AppVeyor-UpdateBuildVersion")
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
               FileName = Settings.Directories.LogOutputDirectory + "/MSBuild.binlog"
           },
           ToolVersion = MSBuildToolVersion.VS2017,
           Configuration = Settings.Configuration,
           PlatformTarget = Settings.PlatformTarget,
           Verbosity = Verbosity.Minimal
       }
    );
});

Task("Publish")
.IsDependentOn("Compile")
.Does(() => {
    var ProjectsToBePublished = new CustomProjectParserResult[]{
        ParseProject("./src/Videothek.Terminal/Videothek.Terminal.csproj","Release")
    };
    foreach(var project in ProjectsToBePublished){
        CopyDirectory(project.OutputPath,Settings.Directories.BinaryOutputDirectory.Combine(project.AssemblyName));
    }
});


Task("Package") 
.IsDependentOn("Publish") 
.Does(() => { 
    var artifactFolders = GetDirectories(Settings.Directories.BinaryOutputDirectory.FullPath + "/**/*"); 
    Information($"Found {artifactFolders.Count} Artifact directories.");
    foreach(var artifactFolder in artifactFolders){ 
        Information($"Zipping {artifactFolder}");
        Zip(artifactFolder.FullPath,Settings.Directories.BinaryOutputDirectory.CombineWithFilePath(artifactFolder.GetDirectoryName() + ".zip")); 
    } 
}); 

Task("AppVeyor") 
.WithCriteria(() => BuildSystem.IsRunningOnAppVeyor) 
.IsDependentOn("Package") 
.Does(() => 
{     
    foreach(var artifactZip in GetFiles(Settings.Directories.BinaryOutputDirectory + "/*.zip")){ 
        Information($"Uploading { artifactZip } to AppVeyor as '{ artifactZip.GetFilename()}'."); 
        BuildSystem.AppVeyor.UploadArtifact(artifactZip);
    } 
});

RunTarget(target);