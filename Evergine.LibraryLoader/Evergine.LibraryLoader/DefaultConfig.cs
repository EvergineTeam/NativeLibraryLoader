// Copyright © Plain Concepts S.L.U. All rights reserved. Use is subject to license terms.

namespace Evergine.LibraryLoader
{
    public class DefaultConfig : IConfig
    {
        public static readonly IConfig Instance = new DefaultConfig();
        
        public string Windows_x86 => "runtimes/win-x86/native";

        public string Windows_x64 => "runtimes/win-x64/native";

        public string Windows_ARM => "runtimes/win-arm/native";

        public string Windows_ARM64 => "runtimes/win-arm64/native";

        public string IOS_ARM64 => "runtimes/ios-arm64/native";

        public string Linux_x64 => "runtimes/linux-x64/native";

        public string Linux_x86 => "runtimes/linux-x86/native";

        public string Linux_ARM => "runtimes/linux-arm/native";

        public string Linux_ARM64 => "runtimes/linux-arm64/native";

        public string OSX_ARM64 => "runtimes/osx-arm64/native";

        private DefaultConfig()
        { 
        }
    }
}
