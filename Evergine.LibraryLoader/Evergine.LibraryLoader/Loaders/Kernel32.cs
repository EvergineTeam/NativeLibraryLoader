// Copyright © Plain Concepts S.L.U. All rights reserved. Use is subject to license terms.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Evergine.LibraryLoader.Loaders
{
    internal static class Kernel32
    {
        [DllImport("kernel32")]
        public static extern IntPtr LoadLibrary(string fileName);

        [DllImport("kernel32")]
        public static extern int FreeLibrary(IntPtr module);
    }
}
