#r "../tools/Cake/Cake.Common.dll"

public class BuildSettings {
    public PlatformTarget PlatformTarget => PlatformTarget.MSIL;
    public string Configuration => "release";    
}