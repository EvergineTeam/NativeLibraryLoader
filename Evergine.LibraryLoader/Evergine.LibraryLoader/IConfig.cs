// Copyright © Plain Concepts S.L.U. All rights reserved. Use is subject to license terms.

namespace Evergine.LibraryLoader
{
    /// <summary>
    /// This interface represent a set of platform path for every architecture where native library are located.
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// Windows platform and x86 architecture path.
        /// </summary>
        string Windows_x86 { get; }

        /// <summary>
        /// Windows platform and x64 architecture path.
        /// </summary>
        string Windows_x64 { get; }

        /// <summary>
        /// Windows platform and arm32 architecture path.
        /// </summary>
        string Windows_ARM { get; }

        /// <summary>
        /// Windows platform and arm64 architecture path.
        /// </summary>
        string Windows_ARM64 { get; }

        /// <summary>
        /// iOS platform and arm64 architecture path.
        /// </summary>
        string IOS_ARM64 { get; }

        /// <summary>
        /// Linux platform and x64 architecture path.
        /// </summary>
        string Linux_x64 { get; }

        /// <summary>
        /// Linux platform and x86 architecture path.
        /// </summary>
        string Linux_x86 { get; }

        /// <summary>
        /// Linux plataform and arm32 architecture path.
        /// </summary>
        string Linux_ARM { get; }

        /// <summary>
        /// Linux platform and arm64 architecture path.
        /// </summary>
        string Linux_ARM64 { get; }

        /// <summary>
        /// MacOS platform and arm64 architecture path.
        /// </summary>
        string OSX_ARM64 { get; }

        /// <summary>
        /// MacOS platform and x64 architecture path.
        /// </summary>
        string OSX_x64 { get; }
    }
}
