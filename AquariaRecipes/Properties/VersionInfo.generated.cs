

using Enhancer.Assemblies;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

[assembly: AssemblyVersion(VersionInfo._assemblyVersionString)]
[assembly: AssemblyFileVersion(VersionInfo._fileVersionString)]
[assembly: AssemblyInformationalVersion(VersionInfo._productVersionString)]

/// <summary>
/// This class holds copies of the version numbers this assembly uses.
/// </summary>
[ExcludeFromCodeCoverage]
partial class VersionInfo
{
    internal const string _assemblyVersionString = "1.0";
    internal const string _fileVersionString     = "1.0.0.0";
    internal const string _productVersionString  = "1.0.0-alpha+adam.OBSIDIAN.Win32NT";

    private static readonly Version         _assemblyVersion = new Version(1, 0);
    private static readonly Version         _fileVersion     = new Version(1, 0, 0, 0);
    private static readonly SemanticVersion _productVersion  = new SemanticVersion(1, 0, 0,
        new object[] { "alpha" },
        new object[] { "adam", "OBSIDIAN", System.PlatformID.Win32NT });

    /// <summary>Gets the version of the assembly.</summary>
    [DebuggerNonUserCode]
    public static Version AssemblyVersion => _assemblyVersion;

    /// <summary>Gets the version of the file.</summary>
    [DebuggerNonUserCode]
    public static Version FileVersion => _fileVersion;

    /// <summary>Gets the version of the product.</summary>
    [DebuggerNonUserCode]
    public static SemanticVersion ProductVersion => _productVersion;
}