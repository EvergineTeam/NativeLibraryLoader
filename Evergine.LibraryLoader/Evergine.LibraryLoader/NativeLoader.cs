// Copyright © Plain Concepts S.L.U. All rights reserved. Use is subject to license terms.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Evergine.LibraryLoader
{
    /// <summary>
    /// This abstract class 
    /// </summary>
    public abstract class NativeLoader
    {
        /// <summary>
        /// Load a native library.
        /// </summary>
        /// <param name="libraryName">The library name to load.</param>
        /// <returns>The pointer reference of the loaded native library.</returns>
        public abstract IntPtr NativeLoad(string libraryName);

        /// <summary>
        /// Free a native library.
        /// </summary>
        /// <param name="libraryHandle">The pointer reference return in the NativeLoad function.</param>
        public abstract void NativeFree(IntPtr libraryHandle);

        /// <summary>
        /// Detect the OS to find the correct library to load.
        /// </summary>
        /// <param name="lib">The lib to load.</param>
        /// <returns>The pointer reference.</returns>
        /// <exception cref="InvalidOperationException">If the running platform is not supported.</exception>
        public IntPtr LoadLibrary(Library lib)
        {
            var os = OSHelper.GetPlatform();
            var architecture = OSHelper.GetArchitecture();

            string libName;
            string runtime = String.Empty;

            switch (os)
            {
                case Platform.Windows:
                case Platform.UWP:
                    libName = lib.WinLibName;

                    switch (architecture)
                    {
                        case Architecture.X86:
                            runtime = lib.Config.Windows_x86;
                            break;
                        case Architecture.X64:
                            runtime = lib.Config.Windows_x64;
                            break;
                        case Architecture.ARM32:
                            runtime = lib.Config.Windows_ARM;
                            break;
                        case Architecture.ARM64:
                            runtime = lib.Config.Windows_ARM64;
                            break;
                    }
                    break;
                case Platform.Android:
                    libName = lib.AndroidLibName;
                    switch (architecture)
                    {
                        case Architecture.X86:
                            runtime = lib.Config.Android_x86;
                            break;
                        case Architecture.X64:
                            runtime = lib.Config.Android_x64;
                            break;
                        case Architecture.ARM32:
                            runtime = lib.Config.Android_ARM;
                            break;
                        case Architecture.ARM64:
                            runtime = lib.Config.Android_ARM64;
                            break;
                    }
                    break;
                case Platform.iOS:
                    libName = lib.IOSLibName;
                    runtime = lib.Config.IOS_ARM64;
                    break;
                case Platform.Linux:
                    libName = lib.LinuxLibName;
                    switch (architecture)
                    {
                        case Architecture.X86:
                            runtime = lib.Config.Linux_x64;
                            break;
                        case Architecture.X64:
                            runtime = lib.Config.Linux_x86;
                            break;
                        case Architecture.ARM32:
                            runtime = lib.Config.Linux_ARM;
                            break;
                        case Architecture.ARM64:
                            runtime = lib.Config.Linux_ARM64;
                            break;
                    }

                    break;
                case Platform.MacOS:
                    libName = lib.OSXLibName;
                    runtime = lib.Config.OSX_ARM64;
                    break;
                case Platform.Undefined:
                default:
                    throw new InvalidOperationException("Invalid Operation system.");
            }

            string libPath = System.IO.Path.Combine(runtime, libName);
            if (lib.Config.BaseDirectory != null)
            {
                libPath = System.IO.Path.Combine(lib.Config.BaseDirectory, libPath);
            }

            lib.Handle = NativeLoad(libPath);
            
            return lib.Handle;
        }

        /// <summary>
        /// Detect the OS to find the way to free the library.
        /// </summary>
        /// <param name="lib"></param>
        public void FreeLibrary(Library lib)
        {
            NativeFree(lib.Handle);
        }
    }
}
