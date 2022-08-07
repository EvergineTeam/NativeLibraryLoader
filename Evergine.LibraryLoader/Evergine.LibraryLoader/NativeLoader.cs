using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Evergine.LibraryLoader
{
    public abstract class NativeLoader
    {
        public abstract IntPtr NativeLoad(string libraryName);
        public abstract void NativeFree(IntPtr libraryHandle);

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
                    runtime = lib.Config.Linux_ARM64;
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
            lib.Handle = NativeLoad(libPath);
            
            return lib.Handle;
        }

        public void FreeLibrary(Library lib)
        {
            NativeFree(lib.Handle);
        }
    }
}
