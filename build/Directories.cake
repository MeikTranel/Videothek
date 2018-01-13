public class BuildDirectories
{
    public DirectoryPath OutputDirectory { get; }

    public DirectoryPath BinaryOutputDirectory => OutputDirectory.Combine("binaries");
    public DirectoryPath LogOutputDirectory => OutputDirectory.Combine("logs");
    public DirectoryPath DeploymentDirectory => OutputDirectory.Combine("deployment");
    public DirectoryPath GitHubDeploymentDirectory => DeploymentDirectory.Combine("github");
    public DirectoryPath TestResults => OutputDirectory.Combine("test-results");

    public BuildDirectories(DirectoryPath baseOutputDirectory,GitVersion version)
    {
        if(version == null)
            throw new ArgumentNullException(nameof(version));
        if(baseOutputDirectory == null)
            throw new ArgumentNullException(nameof(baseOutputDirectory));

        OutputDirectory = baseOutputDirectory.Combine(version.SemVer);
    }
}

