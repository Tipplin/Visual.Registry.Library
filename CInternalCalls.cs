/*********************************************************************************
*	Copyright © 2017 - 2021 by VGF-KernelTeam and Christian 'Tipplin' Kurs.
*			All Rights Reserved.
*
*********************************************************************************/
/*
    This software is the confidential and proprietary information of
    VGF-KernelTeam - ("Confidential Information").  You shall not
    disclose such Confidential Information and shall use it only in
    accordance with the terms of the License Agreement you entered into
    with VGF-KernelTeam.

    VGF-KERNELTEAM MAKES NO REPRESENTATIONS OR WARRANTIES ABOUT THE SUITABILITY OF
    THE SOFTWARE, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
    IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
    PURPOSE, OR NON-INFRINGEMENT.

    VGF-KERNELTEAM SHALL NOT BE LIABLE FOR ANY DAMAGES
    SUFFERED BY LICENSEE AS A RESULT OF USING, MODIFYING OR
    DISTRIBUTING THIS SOFTWARE OR ITS DERIVATIVES.

    Copyright_Version_1.0_BETA

    This file is the same as x that comes with y,
    except that the has been changed so that it is compilable
    under more than just
*/

/**************************************************************************************************
    MAC, macOS, watchOS, tvOS is a registered trademark of Apple Computer, Inc. 
    iOS is a registered trademark of Cisco Cor.
    Intel is a registered trademark of Intel Corporation. 

    Active Desktop, ActiveX, Authenticode, BackOffice, FoxPro, FrontPage, 
    Visual Studio, Jscript, Microsoft, Microsoft Press, MSDN, MS-DOS, MSN, 
    Outlook, PivotTable, PowerPoint, Visual Basic, Visual C++, Visual FoxPro, 
    Visual InterDev, Visual J++, J#, Visual Studio, Win32, Windows, 
    and Windows NT are either registered trademarks or 
    trademarks of Microsoft Corporation in the United States and/or other countries.
    -----------------------------------------------------------------------------------------------
    ! ATTENTION ! write for Export ! 
    This software is subject to the U.S. Export Administration Regulations and 
    other U.S. law, and may not be exported or re-exported to certain countries 
    ( Cuba, Iran, North Korea, Sudan, Syria, and the Crimea region of Ukraine) or 
    to persons or entities prohibited from receiving U.S. exports 
    (including Denied Parties, Specially Designated Nationals, 
    and entities on the Bureau of Export Administration Entity List or 
    involved with missile technology or nuclear, chemical or biological weapons).

    © 1982 - 2021 Microsoft Corporation. All rights reserved.

****************************************************************************************************/


// Set here in us Directives all other are light grayed NOT in use!
// Build run the Compiler delete this, and comments, NOT in use varaibles and more...!
using System;
using System.IO;

// using static new all written static, class, Methods and more...
// so you can use directly the Methods !!!.
using static System.Console;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading;
using System.Security;
using System.Runtime.Versioning;
using System.Security.Permissions;
using System.Security.Principal;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Visual.Registry.Library;

// our famous Resource Library - pure Resources -
using Visual.Registry.Library.Properties;


using static Visual.Registry.Library.VRLBase;



/*
 * Forgotten / slash is Error invalid global code
/ !NOTE! NOT an Assembly/Directive, 
// is other namespace in this Project-Solution and Visual C# File:
// InternalCalls.cs

*/

using static Visual.Registry.Library.Internal.VRLInternalCalls.VRLDataFormat;

using static Visual.Operation.System.Internal.InternalUtilities.VOSInternalUtilities;

using static Visual.Operation.System.Native.NativeMethods;

using static Visual.Operation.System.Native.NativeRuntimeMethods;


using static Visual.Operation.System.Native.UnsafeNativeMethods;


using static Visual.Operation.System.Internal.InternalOSMethods;




/* namespace from Assembly Visual.Operation.System.dll
 * All relevant Operation System Functionalty:
 * Check Windows Operation System and Version Major, Minor, Build, Revision
 */
using Visual.Operation.System.Internal;

using Microsoft.Win32;






/*-----------------------------------------------------------------------------
 * All internal Calls in this Library,
 *-----------------------------------------------------------------------------
 * [MethodImplAttribute(MethodImplOptions.InternalCall)]
 * The Compile see it, and Common Language Runtime make implementation internal.
 * [MethodImpl(MethodImplOptions.AgressiveInline)]
 * [MethodImpl(MethodImplOptions.NoInline)]
 * 
 *------------------------------------------------------------------------------
*/
namespace Visual.Registry.Library.Internal
{
    /// <summary>
    /// ONLY for this Project-Solution - Internal Calls -
    /// </summary>
    /// <!-- Author Tipplin -->
    /// 
    /// <!-- Author Tipplin -->
    /// <remarks>
    /// 
    /// </remarks>
    internal static class VRLInternalCalls
    {

        /*---------------------------------------------------------------------
         * Set here all Members internal static, 
         * for Global Use in Classes and Methods...
         * Instance for Registry Key with instancevariable ndpKey.
         * 
         * --------------------------------------------------------------------
         * HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.5
         * Key's:
         * InstallPath
         * C:\Windows\Microsoft.NET\Framework64\v3.5\
         * Version
         * 3.5.30729.4926
         * 
         * --------------------------------------------------------------------
         * HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4
         * .NET Framework 4.8.03752
         * Key's:
         * C:\Windows\Microsoft.NET\Framework64\v4.0.30319\
         * Release decimal 528040 hexadecimal 80ea8
         * TragetVersion 4.0.0
         * Version 4.8.03752
         * --------------------------------------------------------------------
         * HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion
         * Windows Operation System Compiled at 18.03.2019 12:02
         * Key's
         * BuildLab
         * 18362.19h1_release.190318-1202
         * UBR 
         * decimal 145 hexadecimal 91 means the Revisionnumber
         * EditionID 
         * Professional
         * ReleaseID
         * 1903
         * CurrentBuild
         * 18362
         * BuildBranch
         * 19h1_release
         * 
         * --------------------------------------------------------------------
         * HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\RemoteRegistry
         * DisableIdleStop after install 0
         * --------------------------------------------------------------------
         * C:\Windows\SystemApps\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\MicrosoftEdgeCP.exe
         * 
         *---------------------------------------------------------------------
         */

        /// <summary>
        /// SDataFormat for all .suffixes we can use,
        /// and own .suffixes, at Windows 10 all .suffixes free - Limit 255 Chars.
        /// Windows 10 with a new FileSystem for this, associations and asigns.
        /// Windows 10 Tool - assoc.exe - can see all associations.
        /// Microsoft Database Access new suffix is .accdb older .mdb
        /// .accdb=Access.Application.16
        /// (TIPPOTIP: For StartUp's at Begin the Microsoft Access 16 is good, Users: 255, Highest Database Size: 
        /// Windows Essential Server 2017 - 500 $ - Users:  Devices: , License incl. - No special CAL !)
        /// filename.appconfig
        /// prefix.suffix
        /// <!-- Author TIPPO 🧑 -->
        /// Tippo have convert to Visual C#, source form Andreas Maslo in VB.NET
        /// <!-- Author TIPPO 🧑 -->
        /// 
        /// </summary>
        internal enum VRLDataFormat
        {
            /* All .NET Configruation Files are XML-Files manage with .NET Framework and Class ConfigurationManager
            * Section: add, delete, change
            * All can crypted the Configration File, unauthorized use! (ASP.NET Security Class)
            * 
            * ! own long .suffixes now allowed in .NET, now set your own suffixes - limit 255 chars !
            * prefix.suffix - filename.own-suffix
            * for Windows 10 tell him this suffix in the tool assoc.exe - file associations
            * .dll=dllfile - my association for file library and suffix .dllfile
            */

            appconfig,                  // user application configuratin file
            netconfig,                  // network configuratin file
            serverconfig,               // server configuratin file - one server or more servernames
            sqlqueryconfig,             // MS SQL Server Queries configuratin file
            binary,
            soap,
            xml,
            json,
            binaryCompressed,
            soapCompressed,
            binaryCrypted,
            binaryCompressedCrypted,
            txt,
            config,                     // XML File for App, Web, Machine and User.config
                                        // use with class Configuration Manager from .NET Framework
                                        // add, delete, change...
                                        // own .config's: appname.appconfig - user profile file
                                        // prefix.suffix = filename.suffix is free. (both Limit 255 chars!)
                                        // Idea: network.config, server.config (all servernames, adresses URL's...)
                                        // .config (ASP.NET) can crypt the Configuration File - For foreign no access! and is secure!
                                        //
            dat,                        // performance information files
            bin,                        // you want no that foreign change your files, create .bin - Setup.bin
                                        // Setup.bin by Windows 10 Operation System - one part is crypt, 
                                        // GUID's for Windows Operation System - Windows XP to Windows 10 -
            log                         // .log - logging for anything you want!
                                        // International ISO SRP - want the Log-Method is global in Project!,
                                        // for all Classes and Methods.
        }

        /// <summary>
        /// Add Text into File Stream
        /// </summary>
        /// <param name="fs">FileStream Name</param>
        /// <param name="value">Text</param>
        internal static void VRLAddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        /// <summary>
        /// Create Filename with Prefix and Suffix
        /// </summary>
        /// <!-- Author TIPPO -->
        /// Tippo have convert to Visual C#, source form Andreas Maslo in VB.NET
        /// <!-- Author TIPPO -->
        /// <param name="FullPathFileName">Given Filename</param>
        /// <returns></returns>
        internal static string VRLCreateFileNamePrefixSuffix(string FullPathFileName)
        {
            
            string path = FullPathFileName;

            // Delete the file if it exists.
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            //Create the file.
            using (FileStream fs = File.Create(path))
            {
                /*
                AddText(fs, "This is some text");
                AddText(fs, "This is some more text,");
                AddText(fs, "\r\nand this is on a new line");
                AddText(fs, "\r\n\r\nThe following is a subset of characters:\r\n");

                for (int i = 1; i < 120; i++)
                {
                    AddText(fs, Convert.ToChar(i).ToString());

                }
                */

               return string.Format("{0}.{1}", fs.Name, VRLSuffixByDataFormat(VRLDataFormat.txt)); 

            }
        }

        /// <summary>
        ///   Take suffix to Filename, suffixes come from Enumerator
        /// </summary>
        /// 
        /// <!-- Author TIPPO -->
        /// Tippo have convert to Visual C#, source form Andreas Maslo in VB.NET
        /// <!-- Author TIPPO -->
        /// 
        /// <param name="v">choice your suffix</param>
        /// <remarks>
        /// Have write standard suffixes here !
        /// 
        /// You can write your own .suffixes (Win Limit 255 chars - .xxxxxxxxx)
        /// Windows 10 New File System and Association to Files, means Prefix and Suffix
        /// .accdb=Access.Application.16 (microsoft Access 16)
        /// Microsoft change the suffix by Access from .mdb to .accessdb
        /// 
        /// TIPPO: 
        /// appname.appconfig for user profile file.
        /// 
        /// want save at Microsoft Texteditor:
        /// Filename - your favorite name and suffix - 255 chars limit - tip: .xxxxx alpha and numeric letter or datetimestamp
        /// Filetype - *.txt is standard change to all files in combobox !
        /// 
        /// Coding
        /// ansi
        /// unicode
        /// unicode big endian
        /// UTF8---------------> TIPPO TIP ! For Germany is better with German 'Umlauts' - Rules: Dr.Knittel CBM
        /// ----------------------------------------------------------------------------------------------------
        /// German 'Umlauts' Germany, Switzerland, Austria
        /// .NET Framework have the Two Letters ISO:
        /// For Germany: de-DE
        /// German Dialect as Three Letter ISO: 
        /// Sorbish - wen-den 
        /// (and boennsch from Tippo: bon-den)
        /// ----------------------------------------------------------------------------------------------------
        /// CLR - Common Language Runtime in/out with UTF16.
        /// (UTF8, UTF16 and UTF32 only for algorithmen)
        /// ----------------------------------------------------------------------------------------------------
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        internal static string VRLSuffixByDataFormat(VRLDataFormat v)
        {
            switch(v)
            {
                // all allowed yet at Windows 10 File System, own suffixes
                // all Configuration File like XML standard, manage with .NET Framework and Class ConfigurationManager
                // set entries, add, delete, change
                // and crypted the Configuration File for unauthorized use...
                // Idea for Application Configuration File
                case VRLDataFormat.appconfig:
                    return ".appconfig";
                // Idea for Network Configuration File
                case VRLDataFormat.netconfig:
                    return ".netconfig";
                // Idea for Server Configuration File for all Server at Company
                case VRLDataFormat.serverconfig:
                    return ".serverconfig";
                // Idea for SQL Queries like Microsoft SQL Server inside - SQL Query table
                // Microsotf SQL Server have inside .NET - write stored procedure and he show if .NET is active
                // Microsoft SQL Development Studio and Template for Visual C#.
                // Templates: create a database
                // In Visual C# project: using Microsoft.SQLServer.Client.dll...
                case VRLDataFormat.sqlqueryconfig:
                    return ".sqlqueryconfig";
                case VRLDataFormat.bin:
                    return ".bin";
                case VRLDataFormat.binary:
                    return ".binary";
                case VRLDataFormat.binaryCompressed:
                    return ".binaryCompressed";
                case VRLDataFormat.binaryCompressedCrypted:
                    return ".binaryCompressedCrypted";
                case VRLDataFormat.binaryCrypted:
                    return ".binaryCrypted";
                case VRLDataFormat.config:
                    return ".config";
                case VRLDataFormat.dat:
                    return ".dat";
                case VRLDataFormat.json:
                    return ".json";
                case VRLDataFormat.log:
                    return ".log";
                case VRLDataFormat.soap:
                    return ".soap";
                case VRLDataFormat.soapCompressed:
                    return ".soapCompressed";
                case VRLDataFormat.txt:
                    return ".txt";
                case VRLDataFormat.xml:
                    return ".xml";
                default:
                    return "Not in Enumerator!";
            }
        }





        /// <summary>
        /// Get integer value in milliseconds for systemstart.
        /// write new TickCount for all developer
        /// </summary>
        /// <!-- Author TIPPO -->
        /// Create NEW TickCount, 
        /// while old TickCount make overflow after 49 days (source: Microsoft Developer),
        /// the function is GetTickCount64 from Windows Operation System.
        /// <!-- Author TIPPO -->
        /// <remarks>
        /// [MethodImpl(MethodImplOptions.InternalCall)]
        /// This InternalCall Methods implement into Common Language Runtime.
        /// MethodImplementationAttribute Options are:
        /// AggressiveInline, NoInlining, NoOptimization, Synchronized, InternalCall,
        /// 
        /// ! ATTENTION ! The Compiler make your Method to inline, so you wan't this,
        ///  set NoInlining.
        ///  Microsoft Developer Site:
        ///  Please use only this Function !,
        ///  the old GetTickCount() have a Problem, he overflow after 49 Days!!!.
        /// </remarks>
        /// <returns>
        /// returned the integer value in Milliseconds.
        /// </returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static ulong VRLTickCount()
        {
            // GetTickCount64(); is better! as GetTickCount();
            return GetTickCount64();
        }

        /// <summary>
        /// Get the current Size of this given File
        /// </summary>
        /// <param name="FullFilePath">set the full filepath here !</param>
        /// <!-- Author TIPPO -->
        /// Create same System-Methods for Visual.Galaxy.Framework
        /// <!-- Author TIPPO -->
        /// <remarks>
        /// Solution here with .NET and C#,
        /// Windows OS have in Headerfile x GetFileSize(handle);
        /// </remarks>
        /// <returns>
        /// returned File Size
        /// </returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static long VRLGetFileSize(String FullFilePath)
        {
            long size = 0;

            // using always with Exceptionhandling
            using (var fs = new FileStream(FullFilePath, FileMode.Open))
            {
                size = fs.Length;
            }

            return size;

        }

        /// <summary>
        /// CallConsole for many Information to User.
        /// The Console Window in Windows 10 is NEW written,
        /// is a full legal application now,
        /// with Class, Methods and more,
        /// Offical: Windows 10 Operation System Window
        /// Little overhead, faster as a Form.
        /// Settings directly active.
        /// Sets: Colors (Background, Font), Size, Title and more...
        /// insert code for a Log-file at begin.
        /// </summary>
        /// <!-- Author TIPPO -->
        /// Create same System-Methods for Visual.Galaxy.Framework
        /// <!-- Author TIPPO --> 
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static bool VRLCallConsoleWindow()
        {


            try
            {

                // set here registered Voice "time to registration"
                // Resource come from our famous Visual.Resource.Library.dll/Assembly - pure Resources !!! -
                // witout Class or Methods, only the Visual Studio Resource Manager insert class Resources.
                // using Visual.Resource.Library.Properties;
                // Setname = R came Resources.resourcename
                //var t = new SoundPlayer(Resources.BACKSND);
                // play the sound wave (.wav)
                //t.Play();

                //------------------- Console Window Settings ----------------------------------------

                // Delete show Information in ConsoleBuffer to Console Window
                // static method from Class Console
                Clear();

                // Change new BackgroundColor to BLUE
                // static method from Class Console
                // but set the Color you must set the enumerator ConsoleColor
                BackgroundColor = ConsoleColor.Blue;



                // Delete show Information in ConsoleBuffer to Console Window
                // static method from Class Console
                Clear();

                // Set out Console Window Title
                // static method from Class Console
                Title = "Console App - Copyright © 2018 by Christian 'TIPPO' Kurs - Visual .NET - C# / C++ Developer.";



                //------------------- Call Extern Native Functions, our Visual.function.Library.dll pure C Functions ------------------

                // External from Visual.Function.Library.dll- pure -C- Functions - same Parts of Operation System - Windows -
                // Insert with [DLLImportAttribute] - see ExternalNativeFunctions.cs
                // This MessageBox only parameter TextID - Internal CHAR Text Array. - define 1 to 20.
                // 999 No text - Only Message unknown.
                //vgfVFLMessageBox(1);

                // External from Visual.Function.Library.dll - pure -C- Functions - same Parts of Operation System - Windows -
                // .NET have only one Beep without Frequency and duration.
                //Extern_Native_Functions.vgfVFLMultiBeep(800, 2000);

                //-------------------- set here Form specified ------------------------------------------------------------------------



                // Set ForegroundColor WHITE for Font !
                ForegroundColor = ConsoleColor.White;


                // WriteLine is now static written in System.Console
                WriteLine("\n\n\n");
                WriteLine("\t\t\tWrite all Application Settings in the registry for you !.\n\n");
                WriteLine("\t\t\t\n");
                WriteLine("\t\t\tCopyright © 2017 by Christian 'TIPPO' Kurs - VGF-Kernel-Team\n\n\n");
                // Hold Thread here 8 seconds and than continue the Thread.
                // Thread.Sleep is syncron - Task.Delay is asyncron!
                // Thread.Sleep(2000 * CallMethod or MessageBox(...) );
                // The sign * is operator Asteric, nach sleep 2 Second he continue the Thread and calls the Method or MessageBox.
                // Thread.Sleep as Timer, he stop the Thread with TimeInterval continue.
                // Alternate: many Timers in .NET Framework without Control.
                // timer(Call, parameter, starttimer, timerinterval);
                // timer(Methodname, 0, 1, 5000)
                // Third Parameter start the Timer, any 5 Second he calls the Method.
                // DON'T FORGET ! timer.stop - runs continue, program-end.
                // Class Vibrator in (WIN)Phone API, Vibration - DON'T FORGET Vibrator.stop !
                Thread.Sleep(2000);

                // For urgent messages set Color to RED
                // static method from Class Console
                ForegroundColor = ConsoleColor.Green;

                Write("\t\t\tDone. All Datas into Registry written.\n\n");
                Write("\t\t\tThis File is secure for access ! Only read Data ! NO more!.\n");
                Write("\t\t\tInside File Access Rights System active !.\n\n");
                Write("\t\t\tNOTE: System-Administrator can set for him Fullcontrol.\n\n");

                // OK ! - For end set Color on GREEN
                // static method from Class Console
                ForegroundColor = ConsoleColor.White;

                Write("\t\t\tSpecial Library bind in: Visual.Function.Library.dll\n\n");
                Write("\t\t\tCopyright (c) 2017 by Christian 'TIPPO' Kurs - Visual .NET - C# / C++ Senior Developer.\n");
                Write("\t\t\tPortions Copyright (c) 2017 by Microsoft Corporation.\n\n\n");

                // write all information into Log-file
                // internal call for Log-File
                VRLWriteStartConsoleInfoLog();

                // stop the Soundplayer
                //t.Stop();

                // ReadKey is now static written in System.Console
                // static method from Class Console
                ReadKey(true);
            }
            catch(Exception ex)
            {
                VFLMsgBox(ex.Message, "CallConsole Exception", STYLES.OkOnly | STYLES.Critical | STYLES.MsgBoxSetForeground | STYLES.SystemModal);
                return false;
            }

            return true;

        } // END OF METHOD CallConsole

        /// <summary>
        /// Write Start Console Block
        /// </summary>
        /// <!-- Author TIPPO -->
        /// Create same System-Methods for Visual.Galaxy.Framework
        /// <!-- Author TIPPO --> 
        /// <returns></returns>
        internal static bool VRLWriteStartConsoleInfoLog()
        {
            try
            {
                
                //-----------------------------------------------------------------------------------------------------
                // Set FileStream for LogFile with open, create and append, you see the operator | that's allowed !
                // than FileStream have only two parameters !, the second is MODE !.
                // have forgotten FileMode.Append, than he override everytime! old text.
                //-----------------------------------------------------------------------------------------------------
                var sb = new FileStream(path, FileMode.OpenOrCreate | FileMode.Append);

                //-----------------------------------------------------------------------------------------------------
                // StreamWriter for the strings to write into Stream.
                //-----------------------------------------------------------------------------------------------------
                var sw = new StreamWriter(sb);

                //-----------------------------------------------------------------------------------------------------
                // Here have a Query, System Class Enviroment and Method ExpandEnviromentVariables();
                // Here %SystemDrive% and %SystemRoot%, 
                // in Visual C# Placeholder change the %Placeholder% to string str set him in field.
                //-----------------------------------------------------------------------------------------------------
                String query = "you system drive is %SystemDrive% \nand you system root is %SystemRoot%";
                String str = Environment.ExpandEnvironmentVariables(query);

                sw.WriteLine("=====================================================\n");
                sw.WriteLine("\r\nWrite-Start-Console-Info-System-Log--- Entry ---:\n\n");
                sw.WriteLine("=====================================================\n\n");
                //-------------------------------------------------------------------------------------------------------
                // DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString() as local Time in your Country.
                // using UTC and ISO - ISO Zwo Letters for Countries - en-US = USA, de-DE = Germany,
                // en -UK = United Kingdom
                // next can use string.Format for more options, Time, Date, Timezone(calculated -/+), 
                // Science, Percent, Currency,
                //--------------------------------------------------------------------------------------------------------
                sw.WriteLine("Date: {0} - Time: {1}\n", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
                sw.WriteLine("\r\nUsername: {0}\n", Environment.UserName);
                sw.WriteLine("Computername: {0}\n", Environment.MachineName);
                sw.WriteLine("Is64BIT-OS: {0}\n", Environment.Is64BitOperatingSystem);
                sw.WriteLine("System Enviroment Ouery: {0}\n", str);
                sw.WriteLine("Logical Drives: {0}\n", Environment.GetLogicalDrives());
                sw.WriteLine("Exit-Code means the End of Program - 0 successfully end - 1 - failure at End\n");
                sw.WriteLine("Main Exit-Code: {0}\n", Environment.ExitCode.ToString());
                sw.WriteLine("User Domain Name: {0}\n", Environment.UserDomainName);
                sw.WriteLine("Processor(s) inside current Machine: {0}\n", Environment.ProcessorCount);
                sw.WriteLine("Current Directory: {0}\n", Environment.CurrentDirectory);
                sw.WriteLine("Is a 64BIT Process run: {0}\n", Environment.Is64BitProcess);
                sw.WriteLine("Is Version Major: {0}\n", Environment.OSVersion.VersionString);
                sw.WriteLine("------------------------------------------------------------------------------");
                sw.WriteLine("Special Library: Visual.Resource.Library.dll:\n");
                sw.WriteLine("Special Library: Visual.Function.Library.dll:\n");
                sw.WriteLine("Special Library: Visual.Security.Library.dll:\n");
                sw.WriteLine("------------------------------------------------------------------------------");

                //--------------------------------------------------------------------------------------------------------
                // Flush write complete stream into File !!!
                //--------------------------------------------------------------------------------------------------------
                sw.Flush();

                //--------------------------------------------------------------------------------------------------------
                // Close everytime at end !!!, NOT reverse!!!.
                //--------------------------------------------------------------------------------------------------------
                sw.Close();
            }
            catch (Exception ex)
            {
                VFLMsgBox(ex.Message, "Exception at write the SecretLog !", STYLES.OkOnly | STYLES.Critical | STYLES.MsgBoxSetForeground | STYLES.SystemModal);
                return false;
            }

            return true;

        } // END OF METHOD WriteStartConsoleInfoLog

        /// <summary>
        /// Creates a new PasswordAuthentication object from the given user name and password. 
        /// Note that the given user password is cloned before it is stored in the new PasswordAuthentication object.
        /// </summary>
        /// <!-- Author Tipplin 🧑 -->
        /// 
        /// <!-- Author Tipplin 🧑 -->
        /// <param name="userName"></param>
        /// <param name="password"></param>
        internal static string VRLPasswordAuthentication​(String userName, char[] password)
        {
            // In Visual C# allowed return bool as string true or false,
            // bool normal 0 or 1
            return false.ToString();
        }

        /// <summary>
        /// Is Administrator on this Computer with unrestricted Access.
        /// </summary>
        /// <!-- Author Tipplin 🧑 -->
        /// Windows 10 (Professional) is a Multi User System, One User or more
        /// on one Computer, the Admin or Account Operator add new Users,
        /// User Account with/without Foto and Name - Windows 10 Sign In Screen -
        /// (next Update 19H1, with Fluent Design System and Acrylic)
        /// Administrators have Full Rights in Windows 10 Operation System,
        /// NOT Users!, Windows 10 can lock same Folders on System.
        /// <!-- Author Tipplin 🧑 -->
        /// <returns>
        /// true, wenn die aktuelle Berechtigung uneingeschränkt ist, andernfalls false.
        /// </returns>
        internal static bool VRLIsAdminOnThisComputerUnrestricted()
        {
            //
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            
            //---------------------------------------------------------------------------
            // Windows 10 Professional edition is an Workstation with more Tools,
            // Net policy Wizard an command line tool: 
            // netplwiz.exe with User/Groups Editor
            // NOTE: ONLY an Administrator have full access on an Computer,
            // Users have not all accesses.
            // So Windows 10 denied same Folders.
            //---------------------------------------------------------------------------
            // Principal Accounts Roles(Windows Membership):
            // Windows Operation System BASE:
            // AccountOperator
            // Administrator
            // Users
            // PowerUsers
            // Guest
            // BackupOperator
            // PrintOperator
            //-----------------------------------------------------------------
            // Windows 10 (most come with the newest updates):
            // ! Windows 10 install base system .cabs but NOT all Features!.
            // System .cabs hidden in System Folder.
            // Want install all?
            // App & Features--> Programme & Features -->
            // Windows Features actived/deactived
            //-----------------------------------------------------------------
            // Administrator
            // Users
            // Distributed COM - Users
            // Eventsprotocol reader
            // Guest
            // User
            // Hyper - V - Administrator
            // IIS_IUSRS------------------------> IIS is Microsoft own Web Server
            // Cryptografy - Operator
            // Performance Protocol User
            // Leistungsüberwachungsbenutzer
            // NetworkConfiguration - Operators
            // Remotedesktopbenutzer
            // Remoteverwaltungsbenutzer
            // Replications - Operator
            // Backup - Operators
            // Ssh Users
            // System Managed Accounts Group
            // WmsOperators
            // Access Control - SupportOperators
            //
            //
            //
            PrincipalPermission principalPerm = new PrincipalPermission(null, "Administrators");

            // return true/false is the Administrators Restricted/Unrestricted Access on Computer
            return principalPerm.IsUnrestricted();
        }

        /// <summary>
        /// Get .Net Framework Release Versionnumber installed
        /// </summary>
        /// <!-- Author TIPPO -->
        /// 
        /// <!-- Author TIPPO -->
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>
        /// 
        /// </returns>
        internal static int VRLGetNetFXReleaseVersion()
        {
            int result = 0;
           
            try
            {

                if (ndpKey == null)
                {
                    return result;
                }
                object value = ndpKey2.GetValue("Release");
                if (value == null)
                {
                    return result;
                }
                result = Convert.ToInt32(value);
                return result;
            }
            // see the new catch and filter: more than one Exception class can set, like Java
            catch (Exception ex) when (ex is SecurityException || ex is ObjectDisposedException || ex is IOException || ex is UnauthorizedAccessException || ex is FormatException || ex is OverflowException)
            {
                return result;
            }

        } // END of Method::GetNetFXReleaseVersion


       




    } // END OF CLASS InternalCalls

} // END OF NAMESPACE Visual.Registry.Library.Internal
  /*-----------------------------------------------------------------------------
    * END::OF::FILE::CInternalCalls.cs
    *-----------------------------------------------------------------------------
    */
