// Copyright © Plain Concepts S.L.U. All rights reserved. Use is subject to license terms.

namespace Evergine.LibraryLoader
{
    public interface IConfig
    {
        string Windows_x86 { get; }

        string Windows_x64 { get; }

        string Windows_ARM { get; }

        string Windows_ARM64 { get; }

        string IOS_ARM64 { get; }

        string Linux_x64 { get; }

        string Linux_x86 { get; }

        string Linux_ARM { get; }

        string Linux_ARM64 { get; }

        string OSX_ARM64 { get; }
    }
}
