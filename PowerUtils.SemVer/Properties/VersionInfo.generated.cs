using JAL.Utilities;
using System;
using System.Reflection;

[assembly: AssemblyVersion(VersionInfo._assemblyVersionString)]
[assembly: AssemblyFileVersion(VersionInfo._fileVersionString)]
[assembly: AssemblyInformationalVersion(VersionInfo._productVersionString)]

partial class VersionInfo
{
    internal const string _assemblyVersionString = "1.0.0.0";
    internal const string _fileVersionString = "1.0.0.0";
    internal const string _productVersionString = "1.0.0-0+0.0";

    internal static readonly Version AssemblyVersion = new Version(1, 0);
    internal static readonly Version FileVersion = new Version(1, 0, 0, 0);
    internal static readonly SemanticVersion ProductVersion = new SemanticVersion(1, 0, 0,
        new object[] { 0 },
        new object[] { 0, 0 });
}
