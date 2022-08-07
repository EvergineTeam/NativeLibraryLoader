// Copyright © Plain Concepts S.L.U. All rights reserved. Use is subject to license terms.

using System;
using System.Collections.Generic;
using System.Text;

namespace Evergine.LibraryLoader.Loaders
{
    public class WindowsLoader : NativeLoader
    {
        public override IntPtr NativeLoad(string libraryName)
        {
            return Kernel32.LoadLibrary(libraryName);
        }

        public override void NativeFree(IntPtr libraryHandle)
        {
            Kernel32.FreeLibrary(libraryHandle);
        }
    }
}
