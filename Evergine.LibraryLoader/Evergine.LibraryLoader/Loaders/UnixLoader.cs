// Copyright © Plain Concepts S.L.U. All rights reserved. Use is subject to license terms.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Evergine.LibraryLoader.Loaders
{
    /// <summary>
    /// This class represent a unix platform native library.
    /// </summary>
    public class UnixLoader : NativeLoader
    {
        /// <inheritdoc/>
        public override IntPtr NativeLoad(string libraryName)
        {
            Libdl.dlerror();
            IntPtr handle = Libdl.dlopen(libraryName, Libdl.RTLD_NOW);
            if (handle == IntPtr.Zero && !Path.IsPathRooted(libraryName))
            {
                string baseDir = AppContext.BaseDirectory;
                if (!string.IsNullOrWhiteSpace(baseDir))
                {
                    string localPath = Path.Combine(baseDir, libraryName);
                    handle = Libdl.dlopen(localPath, Libdl.RTLD_NOW);
                }
            }

            return handle;
        }

        /// <inheritdoc/>
        public override void NativeFree(IntPtr libraryHandle)
        {
            Libdl.dlclose(libraryHandle);
        }
    }
}
