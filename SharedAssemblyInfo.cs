using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


#if DEBUG
    [assembly: AssemblyConfiguration("Debug")]
#endif

#if RELEASE
    [assembly: AssemblyConfiguration("Release")]
#endif

[assembly: InternalsVisibleTo("Example.Tests")]
[assembly: ComVisible(false)]
[assembly: AssemblyCompany("Example")]
[assembly: AssemblyProduct("Domain Oriented Architecture")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

