using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace KTLog
{
    /// <summary>
    /// 
    /// </summary>
    public static class KtLog
    {
        public static readonly string BoilerPlate = $"{DateTime.Now} -";
        public static ConsoleColor warningColor = ConsoleColor.Yellow;
        public static ConsoleColor errorColor = ConsoleColor.Red;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public static void Log(string message)
        {
            Console.WriteLine(
                $"{BoilerPlate} Message: {message}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="caller"></param>
        /// <param name="fileOrigin"></param>
        /// <param name="lineNumber"></param>
        public static void LogWarning(Exception ex, [CallerMemberName] string caller = "",
            [CallerFilePath] string fileOrigin = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            Console.ForegroundColor = warningColor;
            Console.WriteLine(
                $"{BoilerPlate} Method: {caller} Exception: {ex.GetType()}\n{ex.Message}\nFilename: {fileOrigin} Line:{lineNumber.ToString()}");
            Console.ResetColor();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="caller"></param>
        /// <param name="fileOrigin"></param>
        /// <param name="lineNumber"></param>
        public static void LogCrash(Exception ex, [CallerMemberName] string caller = "",
            [CallerFilePath] string fileOrigin = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            Console.ForegroundColor = errorColor;
            Console.WriteLine(
                $"{BoilerPlate} Method: {caller} Exception: {ex.GetType()}\n{ex.Message}\nFilename: {fileOrigin} Line:{lineNumber.ToString()}");
            Console.ResetColor();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caller"></param>
        [Conditional("DEBUG")]
        public static void LogStart([CallerMemberName] string caller = "")
        {
            Console.WriteLine($"{BoilerPlate} Method: {caller} started.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caller"></param>
        [Conditional("DEBUG")]
        public static void LogEnd([CallerMemberName] string caller = "")
        {
            Console.WriteLine($"{BoilerPlate} Method: {caller} ended.");
        }

        [Conditional("DEBUG")]
        public static void SignPost([CallerMemberName] string caller = "", [CallerFilePath] string path = "",
            [CallerLineNumber] int lineNum = 0)
        {
            Console.WriteLine($"{BoilerPlate} Signpost File: {Path.GetFileName(path)} Line: {lineNum}");
            
        }
    }
}