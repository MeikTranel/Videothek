#load "./Directories.cake"
public class BuildSettings {
    public GitVersion Version { get; }
    public BuildDirectories Directories { get; } 
    public PlatformTarget PlatformTarget => PlatformTarget.MSIL;
    public string Configuration => "release";   


    public BuildSettings(GitVersion version,DirectoryPath baseOutputDirectory){
        Directories = new BuildDirectories(
            baseOutputDirectory,
            version
        );
        Version = version;
    }
}

public static BuildSettings CreateBuildSettings(ICakeContext context,GitVersion version,DirectoryPath baseOutputDirectory){
    context.Information($"Initializing build settings with version: {version.SemVer}");
    return new BuildSettings(version,baseOutputDirectory);
}