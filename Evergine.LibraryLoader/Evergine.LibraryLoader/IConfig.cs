// Copyright © Plain Concepts S.L.U. All rights reserved. Use is subject to license terms.

using System.Reflection;

namespace Evergine.LibraryLoader
{
    /// <summary>
    /// This interface represent a set of platform path for every architecture where native library are located.
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// The base directory used to look for native libraries. If null the current directory is used.
        /// </summary>
        string BaseDirectory { get; }

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
        /// Android platform and x64 architecture path.
        /// </summary>
        string Android_x64 { get; }

        /// <summary>
        /// Android platform and x86 architecture path.
        /// </summary>
        string Android_x86 { get; }

        /// <summary>
        /// Android plataform and arm32 architecture path.
        /// </summary>
        string Android_ARM { get; }

        /// <summary>
        /// Android platform and arm64 architecture path.
        /// </summary>
        string Android_ARM64 { get; }

        /// <summary>
        /// MacOS platform and arm64 architecture path.
        /// </summary>
        string OSX_ARM64 { get; }

        /// <summary>
        /// MacOS platform and x64 architecture path.
        /// </summary>
        string OSX_x64 { get; }

        /// <summary>
        /// Set the base directory used to look for native libraries.
        /// </summary>
        /// <param name="baseDirectory">The directory path.</param>
        /// <returns>The current config instance.</returns>
        IConfig WithBaseDirectory(string baseDirectory);

        /// <summary>
        /// Set the assembly directory to look for native libraries.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>The current config instance.</returns>
        IConfig WithAssemblyDirectory(Assembly assembly);

        /// <summary>
        /// Set the type assembly directory to look for native libraries.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>The current config instance.</returns>
        IConfig WithTypeAssemblyDirectory<T>();
    }
}
