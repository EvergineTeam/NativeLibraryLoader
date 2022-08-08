// Copyright © Plain Concepts S.L.U. All rights reserved. Use is subject to license terms.

using Evergine.LibraryLoader.Loaders;
using System;
using System.Collections.Generic;

namespace Evergine.LibraryLoader
{
    /// <summary>
    /// Provides a simple API for loading native libraries.
    /// </summary>
    public class LibraryLoader
    {
        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static readonly LibraryLoader Instance = new LibraryLoader();

        private NativeLoader loader;
        private List<Library> libraries = new List<Library>();

        private LibraryLoader()
        {
#if NET5_0_OR_GREATER
            this.loader = new NetLoader();
#else
            if (OSHelper.IsOSPlatform(Platform.Windows))
            {
                this.loader = new WindowsLoader();
            }

            else if (OSHelper.IsOSPlatform(Platform.Android) || OSHelper.IsOSPlatform(Platform.Linux) || OSHelper.IsOSPlatform(Platform.MacOS))
            {
                this.loader = new UnixLoader();
            }
            else
            {
                throw new InvalidOperationException("Cannot load native libraries on this platform.");
            }
#endif
        }

        /// <summary>
        /// Register a new native library to load.
        /// </summary>
        /// <param name="nativeLib"></param>
        /// <returns></returns>
        public LibraryLoader Register(Library nativeLib)
        {
            libraries.Add(nativeLib);
            return this;
        }

        /// <summary>
        /// Load all the previously registered native libraries.
        /// </summary>
        public void Load()
        {
            foreach (var lib in libraries)
            {
                loader.LoadLibrary(lib);
            }
        }

        /// <summary>
        /// Free all the previously registerd native libraries.
        /// </summary>
        public void Free()
        {
            foreach (var lib in libraries)
            {
                loader.FreeLibrary(lib);
            }
        }
    }
}
