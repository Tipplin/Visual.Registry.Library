//#############################################################################
//
// Project		:	Visual.Galaxy.Framework
//
//-----------------------------------------------------------------------------
// Programmer	:	Christian "Tipplin" Kurs
//-----------------------------------------------------------------------------
// Part         :	Visual.Registry.Library
//-----------------------------------------------------------------------------
// Base Class	:	VRLBase
//-----------------------------------------------------------------------------
// Class-File   :   VRLBase.cs is static written, so for all Files in Project.
//-----------------------------------------------------------------------------
// Assist       :   Automatic Versions Setting
//              :   Major, Minor, Build, Revision
//              :   increment always at build run - compile -
//              :   but in Project only build and revision
//              :   set build option, so he show the complete Build-Run
//              :   Build-Run Log in Project-Directory: Projectname.log
//-----------------------------------------------------------------------------
// Specials     :   Change Platform to .NET Framework 4.7.2 !!!
//              :
//              :
//------------------------------------------------------------------------------
// Copyright © 2017 - 2021, 
// by Visual Galaxy Framework Community Kernel Developer Team
//
// by Head-Author: Christian "TIPPO" Kurs - Visual C# Senior Developer
// Portions Copyright © 1982-2021 by Microsoft Corporation GmbH.
//
// Same sourcecode by Microsoft, so we marked with Copyright !.
// © 1982 - 2021 - Copyrights by Microsoft: Images, Icons, Signs, Gadgets, 
// Copyright © and Tradewark by Microsoft Windows, Windows Logo, Visual Studio
// ----------------------------------------------------------------------------
//-----------------------------------------------------------------------------
//
// written by 		Christian "Tipplin" Kurs
// 				    Ahornweg 1
//					-G - 53177 Bonn 
//					Germany - Allemagne - Duitsland
//-----------------------------------------------------------------------------
//					mobile              :   0049 173 4593440
//					Skype				:
//					e-mail				:	kurschristian@gmail.de
//					my Website Community:	http://www.vgfc.org/community/tippo
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



#region ### System namespaces - parts with static and without ###

/*
 * Use System namespace with static class, don't forget the static after using.
 * 
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

#region ### Windows namespaces ###

#endregion

#region ### Microsoft namespaces ###

using Microsoft.Win32;

#endregion

namespace Visual.Registry.Library
{
    internal static class VRLBase
    {
        #region ### Global Class Instances here for all Methods in Class ###

        #region ### Class Registrykey Instances with Paths ###
        
        // In Visual C# allowed constants, instance set into Class Header
        // opening the registry-key on local machine, our system-settings
        // write using block, so we safe exception-handling
        // now in using block inside the try/catch block.
        internal static RegistryKey RegKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Software Creative Production\System\VFL\LICENSE");


        // Opening the Registry first and the specifies Key CurrentVersion
        // All Windows 10 Informations inside and UBR for the Revisionnumber in datatype DWORD.
        internal static RegistryKey registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion");

        // Opens the registry key for the .NET Framework entry.
        internal static RegistryKey ndpKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, Environment.MachineName).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\");

        internal static RegistryKey ndpKey2 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\");

        #endregion

        #region ### Log-Files with Paths ###
        //---------------------------------------------------------------------------------------------------------------------------------------
        // @ unicode sign for slashs, so you set only one slash
        //
        // set here for write all relevant Information into Log File.
        // other you must set two backward slashes
        // url's the same: normal ..\\\.\\
        // with @ : \\.\
        //---------------------------------------------------------------------------------------------------------------------------------------
        internal static string path = @"C:\Users\TIPPO\Software Creative Production\Project_Programming\Secret1\Secret1\bin\x64\Debug\ConsoleSecretLog.syslog";

        // Lock all registry actions in this Log-File
        internal static string reglogpath = @"C:\Users\TIPPO\Software Creative Production\Project_Programming\Secret1\Secret1\bin\x64\Debug\RegistryLog.reglog";


        #endregion


        #region ### Class Instances with instancevariables ###
        //-----------------------------------------------------------------------------------------------------
        // Set FileStream for LogFile with open, create and append, you see the operator | that's allowed !
        // than FileStream have only two parameters !, the second is MODE !.
        // have forgotten FileMode.Append, than he override everytime! old text.
        //-----------------------------------------------------------------------------------------------------
        internal static FileStream sb = new FileStream(path, FileMode.OpenOrCreate | FileMode.Append);

        //-----------------------------------------------------------------------------------------------------
        // StreamWriter for the strings to write into Stream.
        //-----------------------------------------------------------------------------------------------------
        internal static StreamWriter sw = new StreamWriter(sb);


        #endregion

        #endregion











    }

}
