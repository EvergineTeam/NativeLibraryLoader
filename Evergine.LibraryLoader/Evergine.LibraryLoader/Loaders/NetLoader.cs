// Copyright © Plain Concepts S.L.U. All rights reserved. Use is subject to license terms.

using System;
using System.Collections.Generic;
using System.Text;

namespace Evergine.LibraryLoader.Loaders
{
    public class NetLoader : NativeLoader
    {
        public override IntPtr NativeLoad(string libraryName)
        {
#if NET5_0_OR_GREATER
            return System.Runtime.InteropServices.NativeLibrary.Load(libraryName);

#else
            throw new InvalidOperationException();
#endif
        }

        public override void NativeFree(IntPtr libraryHandle)
        {
#if NET5_0_OR_GREATER
            System.Runtime.InteropServices.NativeLibrary.Free(libraryHandle);
#else
            throw new InvalidOperationException();
#endif
        }
    }
}
