// Copyright © Plain Concepts S.L.U. All rights reserved. Use is subject to license terms.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Evergine.LibraryLoader.Loaders
{
    internal static class Libdl
    {
        [DllImport("libdl")]
        public static extern IntPtr dlopen(string fileName, int flags);

        [DllImport("libdl")]
        public static extern int dlclose(IntPtr handle);

        [DllImport("libdl")]
        public static extern string dlerror();

        public const int RTLD_NOW = 0x002;
    }
}
