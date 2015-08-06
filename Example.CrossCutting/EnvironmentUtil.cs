using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Example.CrossCutting
{
    public static class EnvironmentUtil
    {
        static EnvironmentUtil()
        {
            Assembly assembly = typeof(EnvironmentUtil).Assembly;

            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            Version = fvi.FileVersion;

            BuildDate = File.GetCreationTime(assembly.Location);
        }

        public static String Version { get; private set; }
        public static DateTime BuildDate { get; private set; }
    }
}
