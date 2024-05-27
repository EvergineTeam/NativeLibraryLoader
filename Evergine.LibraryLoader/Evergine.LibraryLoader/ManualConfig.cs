// Copyright © Plain Concepts S.L.U. All rights reserved. Use is subject to license terms.

using System.IO;
using System.Reflection;

namespace Evergine.LibraryLoader
{
    /// <summary>
    /// This class allow set specific path for every platform and architecture supported.
    /// </summary>
    public class ManualConfig : IConfig
    {
        /// <inheritdoc/>
        public string Windows_x86 { get; private set; }

        /// <inheritdoc/>
        public string Windows_x64 { get; private set; }

        /// <inheritdoc/>
        public string Windows_ARM { get; private set; }

        /// <inheritdoc/>
        public string Windows_ARM64 { get; private set; }

        /// <inheritdoc/>
        public string IOS_ARM64 { get; private set; }

        /// <inheritdoc/>
        public string Linux_x64 { get; private set; }

        /// <inheritdoc/>
        public string Linux_x86 { get; private set; }

        /// <inheritdoc/>
        public string Linux_ARM { get; private set; }

        /// <inheritdoc/>
        public string Linux_ARM64 { get; private set; }

        /// <inheritdoc/>
        public string OSX_ARM64 { get; private set; }

        /// <inheritdoc/>
        public string OSX_x64 { get; private set; }

        /// <inheritdoc/>
        public string BaseDirectory { get; private set; }

        private ManualConfig()
        {
        }

        /// <summary>
        /// Create a new instance inline.
        /// </summary>
        /// <returns></returns>
        public static ManualConfig Create()
        {
            return new ManualConfig();
        }

        /// <summary>
        /// Set a Specific path.
        /// </summary>
        /// <param name="path">Specific path.</param>
        /// <returns>ManualConfig to be used as fluent api.</returns>
        public ManualConfig SetWindows_x86(string path)
        {
            this.Windows_x86 = path;
            return this;
        }

        /// <summary>
        /// Set a Specific path.
        /// </summary>
        /// <param name="path">Specific path.</param>
        /// <returns>ManualConfig to be used as fluent api.</returns>
        public ManualConfig SetWindows_x64(string path)
        {
            this.Windows_x64 = path;
            return this;
        }

        /// <summary>
        /// Set a Specific path.
        /// </summary>
        /// <param name="path">Specific path.</param>
        /// <returns>ManualConfig to be used as fluent api.</returns>

        public ManualConfig SetWindows_ARM(string path)
        {
            this.Windows_ARM = path;
            return this;
        }

        /// <summary>
        /// Set a Specific path.
        /// </summary>
        /// <param name="path">Specific path.</param>
        /// <returns>ManualConfig to be used as fluent api.</returns>

        public ManualConfig SetWindows_ARM64(string path)
        {
            this.Windows_ARM64 = path;
            return this;
        }

        /// <summary>
        /// Set a Specific path.
        /// </summary>
        /// <param name="path">Specific path.</param>
        /// <returns>ManualConfig to be used as fluent api.</returns>

        public ManualConfig SetIOS_ARM64(string path)
        {
            this.IOS_ARM64 = path;
            return this;
        }

        /// <summary>
        /// Set a Specific path.
        /// </summary>
        /// <param name="path">Specific path.</param>
        /// <returns>ManualConfig to be used as fluent api.</returns>

        public ManualConfig SetLinux_x64(string path)
        {
            this.Linux_x64 = path;
            return this;
        }

        /// <summary>
        /// Set a Specific path.
        /// </summary>
        /// <param name="path">Specific path.</param>
        /// <returns>ManualConfig to be used as fluent api.</returns>

        public ManualConfig SetLinux_x86(string path)
        {
            this.Linux_x86 = path;
            return this;
        }

        /// <summary>
        /// Set a Specific path.
        /// </summary>
        /// <param name="path">Specific path.</param>
        /// <returns>ManualConfig to be used as fluent api.</returns>

        public ManualConfig SetLinux_ARM(string path)
        {
            this.Linux_ARM = path;
            return this;
        }

        /// <summary>
        /// Set a Specific path.
        /// </summary>
        /// <param name="path">Specific path.</param>
        /// <returns>ManualConfig to be used as fluent api.</returns>

        public ManualConfig SetLinux_ARM64(string path)
        {
            this.Linux_ARM64 = path;
            return this;
        }

        /// <summary>
        /// Set a Specific path.
        /// </summary>
        /// <param name="path">Specific path.</param>
        /// <returns>ManualConfig to be used as fluent api.</returns>

        public ManualConfig SetOSX_ARM64(string path)
        {
            this.OSX_ARM64 = path;
            return this;
        }

        /// <summary>
        /// Set a Specific path.
        /// </summary>
        /// <param name="path">Specific path.</param>
        /// <returns>ManualConfig to be used as fluent api.</returns>

        public ManualConfig SetOSX_x64(string path)
        {
            this.OSX_x64 = path;
            return this;
        }

        /// <inheritdoc/>
        public IConfig WithBaseDirectory(string baseDirectory)
        {
            this.BaseDirectory = baseDirectory;
            return this;
        }

        /// <inheritdoc/>
        public IConfig WithAssemblyDirectory(Assembly assembly)
        {
            return WithBaseDirectory(System.IO.Path.GetDirectoryName(assembly.Location));
        }

        /// <inheritdoc/>
        public IConfig WithTypeAssemblyDirectory<T>()
        {
            return WithAssemblyDirectory(typeof(T).Assembly);
        }
    }
}
