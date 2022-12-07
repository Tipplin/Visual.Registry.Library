//#############################################################################
//
// Project		:	Visual.Galaxy.Framework
//
//-----------------------------------------------------------------------------
// Programmer	:	Christian Kurs
//-----------------------------------------------------------------------------
// Part         :	Visual.Registry.Library
//-----------------------------------------------------------------------------
// Class        :	CUnsafeNativeMethods
//-----------------------------------------------------------------------------
// ActualVersion: 1.0.10000.44 <--- automatic increment (AutomaticVersionTool)
// IDEA         : is 99 set build increment on
// but can be change, TIPPOundone, 
// see in Microsoft Delta Program (Version Management Tool)
//-----------------------------------------------------------------------------
// Change Platform to .NET Framework 4.7.2 !!!
//
//#############################################################################
//-----------------------------------------------------------------------------
// INFO         : vNext change System messageBox to fasmous WPF MessageBox new
//              : written in C#, XAML, WPFramework, many features:
//              : left corner fiels, so you can make a greather MessageBox,
//              : WPF 3D Icons, own Icons, Hyperlink in WPF MessageBox,
//              : Copy button, Scroll, more details by errors, 
//              :
//              : Windows 10 Security Icon (yellow, red, green)
//              :
//              : active now!, running code analysis errors, warnings
//              :
//-----------------------------------------------------------------------------
//
//
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// !
// ! NEW ! In Visual Studio now Microsoft Guideline automatic active:
// ! ------------- V 15.6.6------------------------15.6.7----------------------
// ! Microsoft.Design, Microsoft.Portability,        Microsoft.Globalization
// !
// ! Make Warnings, like CA1901, CA1060 means application error by codeanaylize
// ! DON'T TO TIE UP this Warnings !!!.
// !
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// Automatic Syntax check, semantic and more!
// The Compiler runs now 'Under the Hood' from Visual Studio, this a precompile
// better back-end compile !.
// Insert a Codeline, he check the codeline ?! - OK, he directly compile.
//-----------------------------------------------------------------------------
// Microsoft Code Convention for better Runtime Run
// Microsoft Rule Guideline
// Microsoft Name Convention
// The First Letter at Method must be upper !!!.
// Microsoft 
// Warning by native Function to us in .NET,
// It's different!, native Functions are unmanaged code, .NET managed code !!!!
// Microsoft want, Classname: UnsafeNativeMethod, NativeMethods, SafeMethods
//
//-----------------------------------------------------------------------------
// Assist       :   Automatic Versions Setting
//              :   Major, Minor, Build, Revision
//              :   increment always at build run - compile -
//              :   but in Project only build and revision
//              :   set build option, so he show the complete Build-Run
//              :   Build-Run Log in Project-Directory: Projectname.log
//-----------------------------------------------------------------------------
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

//****************************************************************************
//
// namespace NativeMethods only for native Functions in a C++ Library.
//
//
//
//****************************************************************************

//****************************************************************************
// NativeMethods, means all native Dynamic Link Libraries written in C++ or
// C,
// Take Attention !!!, Microsoft have now Guidelines in active !
// Microsoft Portability and Micr0soft.Design specially for native DLL's !!!.
// Microsoft.Globalization too !.
//****************************************************************************
namespace NativeMethods
{

    // We have only one namespace here, so we can set the directives here
    // TIPPOTIP: local and outside standard is global.
    // same directives the color blend up. this means unused in this Project,
    // Compiler make message, build run he delete this directives or ignore this.
    // delete all blank spaces, Compiler goes from bottom to top by directives last is System.
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Security;
    using System.Runtime.InteropServices;




    /// <summary>
    /// Class CUnsafeConstants for IL-Values, for use.
    /// Values from IL-Code via IL-disassembler,
    /// all Values for the MessageBox Styles
    /// One Style Value for native Messagebox Flag,
    /// Button, Icon, SetForeground, SystemModal.
    /// Visual C# Compiler calculate one Value for all Flags.
    /// <remarks>
    ///     SCPGlobalConstants.h - C++
    ///     const unsigned int STYLE1 = MB_OK | MB_ICONHAND | MB_SETFOREGROUND | MB_SYSTEMMODAL;
    ///     const unsigned int STYLE2 = MB_OK | MB_ICONEXCLAMATION | MB_SETFOREGROUND | MB_SYSTEMMODAL;
    ///     const unsigned int STYLE3 = MB_OK | MB_ICONINFORMATION | MB_SETFOREGROUND | MB_SYSTEMMODAL;
    ///     const unsigned int STYLE4 = MB_OK | MB_ICONQUESTION | MB_SETFOREGROUND | MB_SYSTEMMODAL;
    ///     const unsigned int STYLE5 = MB_OK | MB_ICONASTERISK | MB_SETFOREGROUND | MB_SYSTEMMODAL;
    ///     const unsigned int STYLE6 = MB_YESNO | MB_ICONHAND | MB_SETFOREGROUND | MB_SYSTEMMODAL;
    ///     const unsigned int STYLE7 = MB_YESNO | MB_ICONEXCLAMATION | MB_SETFOREGROUND | MB_SYSTEMMODAL;
    ///     const unsigned int STYLE8 = MB_YESNO | MB_ICONINFORMATION | MB_SETFOREGROUND | MB_SYSTEMMODAL;
    ///     const unsigned int STYLE9 = MB_YESNO | MB_ICONQUESTION | MB_SETFOREGROUND | MB_SYSTEMMODAL;
    ///     const unsigned int STYLE10 = MB_OKCANCEL | MB_ICONHAND | MB_SETFOREGROUND | MB_SYSTEMMODAL;
    ///     const unsigned int STYLE11 = MB_OKCANCEL | MB_ICONEXCLAMATION | MB_SETFOREGROUND | MB_SYSTEMMODAL;
    ///     const unsigned int STYLE12 = MB_OKCANCEL | MB_ICONINFORMATION | MB_SETFOREGROUND | MB_SYSTEMMODAL;
    ///     const unsigned int STYLE13 = MB_OKCANCEL | MB_ICONQUESTION | MB_SETFOREGROUND | MB_SYSTEMMODAL;
    /// </remarks>
    /// declare class with UnsafeConstants, values come from IL-code (INT32)
    /// see in remarks the orignal flags with operator vertical bar |
    /// Visual C# Compiler calculate one Value for all Flags.
    /// </summary>
    internal static class UnsafeConstants
    {
        // OK-Button, Icon-Critical, Set Window in Foreground, System Modal - must be close, before continue!
        internal static uint Style1 = 0x00011010;
        // OK-Button, Icon-Exclamation, Set Window in Foreground, System Modal - must be close, before continue!
        internal static uint Style2 = 0x00011030;
        // OK-Button, Icon-Information, Set Window in Foreground, System Modal - must be close, before continue!
        internal static uint Style3 = 0x00011040;
        // OK-Button, Icon-Question, Set Window in Foreground, System Modal - must be close, before continue!
        internal static uint Style4 = 0x00011020;
        // OK-Button, Icon-Asterisk, Set Window in Foreground, System Modal - must be close, before continue!
        internal static uint Style5 = 0x00011040;
        internal static uint Style6 = 0x00011014;
        internal static uint Style7 = 0x00011034;
        internal static uint Style8 = 0x00011044;
        internal static uint Style9 = 0x00011024;
        internal static uint Style10 = 0x00011011;
        internal static uint Style11 = 0x00011031;
        internal static uint Style12 = 0x00011041;
        internal static uint Style13 = 0x00011021;


    }



    // all unsafe native Struts
    // if unused, compile make message!
    internal static class UnsafeNativeStructs
    {
        internal struct FILE_TIME
        {
            internal int ftTimeLow;

            internal int ftTimeHigh;
        }


    }

    /// <summary>
    /// -------------------------------------------------------------------------------------------
    /// Class SafeNativeMethods is Code Convention from Microsoft,
    /// !!! Three Guidelines active !!!: 
    /// Microsoft.Portability and Microsoft.Design and new Microsoft.Globalization (VS 2017 V15.7)
    /// -------------------------------------------------------------------------------------------
    /// Three Classes for unmanaged native Dynamic Link Library's
    /// 
    /// Microsoft Specified in Microsoft.Design:
    /// Inside with/or without Security Check, is Method secure or not and no risk by user call !!!
    /// -------------------------------------------------------------------------------------------
    /// NativeMethods---------> for Methods, use in Project-Solution at any Place
    /// Stackwalk is active.
    /// -------------------------------------------------------------------------------------------
    /// SafeNativeMethods-----> for Methods, use every User without dangerous call,
    /// No Security Check !!!, No Risk !!!, No Stackwalk !!!.
    /// -------------------------------------------------------------------------------------------
    /// UnsafeNativeMethods--->for Methods with Security Risk with full Secuity Check,
    /// No Stackwalk !!!.
    /// All three Classe must be write internal !!!. internal mode access.
    /// -------------------------------------------------------------------------------------------
    /// Special the Attribute [SuppressUnmanagedCodeSecurityAttribute]
    /// -------------------------------------------------------------------------------------------
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    internal static class SafeNativeMethods
    {
        /***************** Visual Function Library.dll **************** pure C Functions **********

        //-----------------------------------------------------------------------------
        INT SCPSTDCALL  vgfVFLCallTerminate(LPSTR DLLName, BOOL Protocol);
        //-----------------------------------------------------------------------------
        INT SCPSTDCALL  vgfVFLCallerTerminate(LPSTR AppName, BOOL Protocol);
        //-----------------------------------------------------------------------------
        VOID SCPSTDCALL  vgfVFLDLLCalls(UINT FreeCalls);
        //-----------------------------------------------------------------------------
        VOID SCPSTDCALL  vgfVFLDLLCalls2(INT iCalls);
        //-----------------------------------------------------------------------------
        LPTSTR SCPSTDCALL  vgfVFLGetStringRes(UINT uiResID);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLIsDefaultPrinter(LPTSTR pszPrinterName);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLIsProtectedFile(LPCWSTR pszProtFileName);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLLicApiDelEmptyKey(
                                                 LPCTSTR szKey,
                                                 LPCTSTR szSubKey);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLLicApiDeleteKey(
                                                 LPCTSTR szKey,
                                                 LPCTSTR szSubKey);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLLicApiRegisterCount(
                                                 LPSTR pszKey,
                                                 LPSTR pszValue,
                                                 LPSTR pszData);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLLicApiRegisterDT(
                                             LPSTR pszKey,
                                             LPSTR pszValue,
                                             LPSTR pszData);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLLicApiRegisterUser(
                                                 LPSTR pszKey,
                                                 LPSTR pszValue,
                                                 LPSTR pszData);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLLicApiRegisterVerifyEntry(
                                                         LPSTR pszKey,
                                                         LPSTR pszValue,
                                                         LPSTR pszData);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLRegisterString(
                                             LPSTR pszKey,
                                             LPSTR pszValue,
                                             LPSTR pszData);
        //-----------------------------------------------------------------------------
        //-----------------------------------------------------------------------------
        //-----------------------------------------------------------------------------
        VOID SCPSTDCALL  vgfVFLTerminateProcess(LPTSTR pszAppName);
        //-----------------------------------------------------------------------------	
        HRESULT SCPSTDCALL  vgfVFLRegisterApplication(LPSTR pszAppName);
        //-----------------------------------------------------------------------------
        HRESULT SCPSTDCALL  vgfVFLUnregisterApplication(LPCTSTR pszAppName);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLWindowsFeatureNotAvailable();
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLIsWindows10Build15063Installed();
        //-----------------------------------------------------------------------------
        LPTSTR SCPSTDCALL  vgfVFLDisplaySystemVersion();
        //-----------------------------------------------------------------------------
        LPSTR SCPSTDCALL  vgfVFLGetComputerName();
        //-----------------------------------------------------------------------------
        LPSTR SCPSTDCALL  vgfVFLGetUserName();
        //-----------------------------------------------------------------------------
        LPTSTR SCPSTDCALL  vgfVFLGetWindowsDirectory();
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLIsWindowMaximized(HWND hWndWindowHandle);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLIsWindowMinimized(HWND hWndWindowHandle);
        //-----------------------------------------------------------------------------
        VOID SCPSTDCALL  vgfVFLIsUnicodeSupported();
        //-----------------------------------------------------------------------------
        LPTSTR SCPSTDCALL  vgfVFLSysMemoryPercentInUse();
        //-----------------------------------------------------------------------------
        LPTSTR SCPSTDCALL  vgfVFLSysAvailExtendedVirtualMemory();
        //-----------------------------------------------------------------------------
        LPTSTR SCPSTDCALL  vgfVFLSysTotalPhysMemory();
        //-----------------------------------------------------------------------------
        LPTSTR SCPSTDCALL  vgfVFLSysTotalVirtualMemory();
        //-----------------------------------------------------------------------------
        LPTSTR SCPSTDCALL  vgfVFLSysAvailVirtualMemory();
        //-----------------------------------------------------------------------------
        LPTSTR SCPSTDCALL  vgfVFLSysAvailPhysicalVirtualMemory();
        //-----------------------------------------------------------------------------
        LPTSTR SCPSTDCALL  vgfVFLSysAvailExtendedVirtualMemory();
        //-----------------------------------------------------------------------------
        UINT SCPSTDCALL  vgfVFLMsgBox(
                                     LPCTSTR lpszText,
                                     LPCTSTR lpszTitle,
                                     UINT Style);
        //-----------------------------------------------------------------------------
        UINT SCPSTDCALL  vgfVFLMsgBoxSetup(LPCTSTR lpszObject,
                                         LPCTSTR lpszComponent,
                                         LPCTSTR lpszBetaComponent);
        //-----------------------------------------------------------------------------
        INT SCPSTDCALL  vgfVFLMessageBox(INT TextID);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLWindowAnimate(HWND WindowHandle,
                                             DWORD SlideTime);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLWindowAnimateAction(HWND WindowHandle,
                                                 DWORD SlideTime,
                                                 INT AnimateAction);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLLockWorkstation();
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLIsUserAdministrator();
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLCheckForSecretKeyStroke();
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLMultiBeep(DWORD Frequency, DWORD Duration);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLStartDirectEXE(LPCTSTR AppName);
        //-----------------------------------------------------------------------------
        INT SCPSTDCALL  vgfVFLMessageBoxTimeout(LPCWSTR Text,
                            LPCWSTR Title, UINT Icon, DWORD TimeOut);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLIsWindows10ProfessionalInstalled();
        //-----------------------------------------------------------------------------
        DWORD SCPSTDCALL  vgfVFLThreadSleep(INT SleepTime);
        //-----------------------------------------------------------------------------
        VOID SCPSTDCALL  vgfVFLTippoInfo1();
        //-----------------------------------------------------------------------------
        VOID SCPSTDCALL  vgfVFLTippoInfo2();
        //-----------------------------------------------------------------------------
        LPWSTR SCPSTDCALL  vgfVFLFormatBytes(unsigned int cBytes);
        //-----------------------------------------------------------------------------
        UINT SCPSTDCALL  vgfVFLRegisterWindowsMessage(LPCWSTR MessageText);
        //-----------------------------------------------------------------------------
        LONG SCPSTDCALL  vgfVFLRegisterApplicationRestart(PCWSTR ApplicationName);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLCheckIsInternetConnected(LPCWSTR Url);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLIsLibraryExpired(WORD Day,
                                                 WORD Month,
                                                 WORD Year,
                                                 WORD Hour,
                                                 WORD Minute);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLVerifyLicFile(LPTSTR pszLicFileName);
        //-----------------------------------------------------------------------------
        LPSTR SCPSTDCALL  vgfVFLLicRandomString(INT iLength, INT iType);
        //-----------------------------------------------------------------------------
        INT SCPSTDCALL  vgfVFLWriteDllCall(LPCTSTR pDLLName);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLShutdownSystemAppUpgrade(bool SystemProtocol);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLCallExitWinAppUpdatePlanned(WORD Hour, WORD Minute, BOOL SystemProtocol);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLCallExitWindows(UINT uFlags, DWORD dwReason);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLIsThresholdOrGreather();
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLIsWindows10OrGreather();
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLSetURLGoesOnline(LPCWSTR lpszURL,
                                                 HWND hwndParent,
                                                 DWORD dwFlags);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLUserGoesOnline(LPCWSTR lpszURL, DWORD dwFlags);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLConnectToInternet(LPCSTR ServerName);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLSetWindowOnPlace(HWND WindowHandle,
                                                 LONG Left,
                                                 LONG Right,
                                                 LONG Top,
                                                 LONG Buttom);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLSetFile_HIDDEN(LPCWSTR FileName);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLSetFile_READ_ONLY(LPCWSTR FileName);
        //-----------------------------------------------------------------------------
        BOOL SCPSTDCALL  vgfVFLIsFallCreatorsUpdateRev192();
        // Microsoft make for OS-Revision 192 
        // a spool in DLL microcodes (Meltdown/Spectre)
        // mc-genuine-intel.dll
        // mc-authentic-amd.dll
        //-----------------------------------------------------------------------------
        VOID SCPSTDCALL  vgfVFLHelpMsg(int HelpMessageId);
        //-----------------------------------------------------------------------------
        VOID SCPSTDCALL  vgfVFLTypingKeys();
        //-----------------------------------------------------------------------------
        */

        // For Windows 10 use unicode !, for International !!!
        // some Countries have special signs, Germany, Switzerland, Autriche have 'German Umlauts'
        // (Microsoft NEW simple Text Editor parse the Text for unicode signs, 
        // make message "Please use coding unicode for this Text ! NOT .ansi")
        //


        /// <summary>
        /// Our self MessageBox from Visual.Function.Library.dll
        /// </summary>
        /// <returns></returns>
        [DllImport("VFL.dll", EntryPoint = "vgfVFLMsgBox", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        internal static extern uint VFLMsgBox(
                                                    [MarshalAs(UnmanagedType.LPWStr)]
                                                    string MessageText,
                                                    [MarshalAs(UnmanagedType.LPWStr)]
                                                    string MessageTitle,
                                                    uint STYLE);

        /// <summary>
        /// Our self MessageBox with forward defined Text's.
        /// (CHAR Arrary's with option by _snprintf_s safe function, new parameter _countof, counts the elements of CHAR arrray)
        /// </summary>
        /// <param name="TextID"> Set only the Text ID from 1 to 27, what you want!</param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        [DllImport("VFL.dll", EntryPoint = "vgfVFLMessageBox", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        internal static extern int VFLMessageBox(int TextID);

        /// <summary>
        /// Create Random License Key String
        /// </summary>
        /// <param name="iLength">set the length for Key String</param>
        /// <param name="iType">set the Type: alpha only, alphanumeric only, numeric</param>
        /// <remarks>
        /// Use inside the Random Generator from C++ Runtime Library and 
        /// the Operation System Function GetTickCount64,
        /// !!! The GetTickCount is over!, after 49 days overflow!
        /// </remarks>
        /// <returns>
        /// returned your created Random License Key String
        /// </returns>
        [DllImport("VFL.dll", EntryPoint = "vgfVFLLicRandomString", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        internal static extern string VFLLicRandomString(int iLength, int iType);

        /// <summary>
        /// Set in Registry Key, for planned Application Update
        /// </summary>
        /// <param name="SystemProtocol">want a System-protocol ? 
        /// true/false set, automatic write a Log-file.</param>
        /// <remarks>
        /// Inside use ExitWindowsEx with Flags: Shutdown System and Reasons: 
        /// Major for Application and Minor for PLANNED_UPDATE
        /// The goes shutdown, can install the new update and restart the System.
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        [DllImport("VFL.dll", EntryPoint = "vgfVFLShutdownSystemAppUpgrade", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool VFLShutdownSystemAppUpgrade(bool SystemProtocol);

        /// <summary>
        /// !!! NOTE !!! - This Method only under Windows 10.
        /// Check is Windows Membership registered as Administrator, 
        /// thats means he have the Full Right on this Computer, NOT User !!!.
        /// </summary>
        /// <returns></returns>
        [DllImport("VFL.dll", EntryPoint = "vgfVFLIsUserAdministrator", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool VFLIsUserAdministrator();


        // [SecurityCritical]
        // [SuppressUnmanagedCodeSecurity]
        // 
        // private hat jetzt einen Schutzgrad !
        // private static extern bool IsWindows10RS3OrGreater(); 
        // wird aus einer anderen Klasse, soll diese Methode aufgerufen werden tritt eine Fehlermeldung !
        // Änderung ! in internal static extern bool IsWindows10RS3OrGreater();


        // At Visual Studio 2017 - V 15.6.6 - depreated/removed the old API
        // GetVersionEx and so... give wrong Version Info

        // Last Redstone is 5, at next Year 2019, Microsoft break with Redstone new Description !.

        /// <summary>
        /// Is Windows 10 Redstone 5
        /// </summary>
        ///     <remarks>
        ///     PresentationNative_v0400.dll has exported functions !.
        ///     Now, DON'T USE AT TIME THIS METHOD !!!!
        ///     Windows 10 Redstone 5 in develop, NOT Final !!!
        ///     Implement as Future Method !!!.
        ///     </remarks>
        /// <returns>
        /// 
        /// </returns>
        [DllImport("PresentationNative_v0400.dll", EntryPoint = "IsWindows10RS5OrGreater", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsWindows10RS5OrGreater();

        /// <summary>
        /// Is Windows 10 Redstone 4 - Spring Creators Update
        /// Windows 10 April Update 2018 - for all at 30.04.2018, 
        /// after Bugfixes, great bug was Blocking Bug, Microsoft STOPPED Final Release !!!,
        /// now STOPPED end!!!.
        /// now free for all !!!.
        /// </summary>
        /// <returns></returns>
        [DllImport("PresentationNative_v0400.dll", EntryPoint = "IsWindows10RS4OrGreater", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsWindows10RS4OrGreater();

        /// <summary>
        /// Is Windows 10 Redstone 3 - Fall Creators Update
        /// </summary>
        /// <returns></returns>
        [DllImport("PresentationNative_v0400.dll", EntryPoint = "IsWindows10RS3OrGreater", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsWindows10RS3OrGreater();

        /// <summary>
        /// Is Windows 10 Redstone 2 - Creators Update
        /// </summary>
        /// <returns></returns>
        [DllImport("PresentationNative_v0400.dll", EntryPoint = "IsWindows10RS2OrGreater", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsWindows10RS2OrGreater();

        /// <summary>
        /// Is Windows 10 Redstone 1 -
        /// </summary>
        /// <returns></returns>
        [DllImport("PresentationNative_v0400.dll", EntryPoint = "IsWindows10RS1OrGreater", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsWindows10RS1OrGreater();

        /// <summary>
        /// Is Windows 10 Threshold 2
        /// </summary>
        /// <returns></returns>
        [DllImport("PresentationNative_v0400.dll", EntryPoint = "IsWindows10TH2OrGreater", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsWindows10TH2OrGreater();

        /// <summary>
        /// Is Windows 10 Threshold 1
        /// </summary>
        /// <returns></returns>
        [DllImport("PresentationNative_v0400.dll", EntryPoint = "IsWindows10TH1OrGreater", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsWindows10TH1OrGreater();

        /// <summary>
        /// Is Windows 10
        /// </summary>
        /// <returns></returns>
        [DllImport("PresentationNative_v0400.dll", EntryPoint = "IsWindows10OrGreater", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsWindows10OrGreater();

        /// <summary>
        /// Is Windows 8.1 
        /// </summary>
        /// <returns></returns>
        [DllImport("PresentationNative_v0400.dll", EntryPoint = "IsWindows8Point1OrGreater", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsWindows8Point1OrGreater();

        /// <summary>
        /// Is Windows 8.0
        /// </summary>
        /// <returns></returns>
        [DllImport("PresentationNative_v0400.dll", EntryPoint = "IsWindows8OrGreater", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsWindows8OrGreater();

        /// <summary>
        /// Is Windows 7 Service Pack 1
        /// </summary>
        /// <returns></returns>
        [DllImport("PresentationNative_v0400.dll", EntryPoint = "IsWindows7SP1OrGreater", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsWindows7SP1OrGreater();

        /// <summary>
        /// Is Windows 7
        /// </summary>
        /// <returns></returns>
        [DllImport("PresentationNative_v0400.dll", EntryPoint = "IsWindows7OrGreater", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsWindows7OrGreater();

        /// <summary>
        /// Is Windows XP Service Pack 3
        /// </summary>
        /// <returns></returns>
        [DllImport("PresentationNative_v0400.dll", EntryPoint = "IsWindowsXPSP3OrGreater", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsWindowsXPSP3OrGreater();

        /// <summary>
        ///  Is Windows XP Service Pack 2
        /// </summary>
        /// <returns></returns>
        [DllImport("PresentationNative_v0400.dll", EntryPoint = "IsWindowsXPSP2OrGreater", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsWindowsXPSP2OrGreater();

        /// <summary>
        ///  Is Windows XP Service Pack 1
        /// </summary>
        /// <returns></returns>
        [DllImport("PresentationNative_v0400.dll", EntryPoint = "IsWindowsXPSP1OrGreater", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsWindowsXPSP1OrGreater();

        /// <summary>
        ///  Is Windows XP
        /// </summary>
        /// <returns></returns>
        [DllImport("PresentationNative_v0400.dll", EntryPoint = "IsWindowsXPOrGreater", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsWindowsXPOrGreater();

        /// <summary>
        /// Is Windows Server
        /// </summary>
        /// <returns></returns>
        [DllImport("PresentationNative_v0400.dll", EntryPoint = "IsWindowsServer", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsWindowsServer();

        /// <summary>
        /// GetSystemTimeAsFileTime
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="lpSystemTimeAsFileTime"></param>
        [DllImport("kernel32.dll", EntryPoint = "GetSystemTimeAsFileTime", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        internal static extern void GetSystemTimeAsFileTime(ref UnsafeNativeStructs.FILE_TIME lpSystemTimeAsFileTime);

        /// <summary>
        /// GetTickCount64
        /// </summary>
        /// <remarks>
        ///     Please use this only now !!!, 
        ///     the old GetTickCount, get a overflow after 49 days !!!.
        ///     
        ///     Microsoft Developer Description in SDK.
        /// </remarks>
        /// <returns>
        /// returned windows start in milliseconds
        /// </returns>
        [DllImport("kernel32.dll", EntryPoint = "GetTickCount64", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        internal static extern int GetTickCount64();
        
        /// <summary>
        /// Windows 10 Function ONLY !
        /// Is User an Administrator
        /// </summary>
        /// <returns></returns>
        [DllImport("shell32.dll", EntryPoint = "IsUserAnAdmin", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool IsUserAnAdmin();

        /// <summary>
        ///		Method MessageBoxTimeout
        /// </summary>
        /// <remarks>
        /// 	MessageBoxTimeout is a new Function in Windows Operation System at Windows 7.
        /// 	Is so implemened that he close automatic the MessageBox after Timeout Value !!!.
        ///		Same as Method from Jeffrey Richter - Inside Windows Programming Book -
        /// </remarks>
        /// <param name="WindowsHandle"></param>
        /// <param name="text">Your String</param>
        /// <param name="title">Your Title String</param>
        /// <param name="Style">Set here the compact Style</param>
        /// <param name="wLanguageId">Set here our constant LANG_NEUTRAL</param>
        /// <param name="milliseconds">
        /// Timeout Value in milliseconds, 
        /// after this Timeout close the MessageBox automatic
        /// without Useraction.
        /// </param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "MessageBoxTimeoutW", SetLastError = true, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        internal static extern int MessageBoxTimeout(IntPtr WindowsHandle,
                                                     [MarshalAs(UnmanagedType.LPWStr)]
                                                     string text,
                                                     [MarshalAs(UnmanagedType.LPWStr)]
                                                     string title,
                                                     uint Style,
                                                     ushort wLanguageId,
                                                     uint milliseconds);





        /// <summary>
        /// Use here Microsoft C Runtime Library 64 Bit Version !.
        /// exit, terminate process complete, call and caller.
        /// exit(errorcode); All in Windows SDK: All with begin ERROR_
        /// </summary>
        [DllImport("mscrt.dll", EntryPoint = "exit", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void VRLExit();
        

    }

} // End of namespace Visual.Registry.Library
