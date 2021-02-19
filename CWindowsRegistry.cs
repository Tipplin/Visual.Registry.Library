//#############################################################################
//
// Project		:	Visual.Galaxy.Framework
//
//-----------------------------------------------------------------------------
// Programmer	:	Christian "Tipplin" Kurs
//-----------------------------------------------------------------------------
// Part         :	Visual.Registry.Library
//-----------------------------------------------------------------------------
// Base Class	:	CWindowsRegistry
//-----------------------------------------------------------------------------
// Assist       :   Automatic Versions Setting
//              :   Major, Minor, Build, Revision
//              :   increment always at build run - compile -
//              :   but in Project only build and revision
//              :   set build option, so he show the complete Build-Run
//              :   Build-Run Log in Project-Directory: Projectname.log
//------------------------------------------------------------------------------
//------------------------------------------------------------------------------
// Copyright © 2017 - 2021
// by Visual Galaxy Framework Community Kernel Developer Team
//
// by Head-Author: Christian "Tipplin" Kurs - Visual C# Senior Developer
// Portions Copyright © 1982-2019 by Microsoft Corporation GmbH.
//
// Same sourcecode by Microsoft, so we marked with Copyright !.
// © 1982-2021 - Copyrights by Microsoft: Images, Icons, Signs, Gadgets, 
// Copyright © and Tradewark by Microsoft Windows, Windows Logo, Visual Studio
// ----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
//
// written by 		Christian "TIPPO" Kurs
// 				    Ahornweg 1
//					-G - 53177 Bonn
//					Germany - Allemagne - Duitsland
//-----------------------------------------------------------------------------
//                  mobile              :   0049 173 4593440
//					Skype				:
//					e-mail				:	kurschristian@gmail.de
//					my Website Community:	
//					
//                  my google account   :   
//                  https://mail.google.com/mail/kurschristian
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
//				
//
//				Honest Business Users, to use our compiled Versions, 
//				please call us to send you our Business Licenses.
//				or our Business Website:
//				
//				
//
//----------------------------------------------------------------------------
//######################### Visual.Galaxy.Framework ##########################
//#
//# Start Date: 2018/03/01 - 17:00 - Ground Leaning -Initial
//#
//#---------------------------------------------------------------------------
//# Freeze Date: 
//# (FREEZE: like Microsoft - stopp develop, no more codes into project,
//# - but develop goes on - compiling to R T M )
//# Microsoft Developer's have all one or more Platform's for Project's.
//# Microsoft Office, Project, Team Foundation Server... 
//# Microsoft Build Server - all Developer save they code here, test OK! 
//# Build Server bundles that and compile a Daily Build - 
//# like Windows 10 Desktop - B 15002 - 09.01.2017.
//# --------------------------------------------------------------------------
//#
//# ! NOTE ! Develop are going on, new an features in later build.
//#
//#
//#
//#
//############################################################################
//############################################################################
//
// Base Object
using System;
// for streams: StreamWriter, StreamReader
using System.IO;

using System.Linq;
using System.Reflection;

// for Network
using System.Net;
using System.Text;
using System.Timers;
// for Threads: Thread.Sleep
using System.Threading;

using System.Security;
using System.Security.Principal;
using System.Security.Permissions;
using System.Security.AccessControl;
using System.Security.Authentication;

// for play Soundfile .wav - Soundplayer
using System.Media;
using System.Windows.Forms;
using Microsoft.Win32;

// Set here own Assemblies as Directive

//-----------------------------------------------------------------------------
// Our famous VisualD.Resource.Library.dll - pure Resources ! -
// Music, Sounds, Images, Icons and more...
//
// At End set extension Properties.
// using VisualD.Resource.Library.Properties;
// The Visual Studio Resource Manager do for us the insert Class Resouce,
// Before!, 
// change option in Resource Manager from intern to public by Resources
// var sp = new SoundPlayer(Resource.ALARM2);
//-------------------set ---Resource Manager .ALARM2 is the Sound resource.
//-----------------------------------------------------------------------------
using VisualD.Resource.Library.Properties;


// Set here all non directives/Assemblies - here only namespaces.


using static Visual.Registry.Library.VRLBase;


// !NOTE! NOT an Assembly/Directive, 
// is other namespace in this Project-Solution and Visual C# File:
// InternalCalls.cs
using Visual.Registry.Library.Internal;

using static Visual.Operation.System.Internal.InternalUtilities.VOSInternalUtilities;

using static Visual.Operation.System.Native.NativeMethods;

using static Visual.Operation.System.Native.NativeRuntimeMethods;

using static Visual.Operation.System.Native.UnsafeNativeMethods;


using static Visual.Operation.System.Internal.InternalOSMethods;







// Set here namespace and class and enums - class and enums written with static
//using static WindowsNativeSystem.NativeMethods.UnsafeEnumerators;

// only two slashes here allowed
// xml /// slashes only on Class, Method and so... allowed
namespace Visual.Registry.Library
{
    /*
     * this must be stand in first line, otherwise the Registry Editor make Exception Message
     * in Windows 10 ! - Windows 10 now show NOT a Dialog Window, write directly into Registry.
     * 
        Windows Registry Editor Version 5.00

        ; this is the comment sign in Registry File .reg !
        ; our settings in Registry for an App!
        [HKEY_LOCAL_MACHINE\SOFTWARE\Software Creative Production\System\Class_Security]
        "SCP_DLL_SEC_USER_LEVEL"=""
        "SCP_DLL_SEC_CRYPT_INST"=dword:00000000
        "SCP_DLL_SEC_CRYPT_KEY"=dword:00000000
        "SCP_DLL_SEC_USER_ACCESS_LEVEL"=dword:00000000

        [HKEY_LOCAL_MACHINE\SOFTWARE\Software Creative Production\System\VFL]

        [HKEY_LOCAL_MACHINE\SOFTWARE\Software Creative Production\System\VFL\LICENSE]
        "SCP_LIC_USER_NAME"=""
        "SCP_LIC_COMPUTER_NAME"=""
        "SCP_LIC_USER_PASSWORD"=dword:00000000
        "SCP_LIC_USER_PASSWORD_LEVEL"=hex(b) :00,00,00,00,00,00,00,00

    */

    /*
            [HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion]
            "SystemRoot" = "C:\\WINDOWS"
            -----------------------------------------------------------------------
            Windows 10 'May Update 2019'
            Windows Explorer
            Betriebssystem-Build 10.0.18362.116 
            -----------------------------------------------------------------------
            Part of Registry:
            UBR = bf (hexadecimal/decimal) == 191 - means the current OS-Revision
            ReleaseId = 1903
            BuildBranch = rs5_release
            BuildLab = 
            -----------Redstone 5--------10.04.2018 um 18:04 compiliert
            CurrentBuild = 18362
            CurrentBuildNumber = 18362
            EditionId = Professional
            ----------------------------------------------------------------------
            "CompositionEditionID" = "Professional"
            "CurrentBuild" = "18362"
            "CurrentBuildNumber" = "18362"
            "CurrentMajorVersionNumber" = dword:0000000a
            "CurrentMinorVersionNumber" = dword : 00000000
            "CurrentType" = "Multiprocessor Free"
            "CurrentVersion" = "6.3"
            "EditionID" = "Professional"----------------------------------> Windows 10 Editions here Professional,
            --------------------------------------------------------------> Home, Professional, S (School), Learn, Enterprise, Workstation, Server
            "EditionSubstring" = ""
            "InstallationType" = "Client"
            "InstallDate" = dword:5a47e21c
            "ProductName" = "Windows 10 Pro"
            "ReleaseId" = "1903"------------------------------------------> Release Version here Fall Creators Update-- V1709
            --------------------------------------------------------------> Release Version here Spring Creators Update V1803
            "SoftwareType" = "System"
            ; UBR is the actual Revisionnumber ! hexadecimal value
            ; by Spring Creators Update Current Revision 167 (OS-Build 17134.191)
            ; 000000bf == dezimal = 191
            "UBR" = dword:000000bf----------------------------------------> UBR means the Revisionnumber of Windows 10 Operation System
            --------------------------------------------------------------> ! ATTENTION ! Microsoft increment eeverytime this Revisionnumber by Bugs and other..
            --------------------------------------------------------------> OS-build 17134.191 revision 191 by Spring Creators Update.
            "PathName" = "C:\\WINDOWS"
            "ProductId" = "00330-71230-97984-AAOEM"
            "RegisteredOrganization" = "-"
            "RegisteredOwner" = "TIPPO"
            "InstallTime" = hex(b) : de, 93, 9e, 58, a0, 81, d3, 01
            [HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\InstalledSDB]

            [HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\InstalledSDB\{08274920 - 8908 - 45c2 - 9258 - 8ad67ff77b09}]
            "DatabasePath" = "C:\\WINDOWS\\AppPatch\\Custom\\Custom64\\{08274920-8908-45c2-9258-8ad67ff77b09}.sdb"
            "DatabaseType" = dword : 00010000
            "DatabaseDescription" = "IIS Express Application Compatibility Database for x64"
            "DatabaseInstallTimeStamp" = hex(b) : c4, aa, 8b, 60, fb, 6d, d3, 01

            [HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\InstalledSDB\{ad846bae - d44b - 4722 - abad - f7420e08bcd9}]
            "DatabasePath" = "C:\\WINDOWS\\AppPatch\\Custom\\{ad846bae-d44b-4722-abad-f7420e08bcd9}.sdb"
            "DatabaseType" = dword : 0001000
            "DatabaseDescription" = ""
            "DatabaseInstallTimeStamp

            [HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\PenService]
            "AliasSketchbookPro.exe" = "E5129A69-FF3A-4129-AE69-9C2E280AAA4B"
            "ExprGD.exe" = "30988F51-D107-4f3b-97A8-60953D29EA39"
            "Freehand MX.exe" = "21A8443D-F741-4d5d-954D-5FE60196A5E8"
            "iexplore.exe" = "596fd73c-fff3-4d3f-81d3-8af2955f3547"
            "Illustrator.exe" = "9A979A3F-92BB-49e9-8F2E-4EB423A9BFC9"
            "photoshop.exe" = "1CAD86A5-8A18-4297-A3FF-5A110325FA12"
            "powerpnt.exe" = "1EC353D2-7EE4-4cbe-A63A-4BFE68DBC65A"
            "visio.exe" = "36D1B905-CC62-4ab0-9C08-118B66D6DB90"



            [HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Shared\CompatMarkers\RS4]
            "UtcSyncId" = "{C53CE595-1286-43D1-8C29-C1491F5C6323}"
            "checksum" = hex:5e, eb, 04, 39, 31, d0, 3d, 59, 94, 3e, 70, 5f, 72, 9e, 8f, 8d, e5, 1c, ed, a1, 71, \
            d6, ba, d4, 3d, 2a, 7c, 4c, 30, 1b, ff, 9b

            [HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\BackgroundModel\BackgroundAudioPolicy]
            "AllowHeadlessExecution" = dword : 00000000
            "AllowMultipleBackgroundTasks" = dword : 00000001
            "InactivityTimeoutMs" = dword : 0000ea60

            [HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\DefaultProductKey2]
            "ProductId" = "00330-71230-97984-AAOEM"
            "DigitalProductId"
            "MicrosoftRedirectionProgramCommandLineParameters" = ""
            "MicrosoftRedirectionURL" = "http://go.microsoft.com/fwlink/events.asp"
            "LocalProvider" = "{2C786341-0E36-4BE8-AA51-524CC1F2AE15}"
            "RegistrarHost" = "C:\\Windows\\explorer.exe"
            "CommandLine" = "-m \"%m\" %c"
            "InternalName" = "*"
            "MappedExeName" = "C:\\Windows\\SysWOW64\\setup16.exe"
            "ProductName" = "Microsoft Setup for Windows"
            "ProductVersion" = "1.2"

            "InternalName" = "*"
            "MappedExeName" = "C:\\Windows\\SysWOW64\\InstallShield\\setup.exe"
            "ProductName" = "InstallShield*"
            "ProductVersion" = "5*"

            */






    /// <summary>
    /// Wrappers for Registry Functions.
    /// </summary>
    public static class VRLWindowsRegistry
    {
        
        #region ### Enumerators for Registry

        /// Enumerator for Registry Rights:
        internal enum RegistryRights
        {
            // No None field - An ACE with the value 0 cannot grant nor deny.
            QueryValues = KEY_QUERY_VALUE,              // 0x0001 query the values of a registry key
            SetValue = KEY_SET_VALUE,                   // 0x0002 create, delete, or set a registry value
            CreateSubKey = KEY_CREATE_SUB_KEY,          // 0x0004 required to create a subkey of a specific key
            EnumerateSubKeys = KEY_ENUMERATE_SUB_KEYS,  // 0x0008 required to enumerate sub keys of a key
            Notify = KEY_NOTIFY,                        // 0x0010 needed to request change notifications
            CreateLink = KEY_CREATE_LINK,               // 0x0020 reserved for system use
                                                               ///
                                                               /// The Windows Kernel team agrees that it was a bad design to expose the WOW64_n options as permissions.
                                                               /// in the .NET Framework these options are exposed via the RegistryView enum
                                                               ///
                                                               ///        Reg64             = Win32Native.KEY_WOW64_64KEY,          // 0x0100 operate on the 64-bit registry view
                                                               ///        Reg32             = Win32Native.KEY_WOW64_32KEY,          // 0x0200 operate on the 32-bit registry view
            ExecuteKey = ReadKey,
            ReadKey = STANDARD_RIGHTS_READ | QueryValues | EnumerateSubKeys | Notify,
            WriteKey = STANDARD_RIGHTS_WRITE | SetValue | CreateSubKey,
            Delete = 0x10000,
            ReadPermissions = 0x20000,
            ChangePermissions = 0x40000,
            TakeOwnership = 0x80000,
            FullControl = 0xF003F | STANDARD_RIGHTS_READ | STANDARD_RIGHTS_WRITE
        }



        #endregion


        #region ### Constants for Keys and Install Keys ###



        internal static string message;

        //---------------------------------------------------------------------
        // see the new constants, only one declaration for all constants, 
        // next constants set commata that's all
        // last constant with semicolon ;
        // @ sign for unicode: normal two slashes \\
        //---------------------------------------------------------------------
        internal const string   WPF = @"Software\Microsoft\.NETFramework\Windows Presentation Foundation",
                                WPF_Features = WPF + "\\Features",
                                value_MediaImageDisallow = "MediaImageDisallow",
                                value_MediaVideoDisallow = "MediaVideoDisallow",
                                value_MediaAudioDisallow = "MediaAudioDisallow",
                                value_WebBrowserDisallow = "WebBrowserDisallow",
                                value_ScriptInteropDisallow = "ScriptInteropDisallow",
                                value_AutomationWeakReferenceDisallow = "AutomationWeakReferenceDisallow",
                                WPF_Hosting = WPF + "\\Hosting",
                                value_DisableXbapErrorPage = "DisableXbapErrorPage",
                                value_UnblockWebBrowserControl = "UnblockWebBrowserControl",
                                HKCU_XpsViewer = @"HKEY_CURRENT_USER\Software\Microsoft\XPSViewer",
                                value_IsolatedStorageUserQuota = "IsolatedStorageUserQuota",
                                HKLM_XpsViewerLocalServer32 = @"HKEY_LOCAL_MACHINE\SOFTWARE\Classes\CLSID\{7DDA204B-2097-47C9-8323-C40BB840AE44}\LocalServer32",

                                HKLM_IetfLanguage = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Nls\IetfLanguage",
                                // These constants are cloned in 
                                // wpf\src\Shared\Cpp\Utils.cxx
                                // Should these reg keys change the above file should be also modified to reflect that.
                                FRAMEWORK_RegKey = @"Software\Microsoft\Net Framework Setup\NDP\v4\Client\",
                                FRAMEWORK_RegKey_FullPath = @"HKEY_LOCAL_MACHINE\" + FRAMEWORK_RegKey,
                                FRAMEWORK_InstallPath_RegValue = "InstallPath"; // here is the last constant with semicolon ;

         internal const int  STANDARD_RIGHTS_REQUIRED = 0x000F0000,
                             SYNCHRONIZE = 0x00100000,
                                        STANDARD_RIGHTS_READ = READ_CONTROL,
                                        STANDARD_RIGHTS_WRITE = READ_CONTROL,
                                        PROCESS_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0xFFF,
                                        REG_BINARY = 3,
                                        REG_MULTI_SZ = 7,
                                        READ_CONTROL = 0x00020000,
                                        KEY_QUERY_VALUE = 0x0001,
                                        KEY_ENUMERATE_SUB_KEYS = 0x0008,
                                        KEY_NOTIFY = 0x0010,
                                        KEY_READ = ((STANDARD_RIGHTS_READ | KEY_QUERY_VALUE | KEY_ENUMERATE_SUB_KEYS | KEY_NOTIFY) & (~SYNCHRONIZE)),
                                        KEY_SET_VALUE = 0x0002,
                                        KEY_CREATE_SUB_KEY = 0x0004,
                                        KEY_CREATE_LINK = 0x0020,
                                        KEY_WRITE = ((STANDARD_RIGHTS_WRITE | KEY_SET_VALUE | KEY_CREATE_SUB_KEY) & (~SYNCHRONIZE)),
                                     KEY_WOW64_64KEY = 0x0100,     //
                                     KEY_WOW64_32KEY = 0x0200,     //
                                     REG_OPTION_NON_VOLATILE = 0x0000,     // (default) keys are persisted beyond reboot/unload
                                     REG_OPTION_VOLATILE = 0x0001,     // All keys created by the function are volatile
                                     REG_OPTION_CREATE_LINK = 0x0002,    // They key is a symbolic link
                                     REG_OPTION_BACKUP_RESTORE = 0x0004,  // Use SE_BACKUP_NAME process special privileges
                                     REG_NONE = 0,    // No value type
                                     REG_SZ = 1,     // Unicode nul terminated string
                                     REG_EXPAND_SZ = 2,     // Unicode
                                     REG_DWORD = 4,    // 32-bit number
                                     REG_DWORD_LITTLE_ENDIAN = 4,    // 32-bit number (same as REG_DWORD)
                                     REG_DWORD_BIG_ENDIAN = 5,    // 32-bit number
                                     REG_LINK = 6,     // Symbolic Link (unicode)
                                     REG_RESOURCE_LIST = 8,     // Resource list in the resource map
                                     REG_FULL_RESOURCE_DESCRIPTOR = 9,   // Resource list in the hardware description
                                     REG_RESOURCE_REQUIREMENTS_LIST = 10,
                                     REG_QWORD = 11;    // 64-bit number






        //----------------------------------------------------------------------------------------------------------------
        // see the new Microsoft Code Convention, one constant declare for constants.
        // pro constant last sign is commata, the last constants with semicolon ;
        //----------------------------------------------------------------------------------------------------------------
        internal const string vrlPathSubKeyName = @"SOFTWARE\VisualRegistryLibrary\Logs", 
                              vrlPathName = "InstallLogPath",
                              vrlDataFolder = "Data", 
                              localizedMpqPathFormat = "Data/{1}/{0}-{1}.mpq",
                              OSInstallTypeRegKey = @"Software\Microsoft\Windows NT\CurrentVersion",
                              OSInstallTypeRegKeyPath = @"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion",
                              OSInstallTypeRegName = "InstallationType",
                              InstallTypeStringClient = "Client",
                              InstallTypeStringServer = "Server",
                              InstallTypeStringServerCore = "Server Core",
                              InstallTypeStringEmbedded = "Embedded"; // at end constants set ; semicolon
                              

        // System.Net.WindowsInstallationType
        internal enum WindowsInstallationType
        {
            Unknown,    // Windows Installation Type is unknown !
            Client,     // Windows 10
            Server,     // Windows Server 2016 or !NEW! at 2018 Windows Server 2019
            ServerCore, //
            Embedded    //
        }

        /// <summary>
        /// signs allowed with 1 char (UTF16)
        /// in Visual C#, more than 1 char make message too many chars in char literal.
        /// Typescript is string allowed in Enumerator. Visual C# later.
        /// </summary>
        internal enum FlagSigns
        {
            flagEuro = '€',
            flagDollar = '$'

        }



        /// <summary>
        /// test play sound file NOTICE.wav (Registry Voice) from our famous Visual.Resource.Library/Assembly - pure resources !!!..
        /// </summary>
        /// <!-- Author Tipplin 🧑-->
        /// 
        /// <!-- Author Tipplin 🧑-->
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        internal static bool VRLPlaySoundRegistered()
        {
            try
            {
                // SoundPlayer is in System.Media, but play's only wave files .wav !
                // Microsoft Windows Function PlaySound(); internal.
                // resourse form our famous Visual.Resource.Library.dll,
                // pure Resources!!! - Music, Sound, Images, Pictures, Photos, Icons, Animated GIF'S....
                // the Resource Manager insert automatic the Class Resources,
                // before you add Resource, set mode over band on public, standard is internal no outside use !!!.
                // using Visual.Resource.Library.Properties;
                var sp = new SoundPlayer(stream: Resources.NOTICE);

                // play one time, other option PlayLooping, ever endless!
                sp.Play();
            }
            catch (Exception ex)
            {
                // Use our famous MessageBox, not .Net MessageBox
                VFLMsgBox(ex.Message, "Resource-Exception", STYLES.OkOnly | STYLES.Critical | STYLES.MsgBoxSetForeground | STYLES.SystemModal);
                return false;
            }


            return true;
        }

        /// <summary>
        /// test play sound file BACKSND.wav (Background Music) from our famous Visual.Resource.Library/Assembly - pure resources !!!..
        /// </summary>
        /// <!-- Author Tipplin 🧑-->
        /// 
        /// <!-- Author Tipplin 🧑-->
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        internal static bool VRLPlaySoundBackSound()
        {
            try
            {
                // SoundPlayer is in System.Media, but play's only wave files .wav !
                // Microsoft Windows Function PlaySound(); internal.
                // resourse form our famous Visual.Resource.Library.dll,
                // pure Resources!!! - Music, Sound, Images, Pictures, Photos, Icons, Animated GIF'S....
                // the Resource Manager insert automatic the Class Resources,
                // before you add Resource, set mode over band on public, standard is internal no outside use !!!.
                // using Visual.Resource.Library.Properties;
                var sp = new SoundPlayer(stream: Resources.BACKSND);

                // play one time, other option PlayLooping, ever endless!
                sp.Play();
            }
            catch (Exception ex)
            {
                // Use our famous MessageBox, not .Net MessageBox
                VFLMsgBox(ex.Message, "Resource-Exception", STYLES.OkOnly | STYLES.Critical | STYLES.MsgBoxSetForeground | STYLES.SystemModal);
                return false;
            }


            return true;
        }


        /// <summary>
        /// test play sound file SNDTEST.wav (Sound Test) from our famous Visual.Resource.Library/Assembly pure resources !!!.
        /// </summary>
        /// <!-- Author Tipplin 🧑-->
        /// 
        /// <!-- Author Tipplin 🧑-->
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        internal static bool VRLPlaySoundTest()
        {
            try
            {
                // SoundPlayer is in System.Media, but play's only wave files .wav !
                // Microsoft Windows Function PlaySound(); internal.
                // resourse form our famous Visual.Resource.Library.dll,
                // pure Resources!!! - Music, Sound, Images, Pictures, Photos, Icons, Animated GIF'S....
                // the Resource Manager insert automatic the Class Resources,
                // before you add Resource, set mode over band on public, standard is internal no outside use !!!.
                // using Visual.Resource.Library.Properties;
                var sp = new SoundPlayer(stream: Resources.SNDTEST);

                // play one time, other option PlayLooping, ever endless!
                sp.Play();
            }
            catch (Exception ex)
            {
                // Use our famous MessageBox, not .Net MessageBox
                VFLMsgBox(ex.Message, "Resource-Exception", STYLES.OkOnly | STYLES.Critical | STYLES.MsgBoxSetForeground | STYLES.SystemModal);
                return false;
            }
            return true;
        }






        /// <summary>
        /// Get Windows InstallType
        /// </summary>
        /// <!-- Author Tipplin 🧑 -->
        /// 
        /// <!-- Author Tipplin 🧑 -->
        /// <returns></returns>
        internal static WindowsInstallationType VRLGetWindowsInstallType()
        {
            try
            {
                
                    string text = registryKey.GetValue("InstallationType") as string;

                    if (string.IsNullOrEmpty(text))
                    {
                        return WindowsInstallationType.Unknown;
                    }
                    if (string.Compare(text, "Client", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        return WindowsInstallationType.Client;
                    }
                    if (string.Compare(text, "Server", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        return WindowsInstallationType.Server;
                    }
                    if (string.Compare(text, "Server Core", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        return WindowsInstallationType.ServerCore;
                    }
                    if (string.Compare(text, "Embedded", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        return WindowsInstallationType.Embedded;
                    }

                    return WindowsInstallationType.Unknown;
                
            }
            catch (UnauthorizedAccessException ex)
            {
                VFLMsgBox(ex.Message, ex.TargetSite.ToString(), STYLES.OkOnly | STYLES.Critical | STYLES.MsgBoxSetForeground | STYLES.SystemModal);
                return WindowsInstallationType.Unknown;
            }
            catch (SecurityException ex2)
            {
                VFLMsgBox(ex2.Message, "SecurityException", STYLES.OkOnly | STYLES.Critical | STYLES.MsgBoxSetForeground | STYLES.SystemModal);
                return WindowsInstallationType.Unknown;
            }
        }




        #endregion



        /// <summary>
        /// Create RegistryKey for Machinename
        /// </summary>
        /// <!-- Author Tipplin 🧑 -->
        /// 
        /// <!-- Author Tipplin 🧑 -->
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        public static string VRLCreateRegistryKeyMachineName()
        {
            

            if(VOSIsWindows10_OSBuild_18362_Revision_10000() == false)
            {
                message = "This is NOT Windows 10 OS-Build 18362 and Revision 10000\n";
                message += "Microsoft have skip the Revision by 19h2 second half year 2019\n";
                message += "but the Build is now the same 18362 normally with Revision,\n";
                message += "after final release ca. September 2019 new OS-Build and Revision higher as 10000.\n\n";
                message += "For use our famous Assembly, please make a update on new Windows 10.\n";
                message += "Terminate now this Assembly !.\n";

                VFLMsgBox(message, "Check Windows Operation System", STYLES.OkOnly | STYLES.Exclamation | STYLES.MsgBoxSetForeground | STYLES.SystemModal);
                
                // C/C++ Runtime function from mscrt.dll - 64BIT -
                NRMExit(EXIT_CODES.ERROR_NOT_FOUND);
                
            }

            // try / catch / finally block for Exception-handling
            try
            {
                // var reg = new RegistrySecurity();

                // set sound with Soundplayer - sound from Visual.Resource.Library.dll - our pure Resource Assembly !
                var sp = new SoundPlayer(Resources.SNDTEST);


                // set value for the registry-key "SCP_LIC_COMPUTER_NAME" with datatype string in key.
                string MachineName = Environment.MachineName;

                RegKey.SetValue("SCP_LIC_COMPUTER_NAME", MachineName, Microsoft.Win32.RegistryValueKind.String);
                
                // play signal Key is written!.
                sp.Play();

                RegKey.Close();


            }
            catch (SystemException ex)when(ex is UnauthorizedAccessException | ex is SecurityException) 
            {
                VFLMsgBox(ex.Message, ex.Source, STYLES.OkOnly | STYLES.Critical | STYLES.MsgBoxSetForeground | STYLES.SystemModal);
                
                // returns boolean string here 'False'
                return false.ToString();
            }
            //finally - is ultimative free resourcer, exception  or NOT - SimpleSample: object.Close(); and so...
            //{ }

            // returns boolean string here 'True'
            return true.ToString();
        }

        /// <summary>
        /// Create RegistryKey Username
        /// </summary>
        /// <!-- Author Tipplin 🧑-->
        /// 
        /// <!-- Author Tipplin 🧑-->
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        public static bool VRLCreateRegistryKeyPasswordLevel(int SecurityLevel)
        {

            // try / catch / finally block for Exception-handling
            try
            {
                // set for vNext insert Security for Key's
                // var reg = new RegistrySecurity();

                
                // take crypted Password into Key - SecureString automatic crypted the Password by insert with AES265 (.NET Framework)
                // SecureString with IDisposable - GC not allowed to take into memory.
                // After App end all in Memory override with zeros.
                RegKey.SetValue("SCP_LIC_USER_PASSWORD_LEVEL", SecurityLevel, Microsoft.Win32.RegistryValueKind.String);

            }
            catch (Exception ex)
            {
                VFLMsgBox(ex.Message, "Registry-Exception NOW !!!", STYLES.OkOnly | STYLES.Critical | STYLES.MsgBoxSetForeground | STYLES.SystemModal);
                
                //MessageBox.Show(ex.Message, "Registry Exception NOW !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            finally // TIPPOTIP: finally is ultimate free resourcer, Exception or NOT Exception !!! - Practice for all native Windows Resources.
            {
                RegKey.Close();
            }



            return true;

        }

       

        /// <summary>
        /// Get the current Revisionumber (Operation System Build) on this Computer
        /// </summary>
        /// <!-- Author Tipplin 🧑-->
        /// 
        /// <!-- Author Tipplin 🧑-->        /// <remarks>
        /// Operation System Build-> Major, Minor, Build, Revision
        /// Windows 10 now: for ever Major 10 and Minor 0, Buildnumber increment and Revision increment
        /// Now! Windows 10 'Spring Creators Update' - Build 17133.73 at 11.04.2018
        /// Final Release everytime is 17133.1 - 1 final release at 06.04.2018
        /// After CleanUp's - Blocking Bug - cumulative update at 11.04.2018 with new Revision 73
        /// Revisionnumber stand in Registry Key under UBR. Next Revision, he change the Value automatic.
        /// </remarks>
        /// <returns>
        /// Have Windows 10 Spring Creators update August 17133.228, so he returned Value 228
        /// </returns>
        public static int VRLGetCurrentRevisionnumber()
        {
            int iResult;
            // opening the registry-key on local machine, our system-settings
            // write using block, so we safe exception-handling
            // now in using block inside the try/catch block.

            
                // Windows 10 May Update 2019 OS-Build 18362.10000 -
                // have cast the Value, while is DWORD 0x000002715 -  is the current revision .10005
                iResult = (int)RegKey.GetValue("UBR");
               
                return iResult;
            
            
        }

        /// <summary>
        ///     Validate the current Revision-number with newer !!!.
        /// </summary>
        /// <!-- Author Tipplin 🧑-->
        /// 
        /// <!-- Author Tipplin 🧑--> 
        /// <param name="UBR">
        ///     UBR (DWORD) is the given Revisionnumber in Registry.
        /// </param>
        /// <remarks>
        /// Microsoft make the increment of Revisionnumber's, automatic at updates:
        /// 1. cumulative update or security update.
        /// 2. great update with new OS-build and Revision.
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        public static bool VRLValidateRevisionnumber(int UBR)
        {

            bool bResult = false;

            // GetValue is object
            int iResult = (int)RegKey.GetValue("UBR");

            if(iResult < UBR)
            {
                string MessageText = string.Format("The current Revisionnumber on this Computer {0} is older as the given UBR", Environment.MachineName);

                VFLMsgBox(MessageText, "VRL - Validate Revisionnumber", STYLES.OkOnly | STYLES.Exclamation | STYLES.MsgBoxSetForeground | STYLES.SystemModal);
            }
            else
            {
                string MessageText = string.Format("The current Revisionnumber on this Computer {0} is equalvalent to given UBR", Environment.MachineName);

                VFLMsgBox(MessageText, "VRL - Validate Revisionnumber", STYLES.OkOnly | STYLES.Exclamation | STYLES.MsgBoxSetForeground | STYLES.SystemModal);
            }


            RegKey.Close();
            return bResult;
        }

        /// <summary>
        /// Get the current Buildnumber on this Computer
        /// </summary>
        /// <!-- Author Tipplin 🧑-->
        /// 
        /// <!-- Author Tipplin 🧑-->
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        public static string VRLGetCurrentBuildNumber()
        {
            
            // instance class RegistryKey stand in Class Head
            string strResult = (string)RegKey.GetValue("CurrentBuildNumber");

            return strResult;
        }

        /// <summary>
        /// Get the current ReleaseId - Fall Creators Update V1709 new Spring Creators Update 1803 on this Computer
        /// </summary>
        /// <!-- Author Tipplin 🧑-->
        /// 
        /// <!-- Author Tipplin 🧑-->
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        public static string VRLGetCurrentReleaseId()
        {
            
            // GetValue is object
            string strResult = (string)RegKey.GetValue("ReleaseId");

            return strResult;
        }


        /// <summary>
        /// Get the current Buildbranch is rs3_release/rs4_release on this Computer
        /// </summary>
        /// <!-- Author Tipplin 🧑-->
        /// 
        /// <!-- Author Tipplin 🧑-->
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        public static string VRLGetCurrentBuildBranch()
        {

            // GetValue is object
            string strResult = (string)RegKey.GetValue("BuildBranch");

            return strResult;
        }



        /// <summary>
        /// Get the current EditionId is Home, Professional or Enterprise on this Computer
        /// </summary>
        /// <!-- Author Tipplin 🧑-->
        /// 
        /// <!-- Author Tipplin 🧑-->
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        public static string VRLGetCurrentEditionID()
        {

            // GetValue is object
            string strResult = (string)RegKey.GetValue("EditionID");

            return strResult;
        }

        /// <summary>
        /// Get the current RegisteredOrganization - Company Name on this Computer
        /// </summary>
        /// <!-- Author Tipplin 🧑-->
        /// 
        /// <!-- Author Tipplin 🧑-->
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        public static string VRLGetCurrentRegisteredOrganization()
        {

            // GetValue is object
            string strResult = (string)RegKey.GetValue("RegisteredOrganization");

            return strResult;
        }


        /// <summary>
        /// Get the current RegisteredOwner - Username on this Computer
        /// </summary>
        /// <!-- Author Tipplin 🧑-->
        /// 
        /// <!-- Author Tipplin 🧑-->
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        public static string VRLGetCurrentRegisteredOwner()
        {

            // GetValue is object
            string strResult = (string)RegKey.GetValue("RegisteredOwner");

            return strResult;
        }


        /// <summary>
        /// Get the current BuildLab is the compiled Build and Date and Time --> 17133.rs4_release.180323-1312 - Username on this Computer
        /// </summary>
        /// <!-- Author Tipplin 🧑-->
        /// 
        /// <!-- Author Tipplin 🧑--> 
        /// <remarks>
        /// 17133 --> Spring Creators Update rs4_release-- Redstone 4 Final Release 
        /// --> 180323 means 23.03.2018 at 13:12 compiled
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        public static string VRLGetCurrentBuildLab()
        {
            // GetValue is object
            string strResult = (string)RegKey.GetValue("BuildLab");

            return strResult;
        }




        // TIPPO-UNDONE - failed Method from VFL VFLLicRandomString(RegLicStringLength, RegLicType);

        /// <summary>
        /// Create Registry Key and set the License String.
        /// </summary>
        /// <!-- Author Tipplin 🧑-->
        /// 
        /// <!-- Author Tipplin 🧑--> 
        /// <param name="RegLicString">length of License Key String</param>
        /// Type of License Key String: 0 = alpha string, 1 = alphanumeric string, 2 = numeric string
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        public static bool VRLVerifyLicenseStringKey(string RegLicString)
        {
            return VLLLicVerifyLicFile(RegLicString);
        }

        /// <summary>
        /// Get the Log Path from Registry.
        /// </summary>
        /// <!-- Author Tipplin 🧑-->
        /// 
        /// <!-- Author Tipplin 🧑-->
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        public static string VRLGetLogPath()
        {

            using (RegKey.OpenSubKey(vrlPathSubKeyName))
            {
                if (RegKey != null)
                    return (string)RegKey.GetValue(vrlPathName, null);
            }

            return null;
        }

        /// <summary>
        /// Gets a value indicating whether World of Warcraft is installed.
        /// </summary>
        /// <!-- Author Tipplin 🧑-->
        /// 
        /// <!-- Author Tipplin 🧑-->
        /// <remarks>
        /// 
        /// </remarks>
        /// <return>
        /// 
        /// </return>
        public static bool VRLIsVGFInstalled
        {
            get { return VRLGetLogPath() != null; }
        }

        /// <summary>
        /// Gets the installed locales in World of Warcraft.
        /// </summary>
        /// <!-- Author Tipplin 🧑-->
        /// 
        /// <!-- Author Tipplin 🧑-->
        /// <remarks>
        /// 
        /// </remarks> 
        /// <returns>
        /// 
        /// </returns>
        public static string[] VRL_VGFGetLocales()
        {
            if (!VRLIsVGFInstalled)
                throw new InvalidOperationException("ATTENTION: Visual Galaxy Framework is not installed !!!.");

            string VRLPath = VRLGetLogPath();

            if (vrlPathName != null)
            {
                string dataPath = Path.Combine(VRLPath, vrlDataFolder);
                if (Directory.Exists(dataPath))
                    return
                        Directory.GetDirectories(dataPath).Select(
                            directory => directory.Substring(directory.LastIndexOf(Path.DirectorySeparatorChar) + 1)).
                            ToArray();
            }

            return null;
        }

        /// <summary>
        /// Get .NET Version from Registry
        /// </summary>
        /// <!-- Author Tipplin 🧑-->
        /// 
        /// <!-- Author Tipplin 🧑-->
        /// <remarks>
        /// 
        /// </remarks>
        /// <return>>
        /// 
        /// </return>
        internal static void VRLGetNETVersionFromRegistry()
        {
            
                // As an alternative, if you know the computers you will query are running .NET Framework 4.5 
                // or later, you can use:
                // using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, 
                // RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\"))
                foreach (string versionKeyName in ndpKey.GetSubKeyNames())
                {
                    if (versionKeyName.StartsWith("v"))
                    {

                        RegistryKey versionKey = ndpKey.OpenSubKey(versionKeyName);
                        string name = (string)versionKey.GetValue("Version", "");
                        string sp = versionKey.GetValue("SP", "").ToString();
                        string install = versionKey.GetValue("Install", "").ToString();
                        if (install == "") //no install info, must be later.
                            Console.WriteLine(versionKeyName + "  " + name);
                        else
                        {
                            if (sp != "" && install == "1")
                            {
                                Console.WriteLine(versionKeyName + "  " + name + "  SP" + sp);
                            }

                        }
                        if (name != "")
                        {
                            continue;
                        }
                        foreach (string subKeyName in versionKey.GetSubKeyNames())
                        {
                            RegistryKey subKey = versionKey.OpenSubKey(subKeyName);
                            name = (string)subKey.GetValue("Version", "");
                            if (name != "")
                                sp = subKey.GetValue("SP", "").ToString();
                            install = subKey.GetValue("Install", "").ToString();
                        if (install == "") //no install info, must be later.
                            Console.WriteLine(versionKeyName + "  " + name);
                        else
                        {
                            if (sp != "" && install == "1")
                            {
                                Console.WriteLine("  " + subKeyName + "  " + name + "  SP" + sp);
                            }
                            else if (install == "1")
                            {
                                Console.WriteLine("  " + subKeyName + "  " + name);
                            }
                        }    
                    }
                }
            }
        }

        /// <summary>
        /// Get .NET Framework Version
        /// </summary>
        /// <!-- Author Tipplin 🧑 -->
        /// 
        /// <!-- Author Tipplin 🧑 -->
        /// <remarks>
        /// 
        /// </remarks>
        /// <return>
        /// 
        /// </return>
        public static void VRLGet45PlusFromRegistry()
        {
            const string subkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";

            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey))
            {
                if (ndpKey != null && ndpKey.GetValue("Release") != null)
                {
                    Console.WriteLine(".NET Framework Version: " + VRLCheckFor45PlusVersion((int)ndpKey.GetValue("Release")));
                }
                else
                {
                    Console.WriteLine(".NET Framework Version 4.5 or later is not detected.");
                }
            }
        }

        /// <summary>
        /// Checking the version using >= will enable forward compatibility.
        /// </summary>
        /// <!-- Author Tipplin 🧑 -->
        /// 
        /// <!-- Author Tipplin 🧑 -->
        /// <param name="releaseKey"></param>
        /// <returns>
        /// 
        /// </returns>
        public static string VRLCheckFor45PlusVersion(int releaseKey)
        {
            if (releaseKey >= 461814)
                return "4.8";
            if (releaseKey >= 461808)
                return "4.7.2"; // come with Windows 10 April Update V1804 - OS-Build 17134.1
            if (releaseKey >= 461308)
                return "4.7.1";
            if (releaseKey >= 460798)
                return "4.7";
            if (releaseKey >= 394802)
                return "4.6.2";
            if (releaseKey >= 394254)
                return "4.6.1";
            if (releaseKey >= 393295)
                return "4.6";
            if (releaseKey >= 379893)
                return "4.5.2";
            if (releaseKey >= 378675)
                return "4.5.1";
            if (releaseKey >= 378389)
                return "4.5";
            // This code should never execute. A non-null release key should mean
            // that 4.5 or later is installed.
            return "No 4.5 or later version detected";
        }
    







    } // END::OF::CLASS::CWindowsRegistry

} // END::OF::NAMESPACE::Visual.Registry.Library
  /*-----------------------------------------------------------------------------
   * END::OF::FILE::CWindowsRegistry.cs
   *-----------------------------------------------------------------------------
   */
