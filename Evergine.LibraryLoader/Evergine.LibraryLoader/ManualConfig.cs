// Copyright © Plain Concepts S.L.U. All rights reserved. Use is subject to license terms.

namespace Evergine.LibraryLoader
{
    public class ManualConfig : IConfig
    {
        public string Windows_x86 { get; private set; }

        public string Windows_x64 { get; private set; }

        public string Windows_ARM { get; private set; }

        public string Windows_ARM64 { get; private set; }

        public string IOS_ARM64 { get; private set; }

        public string Linux_x64 { get; private set; }

        public string Linux_x86 { get; private set; }

        public string Linux_ARM { get; private set; }

        public string Linux_ARM64 { get; private set; }

        public string OSX_ARM64 { get; private set; }

        private ManualConfig()
        { 
        }

        public static ManualConfig Create()
        {
            return new ManualConfig();
        }

        public ManualConfig SetWindows_x86(string path)
        {
            this.Windows_x86 = path;
            return this;
        }

        public ManualConfig SetWindows_x64(string path)
        {
            this.Windows_x64 = path;
            return this;
        }

        public ManualConfig SetWindows_ARM(string path)
        {
            this.Windows_ARM = path;
            return this;
        }

        public ManualConfig SetWindows_ARM64(string path)
        {
            this.Windows_ARM64 = path;
            return this;
        }

        public ManualConfig SetIOS_ARM64(string path)
        {
            this.IOS_ARM64 = path;
            return this;
        }

        public ManualConfig SetLinux_x64(string path)
        {
            this.Linux_x64 = path;
            return this;
        }

        public ManualConfig SetLinux_x86(string path)
        {
            this.Linux_x86 = path;
            return this;
        }

        public ManualConfig SetLinux_ARM(string path)
        {
            this.Linux_ARM = path;
            return this;
        }

        public ManualConfig SetLinux_ARM64(string path)
        {
            this.Linux_ARM64 = path;
            return this;
        }

        public ManualConfig SetOSX_ARM64(string path)
        {
            this.OSX_ARM64 = path;
            return this;
        }
    }
}
