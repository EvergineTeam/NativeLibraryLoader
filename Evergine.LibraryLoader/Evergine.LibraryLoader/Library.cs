// Copyright © Plain Concepts S.L.U. All rights reserved. Use is subject to license terms.

using System;

namespace Evergine.LibraryLoader
{
    /// <summary>
    /// This class represent a native library.
    /// </summary>
    public class Library
    {
        /// <summary>
        /// The base name used inside the dllimport attributes.
        /// </summary>
        public string LibName { get; private set; }

        /// <summary>
        /// The file name used on Windows.
        /// </summary>
        public string WinLibName { get; private set; }

        /// <summary>
        /// The file name used on Android.
        /// </summary>
        public string AndroidLibName { get; private set; }

        /// <summary>
        /// The file name used on iOS.
        /// </summary>
        public string IOSLibName { get; private set; }

        /// <summary>
        /// The file name used on MacOS.
        /// </summary>
        public string OSXLibName { get; private set; }

        /// <summary>
        /// The file name used on Linux.
        /// </summary>
        public string LinuxLibName { get; private set; }

        /// <summary>
        /// The file name used on wasm.
        /// </summary>
        public string WebLibName { get; private set; }

        /// <summary>
        /// The config used to load this library.
        /// </summary>
        public IConfig Config { get; private set; }

        /// <summary>
        /// The poitner reference once the library is loaded.
        /// </summary>
        public IntPtr Handle { get; internal set; }

        /// <summary>
        /// Create a new library to load inline.
        /// </summary>
        /// <param name="libName"></param>
        /// <returns></returns>
        public static Library Create(string libName)
        {
            return new Library(libName);
        }

        private Library(string libName)
        {
            this.LibName = libName;
        }

        /// <summary>
        /// Add the config used to load this library.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public Library AddConfig(IConfig config)
        {
            this.Config = config;
            return this;
        }

        /// <summary>
        /// Set a specify lib name for a supported platform.
        /// </summary>
        /// <param name="platform">The selected platform.</param>
        /// <param name="libName">The specific lib name.</param>
        /// <returns></returns>
        public Library SetPlatform(Platform platform, string libName)
        {
            switch (platform)
            {
                case Platform.Windows:
                    this.WinLibName = libName;
                    break;
                case Platform.Android:
                    this.AndroidLibName = libName;
                    break;
                case Platform.iOS:
                    this.IOSLibName = libName;
                    break;
                case Platform.Linux:
                    this.LinuxLibName = libName;
                    break;
                case Platform.MacOS:
                    this.OSXLibName = libName;
                    break;
                case Platform.Web:
                    this.WebLibName = libName;
                    break;
            }

            return this;
        }
    }
}
