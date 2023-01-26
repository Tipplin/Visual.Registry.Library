//#############################################################################
//
// Project		:	Visual.Registry.Library
//
//-----------------------------------------------------------------------------
// Programmer	:	Christian "Tipplin" Kurs
//-----------------------------------------------------------------------------
// Part         :	Registry
//-----------------------------------------------------------------------------
// Base Class	:	CWindowsRegistry
//-----------------------------------------------------------------------------
// Assist       :   Automatic Versions Setting
//              :   Major, Minor, Build, Revision
//              :   increment always at build run - compile -
//              :   but in Project only build and revision
//              :   set build option, so he show the complete Build-Run
//              :   Build-Run Log in Project-Directory: Projectname.log
//-----------------------------------------------------------------------------
// Specials     :   Change Platform to .NET 7
//              :
//              :
//------------------------------------------------------------------------------
// Copyright © 2018, by Visual Galaxy Framework Community Kernel Developer Team
//
// by Head-Author: Christian "TIPPO" Kurs - Visual C# Senior Developer
// Portions Copyright © 2018 by Microsoft Corporation GmbH.
//
// Same sourcecode by Microsoft, so we marked with Copyright !.
// © 1982 - 2018 - Copyrights by Microsoft: Images, Icons, Signs, Gadgets, 
// Copyright © and Tradewark by Microsoft Windows, Windows Logo, Visual Studio
// ----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
//
// written by 		Christian "Tipplin" Kurs
// 				    Ahornweg 1
//					-G - 53177 Bonn
//					Germany - Allemagne - Duitsland
//-----------------------------------------------------------------------------
// 				    voice				:	
//					international phone	:	00-49-1734593440
//					Skype				:
//					e-mail				:	kurschristian@gmail.de
//					my Website Community:	
//					
//-----------------------------------------------------------------------------
// This software is supplied as is. Use it at your own  RISK !!!!.
// Obviously I've tried to do the best job possible.
// If you find any problem with it, let me know.
//
// With any luck, Visual Galaxy Framework will make it obsolete anyway
//-----------------------------------------------------------------------------
// License:	
//				NO fee for NON-Commercial use.
//				our Community Website: 
//				in Progress
//				
//
//				Honest Business Users, to use our compiled Versions, 
//				please call us to send you our Business Licenses.
//				or our Business Website:
//				is Progress
//				
//
//----------------------------------------------------------------------------
// Same specified to Project "Visual.Galaxy.Framework":
// 
// 	    Bugfix 			-	for Errors (clean up's)
//
//		Hotfix			-	pass to Operation System-update, bugfixes, cleanup
//
//		SecurityFix		-	for Security leaks
//
//		Quickfix		-	quick update for App
//
// combine with Reason in ExitWindowsEx and 
// Shutdown Flag: EWX_RESTARTAPPS | ShutdownReason.REASON_PLANNED_FLAG
// so the Operation System force to close all App's and shutdown,
// install SecurityFix and restart the System and restart the last App.
//
//----------------------------------------------------------------------------
//-------------------------- Project History ---------------------------------
//----------------------------------------------------------------------------
// Release 0.0.0 - 2017/01/01 - TIPPO - KC - Project Founder - Initial
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

//######################## Other notable Changes #############################
//
// Other:
// [VGF.NET - 01] 
//
//----------------------------------------------------------------------------
// Bug:
// [VGF.NET - 01]
// Timer Control 
//----------------------------------------------------------------------------
// Fixes:
//[VGF.NET - Bug 01]
// forget Timer, set directly in Console program.cs the call for the
// Image Form.
//---------------------------------------------------------------------------- 
// Miscellous:
// .1 insert Windows form to Console Project for Splash.
// Console Window goes at Runtime in resize Window, show the Image Form,
// unload method the Image Form in program.cs after Thread.Sleep(7000);
// Resize the Console Window normal, show all relevant Informations for User,
// what have the Console App done.(Settings for user and more.)
// For User: NO Personal Datas have use or write into a File, only machinename
// username that's all.
//
// 
// 
// 
// 
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

// for play Soundfile .wav - Soundplayer
using System.Media;
using System.Windows.Forms;
using Microsoft.Win32;

//-----------------------------------------------------------------------------
// Our famous VisualD.Resource.Library.dll - pure resoures -
// Music, Sounds, Images, Icons and more...
// At End set extension Properties.
// The Visual Studio Resource Manager do for us the all inserts,
// var sp = new SoundPlayer(Resources.ALARM2);
//-------------------set ---Resource Manager .ALARM2 is the Sound resource.
//-----------------------------------------------------------------------------
using VisualD.Resource.Library.Properties;

using NativeMethods;

// only two slashes here allowed
// xml /// slashes only on Class, Method and so... allowed
namespace Visual.Registry.Library
{
    /*
        Windows Registry Editor Version 5.00

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
            Registry Key:
            [HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion]
            "SystemRoot" = "C:\\WINDOWS"
            -----------------------------------------------------------------------
            Windows 10 'Spring Creators Update'
            Windows Explorer
            Betriebssystem-Build 10.0.17133.1 (WinBuild.160101.0800)
            -----------------------------------------------------------------------
            Part of Registry:
            UBR = 1 (hexadecimal/decimal)
            ReleaseId = 1803
            BuildBranch = rs4_release
            BuildLab = 17133.rs4_release.180323-1312
            -----------Redstone 4--------23.03.2018 um 13:12 compiliert
            BuildLabEx = 17133.1.amd64fre.rs4_release.180323-1312
            CurrentBuild = 17133
            CurrentBuildNumber = 17133
            EditionId = Professional
            ----------------------------------------------------------------------
            "CompositionEditionID" = "Professional"
            "CurrentBuild" = "16299"
            "CurrentBuildNumber" = "16299"
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
            "ReleaseId" = "1709"------------------------------------------> Release Version here Fall Creators Update-- V1709
            --------------------------------------------------------------> Release Version here Spring Creators Update V1803
            "SoftwareType" = "System"
            ; UBR is the actual Revisionnumber ! hexadecimal value
            ; by Spring Creators Update Current Revision 48 (OS-Build 17134.48)
            ; 000000d6 == dezimal = 214
            "UBR" = dword:000000d6----------------------------------------> UBR means the Revisionnumber of Windows 10 Operation System
            --------------------------------------------------------------> ! ATTENTION ! Microsoft increment eeverytime this Revisionnumber by Bugs and other..
            --------------------------------------------------------------> OS-build 16299.371 revision 371 and 17134.5 Revision by Spring Creators Update.
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
    public static class CWindowsRegistry
    {

        //################### TIPPO INFO ################################
        // ! ATTENTION ! In some Platforms, 
        // the Windows Registry NOT supports!!!.
        // use our Methods for Windows,
        // For other Operation System they NOT supports this, following:
        // preprocessor directive:
        // #if __WINDOWS__
        //  here the Code Statements
        // #elif __Unix__
        //  throw SystemException
        // #elif __APPLE__
        //
        // #elif __Linux__
        //
        // #endif
        //
        //###############################################################


        #region ### Enumerators for Registry

        /// Enumerator for Registry Rights:
        internal enum RegistryRights
        {
            // No None field - An ACE with the value 0 cannot grant nor deny.
            QueryValues = KEY_QUERY_VALUE,          // 0x0001 query the values of a registry key
            SetValue = KEY_SET_VALUE,            // 0x0002 create, delete, or set a registry value
            CreateSubKey = KEY_CREATE_SUB_KEY,       // 0x0004 required to create a subkey of a specific key
            EnumerateSubKeys = KEY_ENUMERATE_SUB_KEYS,   // 0x0008 required to enumerate sub keys of a key
            Notify = KEY_NOTIFY,               // 0x0010 needed to request change notifications
            CreateLink = KEY_CREATE_LINK,          // 0x0020 reserved for system use
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

        // see the new constants, only one declaration for all constants, next constants set commata that's all
        // last constant with semicolon ;
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
                    HKLM_XpsViewerLocalServer32 = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Classes\\CLSID\\{7DDA204B-2097-47C9-8323-C40BB840AE44}\\LocalServer32",

                    HKLM_IetfLanguage = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Nls\IetfLanguage",
                    // These constants are cloned in 
                    // wpf\src\Shared\Cpp\Utils.cxx
                    // Should these reg keys change the above file should be also modified to reflect that.
                    FRAMEWORK_RegKey = @"Software\Microsoft\Net Framework Setup\NDP\v4\Client\",
                    FRAMEWORK_RegKey_FullPath = @"HKEY_LOCAL_MACHINE\" + FRAMEWORK_RegKey,
                    FRAMEWORK_InstallPath_RegValue = "InstallPath"; /// here is the last constant with semicolon ;

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
        internal const string vrlPathSubKeyName = @"SOFTWARE\VisualRegistryLibrary\Logs", vrlPathName = "InstallLogPath",
                              vrlDataFolder = "Data", localizedMpqPathFormat = "Data/{1}/{0}-{1}.mpq",
                              OSInstallTypeRegKey = "Software\\Microsoft\\Windows NT\\CurrentVersion",
                              OSInstallTypeRegKeyPath = "HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows NT\\CurrentVersion",
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

        /*
        internal bool VRLGetSystemTimeAsFileTime()
        {
            CUnsafeNativeStructs.FILE_TIME fILE_TIME = default(CUnsafeNativeStructs.FILE_TIME);
            NativeMethods.CUnsafeNativeMethods.GetSystemTimeAsFileTime(ref fILE_TIME);

        }
        */

        /// <summary>
        /// test play sound file NOTICE.wav (Registry Voice) from our famous Visual.Resource.Library/Assembly - pure resources !!!..
        /// </summary>
        /// <returns></returns>
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
                SafeNativeMethods.VFLMsgBox(ex.Message, "Resource-Exception", UnsafeConstants.Style1);
                return false;
            }


            return true;
        }

        /// <summary>
        /// test play sound file BACKSND.wav (Background Music) from our famous Visual.Resource.Library/Assembly - pure resources !!!..
        /// </summary>
        /// <returns></returns>
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
                SafeNativeMethods.VFLMsgBox(ex.Message, "Resource-Exception", UnsafeConstants.Style1);
                return false;
            }


            return true;
        }


        /// <summary>
        /// test play sound file SNDTEST.wav (Sound Test) from our famous Visual.Resource.Library/Assembly pure resources !!!.
        /// </summary>
        /// <returns></returns>
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
                SafeNativeMethods.VFLMsgBox(ex.Message, "Resource-Exception", UnsafeConstants.Style1);
                return false;
            }


            return true;
        }






        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal static WindowsInstallationType GetWindowsInstallType()
        {
            try
            {
                // Opening the Registry first and the specifies Key CurrentVersion
                // All Windows 10 Informations inside and UBR for the Revisionnumber in datatype DWORD.
                //
                //
                using (RegistryKey registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion"))
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
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "UnauthorizedAccessException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return WindowsInstallationType.Unknown;
            }
            catch (SecurityException ex2)
            {
                MessageBox.Show(ex2.Message, "SecurityException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return WindowsInstallationType.Unknown;
            }
        }




        #endregion



        /// <summary>
        /// Create RegistryKey for Machinename
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public static bool VRLCreateRegistryKeyMachineName()
        {
            
            // try / catch / finally block for Exception-handling
            try
            {
                // var reg = new RegistrySecurity();

                // set sound with Soundplayer - sound from Visual.Resource.Library.dll - our pure Resource Assembly !
                var sp = new SoundPlayer(Resources.SNDTEST);

                // opening the registry-key on local machine, our system-settings
                //
                // write using block, so we safe exception-handling
                // now in using block inside the try/catch block.
                RegistryKey RegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Software Creative Production\System\VFL\LICENSE");


                // set value for the registry-key "SCP_LIC_COMPUTER_NAME" with datatype string in key.
                string MachineName = Environment.MachineName;
                RegKey.SetValue("SCP_LIC_COMPUTER_NAME", MachineName, RegistryValueKind.String);
                // play signal Key is written!.
                sp.Play();

                RegKey.Close();


            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Registry Exception NOW !!!", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return false;
                
            }
            //finally - is ultimative free resourcer, exception  or NOT - SimpleSample: object.Close(); and so...
            //{ }

            return true;
        }

        // TODO: RegistryAccessRule error

        /*
        /// <summary>
        /// Create RegistryKey Username
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public static bool VRLCreateRegistryKeyUserName()
        {

            string user = Environment.UserDomainName + "\\" + Environment.UserName;


            // try / catch / finally block for Exception-handling
            try
            {
                var reg = new RegistrySecurity();

                // Flag Deny is obsolete and will be removed at newer .NET Framework
                // new RegistryPermission(PermissionState.None).Assert();

                RegistrySecurity rs = new RegistrySecurity();
                
                // opening the registry-key on local machine, our system-settings
                // write using block, so we safe exception-handling
                // now in using block inside the try/catch block.
                RegistryKey RegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Software Creative Production\System\VFL\LICENSE");

                // Add a rule that grants the current user ReadKey
                // rights. ReadKey is a combination of four other 
                // rights. The rule is inherited by all 
                // contained subkeys.
                var rule = new RegistryAccessRule(   user,
                                                                    RegistryRights.QueryValues,
                                                                    InheritanceFlags.ContainerInherit,
                                                                    PropagationFlags.None,
                                                                    AccessControlType.Allow);
                                                                    rs.AddAccessRule(rule);


                // Create a rule that allows the current user only the 
                // right to query the key/value pairs of a key, using  
                // the same inheritance and propagation flags as the
                // first rule. QueryValues is a constituent of 
                // ReadKey, so when this rule is removed, using the 
                // RemoveAccessRule method, ReadKey is broken into
                // its constituent parts.
                /*rule = new RegistryAccessRule(  user,
                                                RegistryRights.QueryValues,
                                                InheritanceFlags.ContainerInherit,
                                                PropagationFlags.None,
                                                AccessControlType.Allow);
                                                rs.RemoveAccessRule(rule);

                

                // set value for the registry-key "SCP_LIC_COMPUTER_NAME" with datatype string in key.
                string UserName = Environment.UserName;
                RegKey.SetValue("SCP_LIC_USER_NAME", UserName, RegistryValueKind.String);

                RegKey.Close();

                // Display the rules in the security object.
                VRLShowSecurity(rs);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Registry Exception NOW !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            

            return true;

        }

*/

        /// <summary>
        /// Create RegistryKey Username
        /// </summary>
        /// <remarks>
        ///     See in Parameter Password, the secure Class SecureString,
        ///     he crypt the string/password directly with the AES-Crypt-Proceed
        ///     internal automatic, Class SecureStrings with inheri IDisposable,
        ///     so the GC can NOT push into Memory, at end of Program write over with zeros.
        ///     SecureString for PIN, TAN, PASSWORD, LOGON
        /// </remarks>
        /// <returns>
        /// the key and password registered false/true as return
        /// !NOTE! In Visual C# are hard coded, 0 or 1 !
        /// </returns>
        public static bool VRLCreateRegistryKeyPassword(SecureString Password)
        {
            // try / catch / finally block for Exception-handling
            try
            {
                var reg = new RegistrySecurity();

                // opening the registry-key on local machine, our system-settings
                //
                // write using block, so we safe exception-handling
                // now in using block inside the try/catch block.
                RegistryKey RegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Software Creative Production\System\VFL\LICENSE");

                // take crypted Password into Key - SecureString automatic crypted the Password by insert with AES265 (.NET Framework)
                // SecureString with IDisposable - GC not allowed to take into memory.
                // After App end all in Memory override with zeros.

                // vNext insert double secure keys and Class RegistrySecurity - NOT allowed Change, read/write, delete !!!
                // can set than expired date for user password, please insert new Password, old password is expired !!!
                // Windows 10 "Spring Creators Update" more LogOn Screen, Fingerprint, Face Detection, PIN and Password.
                // PIN insert, than your must no Password Insert. Have a PIN Validation, allowed/not allowed:
                // simplesample: 1234, 4567, 1111..... 
                RegKey.SetValue("SCP_LIC_USER_PASSWORD", Password, RegistryValueKind.String);

                RegKey.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Visual Registry Library - Exception NOW !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }

            return true;

        }


        /// <summary>
        /// Create RegistryKey Username
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public static bool VRLCreateRegistryKeyPasswordLevel(int SecurityLevel)
        {


            // opening the registry-key on local machine, our system-settings
            //
            // write using block, so we safe exception-handling
            // now in using block inside the try/catch block.
            //
            // 
            // First have write RegistryKey RegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Software Creative Production\System\VFL\LICENSE");
            // in Try, but set Finally no access to RegKey for close the Key.
            //
            // See the sign @ is for unicode, so reduce the slashes to one. (slash \\..\\ to \..\)
            RegistryKey RegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Software Creative Production\System\VFL\LICENSE");

            // try / catch / finally block for Exception-handling
            try
            {
                // set for vNext insert Security for Key's
                // var reg = new RegistrySecurity();

                
                // take crypted Password into Key - SecureString automatic crypted the Password by insert with AES265 (.NET Framework)
                // SecureString with IDisposable - GC not allowed to take into memory.
                // After App end all in Memory override with zeros.
                RegKey.SetValue("SCP_LIC_USER_PASSWORD_LEVEL", SecurityLevel, RegistryValueKind.String);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Registry Exception NOW !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            finally // TIPPOTIP: finally is ultimate free resourcer, Exception or NOT Exception !!! - Practice for all native Windows Resources.
            {
                RegKey.Close();
            }



            return true;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="security"></param>
        public static void VRLShowSecurity(RegistrySecurity security)
        {
            // initialize orignal width + weight
            int origWidth;
            int origHeight;

            // orignal width and height of Console Window
            origWidth = Console.WindowWidth;
            origHeight = Console.WindowHeight;
            
           


            // Delete show Information in ConsoleBuffer to Console Window
            Console.Clear();
            
            // Set new BackgroundColor to BLUE
            Console.BackgroundColor = ConsoleColor.Blue;

            // use SetWindowSize
            Console.SetWindowSize(origWidth, origHeight);

            // Delete show Information in ConsoleBuffer to Console Window
            Console.Clear();

            // Set out Console Window Title
            Console.Title = "Show your Security in Registry - Copyright © 2018 by Christian 'TIPPO' Kurs - Visual .NET - C# / C++ Developer.";

            Console.WriteLine("\r\nCurrent access rules for {0}:\n", Environment.UserName);

            foreach (RegistryAccessRule ar in security.GetAccessRules(true, true, typeof(NTAccount)))
            {
                
                Console.WriteLine("        User: {0}", ar.IdentityReference);
                Console.WriteLine("        Type: {0}", ar.AccessControlType);
                Console.WriteLine("      Rights: {0}", ar.RegistryRights);
                Console.WriteLine(" Inheritance: {0}", ar.InheritanceFlags);
                Console.WriteLine(" Propagation: {0}", ar.PropagationFlags);
                Console.WriteLine("   Inherited? {0}", ar.IsInherited);
                Console.WriteLine();
            }

            Console.Write("\t\t\tCopyright © 2018 by Christian 'TIPPO' Kurs - Visual .NET - C# / C++ Developer.\n");
            Console.Write("\t\t\tPortions Copyright © 2018 by Microsoft Corporation.\n\n\n");
        }

        /// <summary>
        /// Get the current Revisionumber (Operation System Build) on this Computer
        /// </summary>
        /// <remarks>
        /// Operation System Build-> Major, Minor, Build, Revision
        /// Windows 10 now: for ever Major 10 and Minor 0, Buildnumber increment and Revision increment
        /// Now! Windows 10 'Spring Creators Update' - Build 17133.73 at 11.04.2018
        /// Final Release everytime is 17133.1 - 1 final release at 06.04.2018
        /// After CleanUp's - Blocking Bug - cumulative update at 11.04.2018 with new Revision 73
        /// Revisionnumber stand in Registry Key under UBR. Next Revision, he change the Value automatic.
        /// </remarks>
        /// <returns>
        /// Have Spring Creators update 17133.73, so he returned Value 73
        /// </returns>
        public static int VRLGetCurrentRevisionnumber()
        {

            // opening the registry-key on local machine, our system-settings
            // write using block, so we safe exception-handling
            // now in using block inside the try/catch block.


            // !!! ATTENTION !!! both keys, but the first without Operation System Info's
            // HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows\\CurrentVersion
            // OSInstallTypeRegKey = HKEY_LOCAL_MACHINE\\Software\\Microsoft\\Windows NT\\CurrentVersion
            RegistryKey RegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(OSInstallTypeRegKey);
            
            // GetValue is object
            int iResult = (int)RegKey.GetValue("UBR");

            RegKey.Close();
            return iResult;
            
            

        }

        /// <summary>
        /// Validate the current Revisionumber with newer !!!.
        /// </summary>
        /// <param name="UBR">
        ///     UBR is the given revisionnumber
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        public static bool VRLValidateRevisionnumber(int UBR)
        {

            bool bResult = false;

            // opening the registry-key on local machine, our system-settings
            // write using block, so we safe exception-handling
            // now in using block inside the try/catch block.
            // see the sign before registry string, is the unicode sign (UTF16) in Visual C# !.
            // "\\\..\\.\\ - @"\\..\.\"
            // Unicode is .NET !, UTF8 - with "German Umlauts", UTF16 - CLR internal, UTF32 for algorithmen only!.
            // coding same in Microsoft Editor, Windows 10 validate Text in this Editor, if unicode sign inside,
            // he make a message "This text have unicode sign, please change coding to unicode, not ansi !." (lost datas)
            // 
            RegistryKey RegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Software Creative Production\System\VFL\LICENSE");
            
            // GetValue is object
            int iResult = (int)RegKey.GetValue("UBR");

            if(iResult < UBR)
            {
                string MessageText = string.Format("The current Revisionnumber on this Computer {0} is older as the given UBR", Environment.MachineName);
                MessageBox.Show(MessageText, "VRL - Validate Revisionnumber", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string MessageText = string.Format("The current Revisionnumber on this Computer {0} is equalvalent to given UBR", Environment.MachineName);
                MessageBox.Show(MessageText, "VRL - Validate Revisionnumber", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            RegKey.Close();
            return bResult;
        }

        /// <summary>
        /// Get the current Buildnumber on this Computer
        /// </summary>
        /// <returns></returns>
        public static string VRLGetCurrentBuildNumber()
        {
            // opening the registry-key on local machine, our system-settings
            // write using block, so we safe exception-handling
            // now in using block inside the try/catch block.
            RegistryKey RegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Software Creative Production\System\VFL\LICENSE");
            // GetValue is object
            string strResult = (string)RegKey.GetValue("CurrentBuildNumber");

            return strResult;
        }

        /// <summary>
        /// Get the current ReleaseId - Fall Creators Update V1709 new Spring Creators Update 1803 on this Computer
        /// </summary>
        /// <returns></returns>
        public static string VRLGetCurrentReleaseId()
        {
            // opening the registry-key on local machine, our system-settings
            // write using block, so we safe exception-handling
            // now in using block inside the try/catch block.
            RegistryKey RegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Software Creative Production\System\VFL\LICENSE");
            
            // GetValue is object
            string strResult = (string)RegKey.GetValue("ReleaseId");

            return strResult;
        }


        /// <summary>
        /// Get the current Buildbranch is rs3_release/rs4_release on this Computer
        /// </summary>
        /// <returns></returns>
        public static string VRLGetCurrentBuildBranch()
        {
            // opening the registry-key on local machine, our system-settings
            // write using block, so we safe exception-handling
            // now in using block inside the try/catch block.
            RegistryKey RegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Software Creative Production\System\VFL\LICENSE");

            // GetValue is object
            string strResult = (string)RegKey.GetValue("BuildBranch");

            return strResult;
        }



        /// <summary>
        /// Get the current EditionId is Home, Professional or Enterprise on this Computer
        /// </summary>
        /// <returns></returns>
        public static string VRLGetCurrentEditionID()
        {
            // opening the registry-key on local machine, our system-settings
            // write using block, so we safe exception-handling
            // now in using block inside the try/catch block.
            RegistryKey RegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Software Creative Production\System\VFL\LICENSE");

            // GetValue is object
            string strResult = (string)RegKey.GetValue("EditionID");

            return strResult;
        }

        /// <summary>
        /// Get the current RegisteredOrganization - Company Name on this Computer
        /// </summary>
        /// <returns></returns>
        public static string VRLGetCurrentRegisteredOrganization()
        {
            // opening the registry-key on local machine, our system-settings
            // write using block, so we safe exception-handling
            // now in using block inside the try/catch block.
            RegistryKey RegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Software Creative Production\System\VFL\LICENSE");

            // GetValue is object
            string strResult = (string)RegKey.GetValue("RegisteredOrganization");

            return strResult;
        }


        /// <summary>
        /// Get the current RegisteredOwner - Username on this Computer
        /// </summary>
        /// <returns></returns>
        public static string VRLGetCurrentRegisteredOwner()
        {
            // opening the registry-key on local machine, our system-settings
            // write using block, so we safe exception-handling
            // now in using block inside the try/catch block.
            RegistryKey RegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Software Creative Production\System\VFL\LICENSE");

            // GetValue is object
            string strResult = (string)RegKey.GetValue("RegisteredOwner");

            return strResult;
        }


        /// <summary>
        /// Get the current BuildLab is the compiled Build and Date and Time --> 17133.rs4_release.180323-1312 - Username on this Computer
        /// </summary>
        /// <remarks>
        /// 17133 --> Spring Creators Update rs4_release-- Redstone 4 Final Release 
        /// --> 180323 means 23.03.2018 at 13:12 compiled
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        public static string VRLGetCurrentBuildLab()
        {
            // opening the registry-key on local machine, our system-settings
            // write using block, so we safe exception-handling
            // now in using block inside the try/catch block.
            RegistryKey RegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Software Creative Production\System\VFL\LICENSE");

            // GetValue is object
            string strResult = (string)RegKey.GetValue("BuildLab");

            return strResult;
        }

        /// <summary>
        /// Create Registry Key and set the License String.
        /// </summary>
        /// <param name="RegLicStringLength">length of License Key String</param>
        /// <param name="RegLicType">
        /// Type of License Key String: 0 = alpha string, 1 = alphanumeric string, 2 = numeric string</param>
        /// <returns></returns>
        public static string VRLCreateRegistryLicenseString(int RegLicStringLength, int RegLicType)
        {

            //-----------------------------------------------------------------------------
            // Microsoft Code Convention for better Runtime Run
            // Microsoft Rule Guideline
            // Microsoft Name Convention
            // The First Letter at Method must be upper !!!.
            //-----------------------------------------------------------------------------
            // Microsoft Guidelines:
            // Warning by native Function to us in .NET,
            // It's different!, native Functions are unmanaged code, .NET managed code !!!!
            // Microsoft want this Classnames: 
            // class UnsafeNativeMethod - Security Check - Stackwalk
            // class NativeMethods - Security Check - Stackwalk
            // class SafeMethods - No Security Check - No Stackwalk -
            // calls are secure and No Risk for User Call. (no dangerous call)
            //-----------------------------------------------------------------------------


            if (RegLicStringLength == 0)
            {
                SafeNativeMethods.VFLMsgBox("Paramter must be set, for make result.", "Parameter-Error", UnsafeConstants.Style1);
                return null;
            }

            if(RegLicType == 0)
            {
                SafeNativeMethods.VFLMsgBox("Paramter must be set, for make result.", "Parameter-Error", UnsafeConstants.Style1);
                return null;

            }

            string RegistryLicenseString;

            // Class SafeNativeMethods all Calls are secure or without risk for User Call
            // That means No Security Check must be done, No Stackwalk!
            // Three Classes
            RegistryLicenseString = SafeNativeMethods.VFLLicRandomString(RegLicStringLength, RegLicType);


            return RegistryLicenseString;

        }

        /// <summary>
        /// Get the Log Path from Registry.
        /// </summary>
        /// <returns></returns>
        public static string VRLGetLogPath()
        {

            // opening the registry-key on local machine, our system-settings
            // write using block, so we safe exception-handling
            // now in using block inside the try/catch block.
            RegistryKey RegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Software Creative Production\System\VFL\LICENSE");



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
        public static bool IsVGFInstalled
        {
            get { return VRLGetLogPath() != null; }
        }

        /// <summary>
        /// Gets the installed locales in World of Warcraft.
        /// </summary>
        /// <returns></returns>
        public static string[] VGFGetLocales()
        {
            if (!IsVGFInstalled)
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


        





       



    } // End of Class CWindowsRegistry

} // End of namespace Visual.Registry.Library
