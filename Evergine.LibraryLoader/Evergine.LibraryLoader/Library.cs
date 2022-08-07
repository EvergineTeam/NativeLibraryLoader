// Copyright © Plain Concepts S.L.U. All rights reserved. Use is subject to license terms.

using System;

namespace Evergine.LibraryLoader
{
    public class Library
    {
        public string LibName { get; private set; }
        public string WinLibName { get; private set; }
        public string AndroidLibName { get; private set; }
        public string IOSLibName { get; private set; }
        
        public string OSXLibName { get; private set; }

        public string LinuxLibName { get; private set; }
        public string UWPLibName { get; private set; }
        public string WebLibName { get; private set; }

        public IConfig Config { get; private set; }
        public IntPtr Handle { get; internal set; }

        public static Library Create(string libName)
        {
            return new Library(libName);
        }

        private Library(string libName)
        {
            this.LibName = libName;
        }

        public Library AddConfig(IConfig config)
        {
            this.Config = config;
            return this;
        }

        public Library SetPlatform(Platform platform, string libName)
        {
            switch (platform)
            {
                case Platform.Windows:
                    this.WinLibName = libName;
                    break;
                case Platform.Android:
                    this.AndroidLibName = libName;
                    break;
                case Platform.iOS:
                    this.IOSLibName = libName;
                    break;
                case Platform.Linux:
                    this.LinuxLibName = libName;
                    break;
                case Platform.MacOS:
                    this.OSXLibName = libName;
                    break;
                case Platform.UWP:
                    this.UWPLibName = libName;
                    break;
                case Platform.Web:
                    this.WebLibName = libName;
                    break;
            }

            return this;
        }
    }
}
