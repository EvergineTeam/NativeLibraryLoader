// Copyright © Plain Concepts S.L.U. All rights reserved. Use is subject to license terms.

using System;
using System.Collections.Generic;
using System.Text;

namespace Evergine.LibraryLoader.Loaders
{
    /// <summary>
    /// This class represent a Windows native loader based on kernerl32 API.
    /// </summary>
    public class WindowsLoader : NativeLoader
    {
        /// <inheritdoc/>
        public override IntPtr NativeLoad(string libraryName)
        {
            return Kernel32.LoadLibrary(libraryName);
        }

        /// <inheritdoc/>
        public override void NativeFree(IntPtr libraryHandle)
        {
            Kernel32.FreeLibrary(libraryHandle);
        }
    }
}
