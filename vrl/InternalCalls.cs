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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// our famous Resource Library - pure Resources -
using Visual.Registry.Library.Properties;

// NO DIRECTIVE/ASSEMBLY
// Only our Namespace in this Project-Solution
using NativeMethods;


// <summary>
// All internal Calls in this Library,
// 
// [MethodImplAttribute(MethodImplOptions.InternalCall)]
// The Compile see it, and Common Language Runtime make implementation internal !.
// [MethodImpl(MethodImplOptions.AgressiveInline)]
// [MethodImpl(MethodImplOptions.NoInline)]
// </summary>
namespace Visual.Registry.Library.Internal
{
    /// <summary>
    /// ONLY for this Project-Solution - Internal Calls -
    /// 
    /// </summary>
    internal static class InternalCalls
    {

        /// <summary>
        /// Get integer value in milliseconds for systemstart.
        /// </summary>
        /// <remarks>
        /// [MethodImpl(MethodImplOptions.InternalCall)]
        /// MethodImplementationAttribute Options are:
        /// AggressiveInline, NoInlining, NoOptimization, Synchronized, InternalCall,
        /// ! ATTENTION ! The Compiler make your Method to inline, so you wan't this,
        /// set NoInlining.
        ///  Please use only this Function !,
        ///  the old GetTickCount have a Problem, he overflow after 49 Days!!!.
        /// </remarks>
        /// <returns>
        /// returned the integer value in Milliseconds.
        /// </returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static int TickCount()
        {
            return SafeNativeMethods.GetTickCount64();
           
        }

        /// <summary>
        /// Get the current Size of this given File
        /// </summary>
        /// <param name="FullFilePath">set the full filepath here !</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static long GetFileSize(String FullFilePath)
        {
            long size = 0;

            // using always with Exceptionhandling
            using (FileStream fs = new FileStream(FullFilePath, FileMode.Open))
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
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static bool CallConsole()
        {


            try
            {

                // set here registered Voice "time to registration"
                // Resource come from our famous Visual.Resource.Library.dll/Assembly - pure Resources !!! -
                // witout Class or Methods, only the Visual Studio Resource Manager insert class Resources.
                // using Visual.Resource.Library.Properties;
                // Setname = R came Resources.resourcename
                var t = new SoundPlayer(Resources.BACKSND);
                // play the sound wave (.wav)
                t.Play();

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
                Title = "Console App - Copyright © 2017 by Christian 'TIPPO' Kurs - Visual .NET - C# / C++ Developer.";



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
                WriteStartConsoleInfoLog();

                // stop the Soundplayer
                t.Stop();

                // ReadKey is now static written in System.Console
                // static method from Class Console
                ReadKey(true);
            }
            catch(Exception ex)
            {
                SafeNativeMethods.VFLMsgBox(ex.Message, "CallConsole Exception", UnsafeConstants.Style1);
                return false;
            }

            return true;

        } // END OF METHOD CallConsole
            
        /// <summary>
        /// Write Start Console Block
        /// </summary>
        /// <returns></returns>
        internal static bool WriteStartConsoleInfoLog()
        {
            try
            {
                //---------------------------------------------------------------------------------------------------------------------------------------
                // @ unicode sign for slashs, so you set only one slash
                //
                // set here for write all relevant Information into Log File.
                // other you must set two backward slashes
                // url's the same: normal ..\\\.\\
                // with @ : \\.\
                //---------------------------------------------------------------------------------------------------------------------------------------
                string path = @"C:\Users\TIPPO\Software Creative Production\Project_Programming\Secret1\Secret1\bin\x64\Debug\ConsoleSecretLog.syslog";
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
                sw.WriteLine("Special Library: Visual.Resource.Library.dll:\n");
                sw.WriteLine("Special Library: Visual.Function.Library.dll:\n");
                sw.WriteLine("Special Library: Visual.Security.Library.dll:\n");
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
                SafeNativeMethods.VFLMsgBox(ex.Message, "Exception at write the SecretLog !", UnsafeConstants.Style1);
                return false;
            }

            return true;

        } // END OF METHOD WriteStartConsoleInfoLog




    } // END OF CLASS InternalCalls

} // END OF NAMESPACE Visual.Registry.Library.Internal
