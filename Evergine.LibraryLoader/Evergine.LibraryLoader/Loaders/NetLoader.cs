// Copyright © Plain Concepts S.L.U. All rights reserved. Use is subject to license terms.

using System;
using System.Collections.Generic;
using System.Text;

namespace Evergine.LibraryLoader.Loaders
{
    /// <summary>
    /// This class represent a NET native library, works on NetCore or higher.
    /// </summary>
    public class NetLoader : NativeLoader
    {
        /// <inheritdoc/>
        public override IntPtr NativeLoad(string libraryName)
        {
#if NET5_0_OR_GREATER
            return System.Runtime.InteropServices.NativeLibrary.Load(libraryName);

#else
            throw new InvalidOperationException();
#endif
        }

        /// <inheritdoc/>
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
