//#############################################################################
//
// Project		:	Visual.Galaxy.Framework
//
//-----------------------------------------------------------------------------
// Programmer	:	Christian "TIPPO" Kurs
//-----------------------------------------------------------------------------
// Part         :	Visual.Registry.Library
//-----------------------------------------------------------------------------
// Base Class	:	CUtility
//-----------------------------------------------------------------------------
// Assist       :   Automatic Versions Setting
//              :   Major, Minor, Build, Revision
//              :   increment always at build run - compile -
//              :   but in Project only build and revision
//              :   set build option, so he show the complete Build-Run
//              :   Build-Run Log in Project-Directory: Projectname.log
//-----------------------------------------------------------------------------
// Specials     :   Change Platform to .NET Framework 4.8 !.
//              :   ! ATTENTION ! at current Project-Solutions all Version,
//              :   Minor Version, Build and Revision an automatic tool set this
//              :   Automatic Version Settings, increment all by compile.
//              :   ! HAND OFF ! Assembly Information settings.
//              :   click Build order at Build run, while then he write all in
//              :   Logfile .tlog
//              :   This Project-Solution and others have Project Websites
//              :   inside der Project written projectname.hmtl the Compiler
//              :   compile the site, is exception or not.
//------------------------------------------------------------------------------
// Copyright © 2019, by Visual Galaxy Framework Community Kernel Developer Team
//
// by Head-Author: Christian "TIPPO" Kurs - Visual C# Senior Developer
// Portions Copyright © 2019 by Microsoft Corporation GmbH.
//
// Same sourcecode by Microsoft, so we marked with Copyright !.
// © 1982 - 2019 - Copyrights by Microsoft: Images, Icons, Signs, Gadgets, 
// Copyright © and Tradewark by Microsoft Windows, Windows Logo, Visual Studio
//------------------------------------------------------------------------------
// Get Permission from Microsoft to use Icons, Signs, Images for this Project.
//-----------------------------------------------------------------------------
//
// written by 		Christian "TIPPO" Kurs
// 				    Nettweg 1
//					-G - 53498 Bad Breisig
//					Germany - Allemagne - Duitsland
//-----------------------------------------------------------------------------
// 				    voice				:	02633 - 470736  
//					international phone	:	00-49-2633-470736
//					Skype				:
//					e-mail				:	kurschristian@gmail.de
//					my Website Community:	http://www.vgfc.org/community/tippo
//					
//----------------------------------------------------------------------------
// This software is supplied as is. Use it at your own  RISK !!!!.
// Obviously I've tried to do the best job possible.
// If you find any problem with it, let me know.
//
// With any luck, Visual Galaxy Framework will make it obsolete anyway
//----------------------------------------------------------------------------
// License:	
//				NO fee for NON-Commercial use.
//				our Community Website: 
//				
//				http://www.vgfc.org/community/project/vgfc/
//
//				Honest Business Users, to use our compiled Versions, 
//				please call us to send you our Business Licenses.
//				or our Business Website:
//				
//				http://www.vgfc.org/business/vgfc/License
//
//----------------------------------------------------------------------------

//----------------------------------------------------------------------------
//-------------------------- Project History ---------------------------------
//----------------------------------------------------------------------------
// Release 0.0.0 - 2016/01/01 - TIPPO - KC - Project Founder - Initial
//----------------------------------------------------------------------------
// Commentary:
// [VGF.NET - 01]
//
//
//
//----------------------------------------------------------------------------
// Definition:
// [VGF.NET - 01]
//
//----------------------------------------------------------------------------
// Improvement:
// [VGF.NET - 01]
//
//----------------------------------------------------------------------------
// New Feature:
// [VGF.NET - 01]
//
//----------------------------------------------------------------------------
// Task:
// [VGF.NET - 01]
//
//----------------------------------------------------------------------------
// Class:
// [VGF.NET - 01]
//
//----------------------------------------------------------------------------
// Method:
// [VGF.NET - 01]
//
//----------------------------------------------------------------------------
// Property:
// [VGF.NET - 01]
//
//----------------------------------------------------------------------------

//----------------------------------------------------------------------------
// All .NET Framework Directives are begin with System
// same with 
// Microsoft Directives: 
// Microsoft.Win32 with Class SafeHandles
// Windows Directives: 
// Windows.System.winmd - winmd's are the same as Assemblies!
// The Windows Operation System give us this Windows Metadatas for use 
// in this System-Directory: C:\Windows\System32\WinMetadata
// On 64BIT System \System32 
// is the 64BIT System-Directory for all System-Components.
// Special on Windows 64 BIT is the Directory for 32 BIT Compoments in
// \WOW64 - Windows on Windows - for execute all 32 BIT App's.
// No execute 16BIT App's, make Message for that.
//----------------------------------------------------------------------------

/*---------------- For Developers --------------------------------------------
 * Here all System Directives, begins with System and 
 * for Windows Operation System begins with Windows.
 * 
 * 
 * 
 *--------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using System.Media;
using System.Diagnostics;
using System.Text.RegularExpressions;

/*-----------------------------------------------------------------------------
 * Microsoft Directives and Assemblies
 * Microsoft.Win32
 * MS.Internal.WindowsBase inside MS.Internal.CriticalExceptions
 * 
 *---------------------------------------------------------------------------*/

using Microsoft.Win32;
using MS.Internal.WindowsBase;

/*-----------------------------------------------------------------------------
 * VGF Our Directives/Assemblies and namespace from other .cs Files in this
 * Project.
 *-----------------------------------------------------------------------------
 * Visual.Resource.Library.dll:
 * VisualD.Resource.Library.Properties;
 * our famous Resource Assembly - pure Resources -
 *-----------------------------------------------------------------------------
 * Visual.Registry.Library.dll:
 * Visual.Registry.Library.Internal;
 * !NOTE! NOT an Assembly/Directive,
 * is other namespace in this Project-Solution and Visual C# File:
 * InternalCalls.cs
 *-----------------------------------------------------------------------------
 * Visual.Operation.System.dll: - Windows Operation System Functions -
 * Visual.Operation.System.Native.NativeMethods;
 * Visual.Operation.System.Native.UnsafeNativeMethods;
 * Visual.Operation.System.Native.NativeRuntimeMethods;
 * Visual.Operation.System.Internal.InternalUtilities.VOSInternalUtilities;
 * 
 *----------------------------------------------------------------------------- 
 * Microsoft Edge Start
 * cmd MicrosoftEdge - first variant - Start Bing
 * Process.Start("cmd MicrosoftEdge");
 * 
 *---------------------------------------------------------------------------*/

/*-----------------------------------------------------------------------------------
 * Visual Operation System Assembly for use:
 * all written in Visual C# and all Methods are static.
 *-----------------------------------------------------------------------------------
 */
using static Visual.Operation.System.Internal.InternalUtilities.VOSInternalUtilities;
using static Visual.Operation.System.Native.NativeMethods;
using static Visual.Operation.System.Native.NativeRuntimeMethods;
using static Visual.Operation.System.Native.UnsafeNativeMethods;
using static Visual.Operation.System.Internal.InternalOSMethods;







/* 
 * Many Resources for use like: Music, Sound, Signs, Images, Photo, Pictures...
 * 
 */
using VisualD.Resource.Library.Properties;




/*
* Registry Wrapper Methods in Visual C#
* Get registry Entry Info for System, Windows or others.
* 
*/

// Base Class for constants, variables, instancevariables...
using static Visual.Registry.Library.VRLBase;

using Visual.Registry.Library.Internal;

using static Visual.Registry.Library.VRLWindowsRegistry;






/*###################################################################################################
* At Visual Studio 2017 V 15.6.4 with Programming-Language Visual C# 7.2 in use !.
* Visual C# 7.3 with Visual Studio 2017 V 15.7.0
* Visual Studio 2017 and Visual C# 7.2
* ---------------------------------------------------------------------------------------------------
* Windows 10 Build 17130.48 - 'Spring Creators Update' in dependency with .NET Framework 4.7.2 (new)
* Change Platform to .NET Framework 4.7.2 !!!
* Windows 10 Build 17754.1 - 'October Update 2018' in dependency with .NET Framework 4.7.2
* ---------------------------------------------------------------------------------------------------
* Windows 10 Build 18362.0 - Release Preview - end of May - 
* Finally with Bugfixes, but increment only the Revisions.
* most like cumulative updates for Bugfixes and issue.
* at Time New Revision is .86 - OS-Build 18362.86 - 30.04.2019 -
* ---------------------------------------------------------------------------------------------------
* Change Platform to .NET Framework 4.8.03752
* Visual Studio 2019 and Visual C# 8.0 -
* 
* 
###################################################################################################*/


/*-----------------------------------------------------------------------------
 * namespace Visual.Registry.Library for CUtilities, Windows Operation System, 
 * Critical Exceptions...
 * 
 * 
 * 
 * 
 *----------------------------------------------------------------------------- 
*/
namespace Visual.Registry.Library
{

    // Windows Operation System Versions
    internal class VRLWindowsOperationSystemVersion
    {

        //
        internal OperatingSystem OSVersion = Environment.OSVersion;


        // __osversion as readonly
        internal static readonly Version _osVersion = Environment.OSVersion.Version;


        // Windows 7 Version 6.1 as property { get; }
        /// <summary>
        /// Is Windows 7
        /// </summary>
        internal static bool IsOSWindows7OrNewer => _osVersion >= new Version(6, 1);
        /// <summary>
        /// Is Windows 8
        /// </summary>
        internal static bool IsOSWindows8OrNewer => _osVersion >= new Version(6, 2);
        /// <summary>
        /// Is Windows 8.1
        /// </summary>
        internal static bool IsOSWindows81rNewer => _osVersion >= new Version(6, 3);
        /// <summary>
        /// Username as shortcut
        /// </summary>
        internal static string Uname => Environment.UserName;
        /// <summary>
        /// Machinename as shortcut
        /// </summary>
        internal static string Machine => Environment.MachineName;
        /// <summary>
        /// Is 64BIT Operation System
        /// </summary>
        internal static bool OS64 => Environment.Is64BitOperatingSystem;
        /// <summary>
        /// Is 64BIT Process
        /// </summary>
        internal static bool Process64 => Environment.Is64BitProcess;
        /// <summary>
        /// Get OS-Versionstring
        /// </summary>
        internal static string SVersion => Environment.OSVersion.VersionString;
        /// <summary>
        /// initialize message with null
        /// </summary>
        internal const string message = null;

        // MS.Internal.WindowsBase.Interop.OperatingSystemVersion

        /// <summary>
        /// 
        /// </summary>
        /// <!-- Author Tipplin 🧑 -->
        /// 
        /// <!-- Author Tipplin 🧑 -->
        /// <remarks>
        /// 
        /// </remarks>
        internal enum OperatingSystemVersion
        {
            WindowsXPSP2,       // support over
            WindowsXPSP3,       // support over
            WindowsVista,       // support over - this three Vista Version have lot of internal errors
            WindowsVistaSP1,    // support over - Technical Incorrections in System!.
            WindowsVistaSP2,    // support over - We write NOT for Vista !.
            Windows7,           // support over - <date>
            Windows7SP1,        // support over -
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
                                //----------------------------------------------------------------- 12.06.2018 - Operation System Build 17133.112
                                //----------------------------------------------------------------- culumative update Revision 112
                                //
                                //----------------------------------------------------------------- Microsoft STOPPED for all others the Final Release! not for TIPPO!
                                //----------------------------------------------------------------- OS-Build 17134.5 Revision 5 - 26.04.2018
                                //----------------------------------------------------------------- OS-Build 17134.191 Revision 191 - 27.07.2018
            Windows10RS5,       // Redstone 5 - October Update         V 1809 - 02.10.2018 - Operation System Build 17763.1
                                //
            Windows1019h1,      // Windows 10 (19H1) - May Update - actual OS-Build 18362.1 - 25.04.2018 for 2019.
                                // Official Final Version 18362.116
                                // actual Revision 68 - OS-Build 18362.145 -
            Windows1019h20,     // Revision 10000 by 19h2 - OS-Build 18362.10000 half second year -
            Windows1019h25,     // actual Revision 10005 - 19h2 - after cleanup's.
            Windows1020h1,      // Open Branch 2020 - actual OS-Build 18865 -
            Windows1020h2       //
        }



        /// <summary>
        /// Is Windows 7 ?
        /// </summary>
        /// <!-- Author Tipplin 🧑 -->
        /// same Function from Windows Operation System,
        /// C++ Headerfile SDK 18362 versionhelper.h, complete Functions inside.
        /// <!-- Author Tipplin 🧑 -->
        /// <remarks>
        /// here from
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
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
        /// Get Operation System Version
        /// </summary>
        /// <!-- Author Tipplin 🧑 -->
        /// 
        /// <!-- Author Tipplin 🧑 -->
        /// <returns>
        /// 
        /// </returns>
        public static string VRLGetOSVersion()
        {
            string osVersion = string.Empty;

            try
            {
                var processStartInfo = new ProcessStartInfo("cmd.exe", "/c ver");

                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.UseShellExecute = false;
                processStartInfo.CreateNoWindow = true;
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                ProcessStartInfo getOsVersionProcess = processStartInfo;

                osVersion = Process.Start(getOsVersionProcess).StandardOutput.ReadToEnd();
                
            }
            catch (Exception ex)
            {
                VFLMsgBox("EXCEPTION NOW: " + ex.GetType().Name + " - " + ex.Message, "GetOSVersion - Exception is occured !!!", STYLES.OkOnly | STYLES.Critical | STYLES.MsgBoxSetForeground | STYLES.SystemModal);
                   
            }
            return VRLFormatOSVersionString(osVersion);
        }

        /// <summary>
        /// Format OS-Version String
        /// </summary>
        /// <!-- Author Tipplin 🧑 -->
        /// 
        /// <!-- Author Tipplin 🧑 -->
        /// <param name="osVersion"></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        internal static string VRLFormatOSVersionString(string osVersion)
        {
            string formattedOSVersion = osVersion.Trim();
            string osVersionRegexPattern = "^Microsoft Windows \\[Version ([0-9\\.]+)\\]$";

            // Regex Regular Expressions - Microsoft Table for it all Regular Expressions as .pdf Tab
            // download over:
            // some in [Attributes] (all):
            // System.Attribute:
            // [EmailAtrribute] check url, [CreditCardAttribute] (Master, Visa (World Number One), American Card)
            //
            //
            // 
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
    internal static class VRLCriticalExceptions
    {
        // MS.Internal.Interop.Facility

        /// <summary>
        /// 
        /// </summary>
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








        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        internal static bool VRLIsCriticalException(Exception ex)
        {
                ex = VRLUnwrap(ex);

                // new written Microsoft Code Convention, for better Tuning and Performance
                // and operator && is better, as operator &
                if (!(ex is NullReferenceException) && !(ex is StackOverflowException) && !(ex is OutOfMemoryException) && !(ex is ThreadAbortException) && !(ex is SEHException))
                {
                    return ex is SecurityException;
                }
                return true;
         }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        internal static bool VRLIsCriticalApplicationException(Exception ex)
        {
                ex = VRLUnwrap(ex);
                if (!(ex is StackOverflowException) && !(ex is OutOfMemoryException) && !(ex is ThreadAbortException))
                {
                    return ex is SecurityException;
                }
                return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        internal static Exception VRLUnwrap(Exception ex)
        {
                while (ex.InnerException != null && ex is TargetInvocationException)
                {
                    ex = ex.InnerException;
                }
                return ex;
            }
        
            
            

    } // END::OF::Class::VRLCriticalExceptions


    /*-------------------------------------------------------------------------
     * 
     * 
     * 
     *------------------------------------------------------------------------- 
     */
    internal static class VRLInstalledFramework
    {

        //
        internal static FrameworkVersion? installedFramework4Version;



        // SystemInformationHelpers.FrameworkVersion

        /// <summary>
        /// Enumerator for all .NET Frameworks
        /// </summary>
        public enum FrameworkVersion
        {
            Unknown,
            v3_0,       // 3.0.4506.30 - 6. November 2006 
            v3_5,       // 3.5.21022.8 - 9. November 2007 
            v3_5_1,     // 3.5.30729.1 - 11. August 2008
            v4_0,       // 4.0.30319 - 12. April 2010 
            v4_5,       // 4.5.50501 - Release 378389 - 15. August 2012 
            v4_5_1,     // 4.5.50938 - Release 378758 / 379893 - 12. Oktober 2013 
            v4_5_2,     // 4.5.51090 - Release Windows 10 - 393295 - 05. Mai 2014 
            v4_6,       // 4.6.00081 - Release Windows 10 - 394254 - 10. Juli 2015 
            v4_6_1,     // - Release Windows 10 - 394806 - 17. November 2015 
            v4_6_2,     // - Release Windows 10 - 460798 - 20. Juli 2016 
            v4_7,       // - Release Windows 10 - 461308 - 11. April 2017
            v4_7_1,     // 13. Oktober 2017 - Windows 10 Fall Creators Update     - V1709
            v4_7_2,     // 4.7.3081.0 - Release 461808 - 10. Juli 2018  - Windows 10 Spring Creators Update   - V1803
            v4_8        // 4.8.3761.0 - 4.8.03752 - Release 528040 and 528049 for other OS Systems 18. April 2019 - Windows 10 May Update 2019
        }


        /// <summary>
        /// Constructor
        /// </summary>
        static VRLInstalledFramework()
        {
            installedFramework4Version = null;
        }




        // TIPPO_UNDONE - releasekey's failed, set here fake values

        /// <summary>
        /// Get the installed Framework Version
        /// </summary>
        /// <returns></returns>
        public static FrameworkVersion VRLGetInstalledFramework4Version()
        {
            if (!installedFramework4Version.HasValue)
            {
                try
                {
                    using (ndpKey)
                    {
                        object releaseKeyAsObject = ndpKey.GetValue("Release");

                        if (releaseKeyAsObject == null)
                        {
                            installedFramework4Version = FrameworkVersion.v4_0;
                        }
                        
                        int releaseKey = Convert.ToInt32(releaseKeyAsObject);
                        if (releaseKey >= 528040)
                        {
                            installedFramework4Version = FrameworkVersion.v4_8;
                            // Microsoft developer: goto is IN !
                            // make Clean Up's with label mark!
                            goto InstalledFX;
                        }
                        if (releaseKey >= 461808)
                        {
                            installedFramework4Version = FrameworkVersion.v4_7_2;
                            goto InstalledFX;
                        }
                        if (releaseKey >= 461308)
                        {
                            installedFramework4Version = FrameworkVersion.v4_7_1;

                            // ! NEW ! both by Visual C++ and Visual C# goto mark is IN !!!
                            // Microsoft Developer used in Windows Operation System, Studio...
                            // for CleanUp's - to clear away's !!!.
                            goto InstalledFX;
                        }
                        if (releaseKey >= 460798)
                        {
                            installedFramework4Version = FrameworkVersion.v4_7;
                            goto InstalledFX;
                        }
                        if (releaseKey >= 394802)
                        {
                            installedFramework4Version = FrameworkVersion.v4_6_2;
                            goto InstalledFX;
                        }
                        if (releaseKey >= 394254)
                        {
                            installedFramework4Version = FrameworkVersion.v4_6_1;
                            goto InstalledFX;
                        }
                        if (releaseKey >= 393295)
                        {
                            installedFramework4Version = FrameworkVersion.v4_6;
                            goto InstalledFX;
                        }
                        if (releaseKey >= 379893)
                        {
                            installedFramework4Version = FrameworkVersion.v4_5_2;
                            goto InstalledFX;
                        }
                        if (releaseKey >= 378675)
                        {
                            installedFramework4Version = FrameworkVersion.v4_5_1;
                            goto InstalledFX;
                        }
                        if (releaseKey >= 378389)
                        {
                            installedFramework4Version = FrameworkVersion.v4_5;
                            goto InstalledFX;
                        }
                  
                        // goto label mark
                        InstalledFX:
                        VFLMsgBox("Installed Framework on this Computer is : {0}" + releaseKey, "Installed Framework View", STYLES.OkOnly | STYLES.Exclamation | STYLES.MsgBoxSetForeground | STYLES.SystemModal);

                    }
                }
                catch (Exception ex)
                {
                    if (!(ex is SecurityException) && !(ex is UnauthorizedAccessException) && !(ex is NullReferenceException))
                    {
                        VFLMsgBox(ex.Message, "Visual Registry Library - Exception is occured !", STYLES.OkOnly | STYLES.Critical | STYLES.MsgBoxSetForeground |STYLES.SystemModal);
                    }

                    installedFramework4Version = VRLGetFrameworkVersionByFileVersion(VRLGetCLRDefault32CorlibPath());
                }
            }
            return installedFramework4Version.Value;
        }

        /// <summary>
        /// Get CLR default Corlib path
        /// </summary>
        /// <!-- Author Tipplin 🧑 -->
        /// use Class Enviroment with GetEnviromentVariable - Win Dir and SystemRoot
        /// <!-- Author Tipplin 🧑 -->
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        public static string VRLGetCLRDefault32CorlibPath()
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
        public static FrameworkVersion VRLGetFrameworkVersionByFileVersion(string assemblyFilePath)
        {
            var versionInfo = FileVersionInfo.GetVersionInfo(assemblyFilePath);

            if (versionInfo.FileMajorPart == 4)
            {

                // New Framework 4.7.3 - Windows 10 October Update 2018 - 02.10.2018
                if (versionInfo.FileMinorPart == 8)
                {
                    if (versionInfo.FileBuildPart >= 483752)
                    {
                        return FrameworkVersion.v4_8;
                    }
                    return FrameworkVersion.v4_7;
                }
                if (versionInfo.FileMinorPart == 7)
                {
                    if (versionInfo.FileBuildPart >= 461808)
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

        /// <summary>
        /// Get Windows Operation System current Build
        /// </summary>
        /// <!-- Author Tippo 🧑 -->
        /// 
        /// <!-- Author Tippo 🧑 -->
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        public static string VRLIsWindowsOperationSystem()
        {

            
            switch ( VRLGetCurrentBuildNumber() )
            {
                // Anniversary Update
                case "14393":
                    return "14393";
                // Creators Update(15063)
                case "15063":
                    return "15063";
                // Fall Creators Update
                case "16299":
                    return "16299"; 
                // April 2018 Update
                case "17134":
                    return "17134";
                // October 2018 Update
                case "17763":
                    return "17763"; 
                // May 2019 Update
                case "18362":
                    return "18362";
                // Sep Oct Update
                case "18900":
                    return "18900";
                default:
                    VFLMsgBox("No current Buildnumber available", "IsWindowsOperationSystem", STYLES.OkOnly | STYLES.Exclamation | STYLES.MsgBoxSetForeground | STYLES.SystemModal);
                    break;

            } // SWITCH_END


            return "null";

        } // METHOD_END::IsWindowsOperationSystem







    } // END::OF::CLASS::InstalledFramework

} // END::OF::NAMESPACE::Visual.Registry.Library
/*-----------------------------------------------------------------------------
 * END::OF::FILE::CUtitily.cs
 *-----------------------------------------------------------------------------
 */