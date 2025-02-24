using System.Runtime.InteropServices;

namespace Marqdouj.CLRCommon
{
    public enum KnownFolder
    {
        Downloads,
    }

    /// <summary>
    /// Path helper methods
    /// </summary>
    public static class PathExtensions
    {
        private static readonly Dictionary<KnownFolder, Guid> _knownFolderGuids = new()
        {
            [KnownFolder.Downloads] = new("374DE290-123F-4565-9164-39C4925E467B"),
        };

        /// <summary>
        /// Helper method to resolve a folder locations not supported by Environment.GetFolderPath 
        /// <see cref="Environment.GetFolderPath(Environment.SpecialFolder)"/>
        /// </summary>
        /// <param name="folder">Currently only the Downloads folder is supported</param>
        /// <returns>null if not found</returns>
        public static string? GetPath(this KnownFolder folder)
        {
            var x = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            var path = SHGetKnownFolderPath(_knownFolderGuids[folder], 0);

            if (string.IsNullOrWhiteSpace(path))
            {
                switch (folder)
                {
                    case KnownFolder.Downloads:
                        path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                        break;
                }
            }

            if (string.IsNullOrWhiteSpace(path))
                return null;

            var info = new DirectoryInfo(path);
            return info.Exists ? info.FullName : null;
        }

        [DllImport("shell32", CharSet = CharSet.Unicode, ExactSpelling = true, PreserveSig = false)]
        private static extern string SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)] Guid rfid, uint dwFlags, nint hToken = default);
    }
}
