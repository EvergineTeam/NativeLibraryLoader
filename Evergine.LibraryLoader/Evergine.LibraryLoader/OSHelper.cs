// Copyright © Plain Concepts S.L.U. All rights reserved. Use is subject to license terms.

#if NET5_0_OR_GREATER
using System;
#endif
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
#if !NET5_0_OR_GREATER
using System.Runtime.InteropServices;
#endif

namespace Evergine.LibraryLoader
{
    /// <summary>
    /// Helper class to determine executing OS platform.
    /// </summary>
    public static class OSHelper
    {
        /// <summary>
        /// Checks current executing platform.
        /// </summary>
        /// <param name="platform">Platform to check.</param>
        /// <returns>True if platform check succees; false otherwise.</returns>
        public static bool IsOSPlatform(Platform platform)
        {
#if NET5_0_OR_GREATER
            switch (platform)
            {
                case Platform.Windows:
                    return OperatingSystem.IsWindows();
                case Platform.Linux:
                    return OperatingSystem.IsLinux();
                case Platform.Android:
                    return OperatingSystem.IsAndroid();
                case Platform.MacOS:
                    return OperatingSystem.IsMacOS();
                case Platform.iOS:
                    return OperatingSystem.IsIOS();
                case Platform.Web:
                    return OperatingSystem.IsBrowser();
                default:
                    return false;
            }
#else
            OSPlatform osPlatform;
            switch (platform)
            {
                case Platform.Windows:
                    osPlatform = OSPlatform.Windows;
                    break;
                case Platform.Linux:
                case Platform.Android:
                    osPlatform = OSPlatform.Linux;
                    break;
                case Platform.MacOS:
                case Platform.iOS:
                    osPlatform = OSPlatform.OSX;
                    break;
            }

            bool matching = RuntimeInformation.IsOSPlatform(osPlatform);
            if (matching && platform == Platform.Android)
            {
                matching = RuntimeInformation.OSDescription.Contains("Unix");
            }
            else if (matching && platform == Platform.iOS)
            {
                matching = RuntimeInformation.OSDescription.Contains("Darwin");
            }
            else if (platform == Platform.Web)
            {
                matching = RuntimeInformation.OSDescription == "Browser";
            }

            return matching;
#endif
        }

        /// <summary>
        /// Checks current executing platform is one of specified platforms.
        /// </summary>
        /// <param name="platforms">Lookup platforms.</param>
        /// <returns>True if any of the provided platforms matches; false otherwise.</returns>
        public static bool IsAnyOfOSPlatforms(IEnumerable<Platform> platforms)
            => platforms.Any(IsOSPlatform);

        /// <summary>
        /// Gets current executing platform.
        /// </summary>
        /// <returns>Executing platform if found. Returns <see cref="Platform.Undefined"/> if platform could not be determined.</returns>
        public static Platform GetPlatform()
        {
            if (IsOSPlatform(Platform.Windows))
            {
                return Platform.Windows;
            }
            else if (IsOSPlatform(Platform.Android))
            {
                return Platform.Android;
            }
            else if (IsOSPlatform(Platform.Linux))
            {
                return Platform.Linux;
            }
            else if (IsOSPlatform(Platform.iOS))
            {
                return Platform.iOS;
            }
            else if (IsOSPlatform(Platform.MacOS))
            {
                return Platform.MacOS;
            }
            else if (IsOSPlatform(Platform.Web))
            {
                return Platform.Web;
            }

            return Platform.Undefined;
        }

        public static Architecture GetArchitecture()
        {
            var ar = RuntimeInformation.ProcessArchitecture;
            switch (ar)
            {
                case System.Runtime.InteropServices.Architecture.Arm:
                    return Architecture.ARM32;
                case System.Runtime.InteropServices.Architecture.Arm64:
                    return Architecture.ARM64;
                case System.Runtime.InteropServices.Architecture.X64:
                    return Architecture.X64;
                case System.Runtime.InteropServices.Architecture.X86:
                    return Architecture.X86;
                default:
                    return Architecture.Undefined;
            }
        }

        /// <summary>
        /// Get the enum platform type as string.
        /// </summary>
        /// <param name="value">The platform type to convert.</param>
        /// <returns>The name of the selected platform.</returns>
        public static string GetPlatformName(Platform value)
        {
            switch (value)
            {
                case Platform.Windows:
                    return "windows";
                case Platform.Android:
                    return "android";
                case Platform.iOS:
                    return "ios";
                case Platform.Linux:
                    return "linux";
                case Platform.MacOS:
                    return "osx";
                case Platform.UWP:
                    return "uwp";
                case Platform.Web:
                    return "web";
                case Platform.Undefined:
                default:
                    return string.Empty;
            }
        }
    }
}
