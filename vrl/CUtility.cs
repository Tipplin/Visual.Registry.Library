using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// MS.Internal.CriticalExceptions
using MS.Internal.WindowsBase;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Media;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.Win32;

// our famous Resource Assembly - pure Resources -
using VisualD.Resource.Library.Properties;

// This is not a Assembly or Directive,
// is namespace in this Project-Solution
// Visual C# File: CUnsafeNativeMethods.cs
using NativeMethods;



//###################################################################################################
//
// At Visual Studio 2017 V 15.6.4 with Programming-Language Visual C# 7.2 in use !.
// Visual C# 7.3 with Visual Studio 2017 V 15.7.0
// Visual C# 8.0 in develop.
// Windows 10 Build 17130.0 - 'Spring Creators Update' in dependency with .NET Framework 4.7.2 (new)
// Change Platform to .NET Framework 4.7.2 !!!
//###################################################################################################

//***************************************************************************************************
// namespace Visual.Registry.Library for CUtilities, Windows Operation System, Critical Exceptions...
//***************************************************************************************************
namespace Visual.Registry.Library
{

    // Windows Operation System Versions
    internal class WindowsOperationSystemVersion
    {
        private OperatingSystem OSVersion = Environment.OSVersion;

        // __osversion as readonly
        internal static readonly Version _osVersion = Environment.OSVersion.Version;

        
        // Windows 7 Version 6.1 as property { get; }
        internal static bool IsOSWindows7OrNewer => _osVersion >= new Version(6, 1);

        internal static bool IsOSWindows8OrNewer => _osVersion >= new Version(6, 2);

        internal static bool IsOSWindows81rNewer => _osVersion >= new Version(6, 3);

        internal static bool IsOSWindows10OrNewer => _osVersion >= new Version(6, 4);


        // MS.Internal.WindowsBase.Interop.OperatingSystemVersion
        internal enum OperatingSystemVersion
        {
            WindowsXPSP2,       // support over
            WindowsXPSP3,       // support over
            WindowsVista,       // support over - this three Vista Version have lot of internal errors
            WindowsVistaSP1,    // support over - technical incorrections
            WindowsVistaSP2,    // support over - We write NOT for Vista !!!.
            Windows7,           //
            Windows7SP1,        //
            Windows8,           // Windows 8.0
            Windows8Point1,     // Windows 8.1
            Windows10,          // Threshold 1
            Windows10TH2,       // Threshold 2
            Windows10RS1,       // Redstone 1 - Anniversary Update
            Windows10RS2,       // Redstone 2 - Creators Update
            Windows10RS3,       // Redstone 3 - Fall Creators Update
            Windows10RS4,       // Redstone 4 - Spring Creators Update V 1803 - 06.04.2018 - Operation System Build 17133.1
                                //----------------------------------------------------------------- 11.04.2018 - Operation System Build 17133.73
                                //----------------------------------------------------------------- culumative update Revision 73
                                //----------------------------------------------------------------- After Bugs - Blocking Bug, 
                                //----------------------------------------------------------------- Microsoft STOPPED for all others the Final Release! not for TIPPO!
                                //----------------------------------------------------------------- new OS-Build 17134.5 Revision 5 - 26.04.2018
                                //
            Windows10RS5,       // Redstone 5 - Autumn Creators Update V 1809
                                //
                                // Next Year 2019 break with Redstone, new HY
            Windows10HY1,       // Break with Redstone next Year 2019, new codename Hash Year - HY1 19HJ1 - 2019 First Update
            Windows10HY2        // Break with Redstone next Year 2019, new codename Hash Year - HY2 19HJ2 - 2019 Second Update

        }



        /// <summary>
        /// Is Windows 7 ?
        /// </summary>
        /// <returns></returns>
        internal static bool VRLIsOSWindows7()
        {
            if (!IsOSWindows7OrNewer)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Is Operation System or Greather Queries
        /// </summary>
        /// <param name="osVer"></param>
        /// <returns></returns>
        internal static bool VRLIsOsVersionOrGreater(OperatingSystemVersion osVer)
        {
            switch (osVer)
            {

                //case OperatingSystemVersion.Windows10HY2:
                //    return SafeNativeMethods.Windows10HY2();
                //case OperatingSystemVersion.Windows10HY1:
                //    return SafeNativeMethods.Windows10HY1();
                case OperatingSystemVersion.Windows10RS5:
                    return SafeNativeMethods.IsWindows10RS5OrGreater();
                case OperatingSystemVersion.Windows10RS4:
                    return SafeNativeMethods.IsWindows10RS4OrGreater();
                case OperatingSystemVersion.Windows10RS3:
                    return SafeNativeMethods.IsWindows10RS3OrGreater();
                case OperatingSystemVersion.Windows10RS2:
                    return SafeNativeMethods.IsWindows10RS2OrGreater();
                case OperatingSystemVersion.Windows10RS1:
                    return SafeNativeMethods.IsWindows10RS1OrGreater();
                case OperatingSystemVersion.Windows10TH2:
                    return SafeNativeMethods.IsWindows10TH2OrGreater();
                case OperatingSystemVersion.Windows10:
                    return SafeNativeMethods.IsWindows10OrGreater();
                case OperatingSystemVersion.Windows8Point1:
                    return SafeNativeMethods.IsWindows8Point1OrGreater();
                case OperatingSystemVersion.Windows8:
                    return SafeNativeMethods.IsWindows8OrGreater();
                case OperatingSystemVersion.Windows7SP1:
                    return SafeNativeMethods.IsWindows7SP1OrGreater();
                case OperatingSystemVersion.Windows7:
                    return SafeNativeMethods.IsWindows7OrGreater();
                case OperatingSystemVersion.WindowsXPSP3:
                    return SafeNativeMethods.IsWindowsXPSP3OrGreater();
                case OperatingSystemVersion.WindowsXPSP2:
                    return SafeNativeMethods.IsWindowsXPSP2OrGreater();
                default:
                    throw new ArgumentException($"{osVer.ToString()} is not a valid OS!", "osVer");
            }

            /*
                IsWin7orLater = (oSVersion.Version >= new Version(6, 1));
                IsWin7Sp1orLater = (oSVersion.Version >= new Version(6, 1, 7601));
                IsWin8orLater = (oSVersion.Version >= new Version(6, 2));
                IsWin81orLater = (oSVersion.Version >= new Version(6, 3));
                // Windows Operation System 10:
                // First is Major-version, Second is Minor-version, Third is Buildnumber, Fourth is Revisionnumber
                // NOTE ! Microsoft increment the Revisionnumber in Time, Corrections, Bugfixes...
                IsWin10with15063 = (oSVersion.Version >= new Version(6, 2, 15063, 0));
                // Fall creators Update
                IsWin10with16299 = (oSVersion.Version >= new Version(6, 2, 16299, 334));
                // Spring Creators Update
                IsWin10with17130 = (oSVersion.Version >= new Version(6, 2, 17130, 0));
            */





        }

        /// <summary>
        /// Get Operation System Version
        /// </summary>
        /// <returns></returns>
        public static string GetOSVersion()
        {
            string osVersion = string.Empty;
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", "/c ver");
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.UseShellExecute = false;
                processStartInfo.CreateNoWindow = true;
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                ProcessStartInfo getOsVersionProcess = processStartInfo;
                osVersion = Process.Start(getOsVersionProcess).StandardOutput.ReadToEnd();
                
            }
            catch (Exception ex)
            {
                SafeNativeMethods.VFLMsgBox("EXCEPTION NOW: " + ex.GetType().Name + " - " + ex.Message, "GetOSVersion - Exception is occured !!!", UnsafeConstants.Style1);
                   
            }
            return VRLFormatOSVersionString(osVersion);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="osVersion"></param>
        /// <returns></returns>
        internal static string VRLFormatOSVersionString(string osVersion)
        {
            string formattedOSVersion = osVersion.Trim();
            string osVersionRegexPattern = "^Microsoft Windows \\[Version ([0-9\\.]+)\\]$";
            Regex regex = new Regex(osVersionRegexPattern);
            Match regexMatch = regex.Match(formattedOSVersion);
            if (regexMatch.Success)
            {
                formattedOSVersion = regexMatch.Groups[1].Value;
            }
            return formattedOSVersion;
        }






    } // End of Class WindowsOperationSystemVersion

    // [FriendAccessAllowed]
    //
    //
    // [InternalsVisibleAttribute("Assemblyname.dll")]
    // Make internal Class and Methods.. visible in the given Assembly,
    // internals are after compile 'HIDDEN' in Viewer !!!.
    // Can bind in, no class and Methods are see!

    /// <summary>
    /// 
    /// </summary>
    internal static class CriticalExceptions
    {

         internal static bool IsCriticalException(Exception ex)
         {
                ex = Unwrap(ex);

                // new written Microsoft Code Convention, for better Tuning and Performance
                // and operator && is better, as operator &
                if (!(ex is NullReferenceException) && !(ex is StackOverflowException) && !(ex is OutOfMemoryException) && !(ex is ThreadAbortException) && !(ex is SEHException))
                {
                    return ex is SecurityException;
                }
                return true;
         }

            internal static bool IsCriticalApplicationException(Exception ex)
            {
                ex = Unwrap(ex);
                if (!(ex is StackOverflowException) && !(ex is OutOfMemoryException) && !(ex is ThreadAbortException))
                {
                    return ex is SecurityException;
                }
                return true;
            }


            internal static Exception Unwrap(Exception ex)
            {
                while (ex.InnerException != null && ex is TargetInvocationException)
                {
                    ex = ex.InnerException;
                }
                return ex;
            }
        
            // MS.Internal.Interop.Facility
            internal enum Facility
            {
                    Null,
                    Rpc,
                    Dispatch,
                    Storage,
                    Itf,
                    Win32 = 7,
                    Windows,
                    Control = 10,
                    Ese = 3678
            }

        [StructLayout(LayoutKind.Explicit)]
        internal struct HRESULT
        {
            [FieldOffset(0)]
            internal readonly uint _value;

            public static readonly HRESULT S_OK = new HRESULT(0u);

            public static readonly HRESULT S_FALSE = new HRESULT(1u);

            public static readonly HRESULT E_NOTIMPL = new HRESULT(2147500033u);

            public static readonly HRESULT E_NOINTERFACE = new HRESULT(2147500034u);

            public static readonly HRESULT E_POINTER = new HRESULT(2147500035u);

            public static readonly HRESULT E_ABORT = new HRESULT(2147500036u);

            public static readonly HRESULT E_FAIL = new HRESULT(2147500037u);

            public static readonly HRESULT E_UNEXPECTED = new HRESULT(2147549183u);

            public static readonly HRESULT DISP_E_MEMBERNOTFOUND = new HRESULT(2147614723u);

            public static readonly HRESULT DISP_E_TYPEMISMATCH = new HRESULT(2147614725u);

            public static readonly HRESULT DISP_E_UNKNOWNNAME = new HRESULT(2147614726u);

            public static readonly HRESULT DISP_E_EXCEPTION = new HRESULT(2147614729u);

            public static readonly HRESULT DISP_E_OVERFLOW = new HRESULT(2147614730u);

            public static readonly HRESULT DISP_E_BADINDEX = new HRESULT(2147614731u);

            public static readonly HRESULT DISP_E_BADPARAMCOUNT = new HRESULT(2147614734u);

            public static readonly HRESULT DISP_E_PARAMNOTOPTIONAL = new HRESULT(2147614735u);

            public static readonly HRESULT SCRIPT_E_REPORTED = new HRESULT(2147614977u);

            public static readonly HRESULT STG_E_INVALIDFUNCTION = new HRESULT(2147680257u);

            public static readonly HRESULT DESTS_E_NO_MATCHING_ASSOC_HANDLER = new HRESULT(2147749635u);

            public static readonly HRESULT E_ACCESSDENIED = new HRESULT(2147942405u);

            public static readonly HRESULT E_OUTOFMEMORY = new HRESULT(2147942414u);

            public static readonly HRESULT E_INVALIDARG = new HRESULT(2147942487u);

            public static readonly HRESULT COR_E_OBJECTDISPOSED = new HRESULT(2148734498u);

            public static readonly HRESULT WC_E_GREATERTHAN = new HRESULT(3222072867u);

            public static readonly HRESULT WC_E_SYNTAX = new HRESULT(3222072877u);


            public Facility Facility => GetFacility((int)_value);

            public int Code => GetCode((int)_value);

            public bool Succeeded => (int)_value >= 0;

            public bool Failed => (int)_value < 0;


            public HRESULT(uint i)
            {
                _value = i;
            }

            /// <summary>
            /// Make your HRESULT for your Project.
            /// </summary>
            /// <param name="severe"></param>
            /// <param name="facility"></param>
            /// <param name="code"></param>
            /// <remarks>
            /// !!! MAKE SURE THAT YOU MAKE HRESULT's, OVER MICROSOFT RESERVED !!!
            /// HRESULT are Hexadecimal values - decimal with prefix minus sign -2147483648
            /// </remarks>
            /// <returns>
            /// 
            /// </returns>
            public static HRESULT MakeHRESULT(bool severe, Facility facility, int code)
            {
                return new HRESULT((uint)((severe ? (-2147483648) : 0) | (int)facility << 16 | code));
            }

            /// <summary>
            /// Get the Facility for Error Code
            /// </summary>
            /// <param name="errorCode"></param>
            /// <returns></returns>
            public static Facility GetFacility(int errorCode)
            {
                return (Facility)(errorCode >> 16 & 0x1FFF);
            }

            /// <summary>
            /// Get Code
            /// </summary>
            /// <param name="error"></param>
            /// <returns></returns>
            public static int GetCode(int error)
            {
                return error & 0xFFFF;
            }

        } // End of Struct HRESULT

    } // End of Class CriticalExceptions


    internal static class InstalledFramework
    {
        internal static FrameworkVersion? installedFramework4Version;

        // SystemInformationHelpers.FrameworkVersion

        /// <summary>
        /// Enumerator for all .NET Frameworks
        /// </summary>
        public enum FrameworkVersion
        {
            Unknown,
            v4_0,
            v4_5,
            v4_5_1,
            v4_5_2,
            v4_6,
            v4_6_1,
            v4_6_2,
            v4_7,
            v4_7_1, // Windows 10 Fall Creators Update     - V1709
            v4_7_2  // Windows 10 Spring Creators Update   - V1803/1804
        }


        /// <summary>
        /// Constructor
        /// </summary>
        static InstalledFramework()
        {
            installedFramework4Version = null;
        }

        /// <summary>
        /// Get the installed Framework Version
        /// </summary>
        /// <returns></returns>
        public static FrameworkVersion GetInstalledFramework4Version()
        {
            if (!installedFramework4Version.HasValue)
            {
                try
                {
                    RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\");
                    using (ndpKey)
                    {
                        object releaseKeyAsObject = ndpKey.GetValue("Release");
                        if (releaseKeyAsObject == null)
                        {
                            installedFramework4Version = FrameworkVersion.v4_0;
                        }
                        int releaseKey = Convert.ToInt32(releaseKeyAsObject);
                        if (releaseKey >= 03056)
                        {
                            installedFramework4Version = FrameworkVersion.v4_7_2;
                            goto end_IL_002c;
                        }
                        if (releaseKey >= 461308)
                        {
                            installedFramework4Version = FrameworkVersion.v4_7_1;

                            // ! NEW ! both by Visual C++ and Visual C# goto mark is IN !!!
                            // Microsoft Developer used in Windows Operation System, Studio...
                            // for CleanUp's - to clear away's !!!.
                            goto end_IL_002c;
                        }
                        if (releaseKey >= 460798)
                        {
                            installedFramework4Version = FrameworkVersion.v4_7;
                            goto end_IL_002c;
                        }
                        if (releaseKey >= 394802)
                        {
                            installedFramework4Version = FrameworkVersion.v4_6_2;
                            goto end_IL_002c;
                        }
                        if (releaseKey >= 394254)
                        {
                            installedFramework4Version = FrameworkVersion.v4_6_1;
                            goto end_IL_002c;
                        }
                        if (releaseKey >= 393295)
                        {
                            installedFramework4Version = FrameworkVersion.v4_6;
                            goto end_IL_002c;
                        }
                        if (releaseKey >= 379893)
                        {
                            installedFramework4Version = FrameworkVersion.v4_5_2;
                            goto end_IL_002c;
                        }
                        if (releaseKey >= 378675)
                        {
                            installedFramework4Version = FrameworkVersion.v4_5_1;
                            goto end_IL_002c;
                        }
                        if (releaseKey >= 378389)
                        {
                            installedFramework4Version = FrameworkVersion.v4_5;
                            goto end_IL_002c;
                        }
                        throw new Exception("Invalid value of Release key.");
                        // goto mark
                        end_IL_002c:;
                    }
                }
                catch (Exception ex)
                {
                    if (!(ex is SecurityException) && !(ex is UnauthorizedAccessException) && !(ex is NullReferenceException))
                    {
                        NativeMethods.SafeNativeMethods.VFLMsgBox(ex.Message, "Visual Registry Library - Exception is occured !", UnsafeConstants.Style1);
                    }
                    installedFramework4Version = GetFrameworkVersionByFileVersion(GetCLRDefault32MscorlibPath());
                }
            }
            return installedFramework4Version.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetCLRDefault32MscorlibPath()
        {
            string windowsPath = Environment.GetEnvironmentVariable("windir") ?? Environment.GetEnvironmentVariable("SystemRoot");
            string clr32Path = Path.Combine(windowsPath, "Microsoft.NET\\Framework");
            return Path.Combine(clr32Path, "v4.0.30319\\mscorlib.dll");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assemblyFilePath"></param>
        /// <returns></returns>
        public static FrameworkVersion GetFrameworkVersionByFileVersion(string assemblyFilePath)
        {
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assemblyFilePath);
            if (versionInfo.FileMajorPart == 4)
            {

                if (versionInfo.FileMinorPart == 7)
                {
                    if (versionInfo.FileBuildPart >= 3052)
                    {
                        return FrameworkVersion.v4_7_2;
                    }
                    return FrameworkVersion.v4_7;
                }
                if (versionInfo.FileMinorPart == 7)
                {
                    if (versionInfo.FileBuildPart >= 2558)
                    {
                        return FrameworkVersion.v4_7_1;
                    }
                    return FrameworkVersion.v4_7;
                }
                if (versionInfo.FileMinorPart == 6)
                {
                    if (versionInfo.FileBuildPart >= 1590)
                    {
                        return FrameworkVersion.v4_6_2;
                    }
                    if (versionInfo.FileBuildPart >= 127)
                    {
                        return FrameworkVersion.v4_6_1;
                    }
                    return FrameworkVersion.v4_6;
                }
                if (versionInfo.FileMinorPart == 0 && versionInfo.FileBuildPart == 30319)
                {
                    if (versionInfo.FilePrivatePart >= 34209)
                    {
                        return FrameworkVersion.v4_5_2;
                    }
                    if (versionInfo.FilePrivatePart >= 18402)
                    {
                        return FrameworkVersion.v4_5_1;
                    }
                    if (versionInfo.FilePrivatePart > 15000)
                    {
                        return FrameworkVersion.v4_5;
                    }
                    return FrameworkVersion.v4_0;
                }
            }
            return FrameworkVersion.Unknown;
        }










    }
} // End of namespace
