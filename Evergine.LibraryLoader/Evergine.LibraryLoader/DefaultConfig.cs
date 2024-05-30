// Copyright © Plain Concepts S.L.U. All rights reserved. Use is subject to license terms.

using System.Reflection;

namespace Evergine.LibraryLoader
{
    /// <summary>
    /// This class represent the default paths used to looking for native libraries in every platform supported.
    /// </summary>
    public class DefaultConfig : IConfig
    {
        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static readonly IConfig Instance = new DefaultConfig();

        /// <inheritdoc/>
        public string Windows_x86 => "runtimes/win-x86/native";

        /// <inheritdoc/>
        public string Windows_x64 => "runtimes/win-x64/native";

        /// <inheritdoc/>
        public string Windows_ARM => "runtimes/win-arm/native";

        /// <inheritdoc/>
        public string Windows_ARM64 => "runtimes/win-arm64/native";

        /// <inheritdoc/>
        public string IOS_ARM64 => "runtimes/ios-arm64/native";

        /// <inheritdoc/>
        public string Linux_x86 => "runtimes/linux-x86/native";

        /// <inheritdoc/>
        public string Linux_x64 => "runtimes/linux-x64/native";

        /// <inheritdoc/>
        public string Linux_ARM => "runtimes/linux-arm/native";

        /// <inheritdoc/>
        public string Linux_ARM64 => "runtimes/linux-arm64/native";

        /// <inheritdoc/>
        public string Android_x86 => "runtimes/android-x86/native";

        /// <inheritdoc/>
        public string Android_x64 => "runtimes/android-x64/native";

        /// <inheritdoc/>
        public string Android_ARM => "runtimes/android-arm/native";

        /// <inheritdoc/>
        public string Android_ARM64 => "runtimes/android-arm64/native";

        /// <inheritdoc/>
        public string OSX_x64 => "runtimes/osx-x64/native";

        /// <inheritdoc/>
        public string OSX_ARM64 => "runtimes/osx-arm64/native";

        /// <inheritdoc/>
        public string UWP_x86 => "runtimes/win-x86/nativeassets/uap10.0";

        /// <inheritdoc/>
        public string UWP_x64 => "runtimes/win-x64/nativeassets/uap10.0";

        /// <inheritdoc/>
        public string UWP_ARM => "runtimes/win-arm/nativeassets/uap10.0";

        /// <inheritdoc/>
        public string UWP_ARM64 => "runtimes/win-arm64/nativeassets/uap10.0";

        /// <inheritdoc/>
        public string BaseDirectory { get; private set; }

        private DefaultConfig()
        { 
        }

        /// <inheritdoc/>
        public IConfig WithBaseDirectory(string baseDirectory)
        {
            BaseDirectory = baseDirectory;
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
