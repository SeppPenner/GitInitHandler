// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company = "Hämmer Electronics" >
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The main program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GitInitHandler
{
    using System;
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// The main program.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main method.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    return;
                }

                var path = Path.GetDirectoryName(args[0]);
                var process = new Process();

                if (path == null)
                {
                    return;
                }

                var startInfo = new ProcessStartInfo
                {
                    WorkingDirectory = path,
                    WindowStyle = ProcessWindowStyle.Normal,
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    UseShellExecute = false
                };

                process.StartInfo = startInfo;
                process.Start();

                using var writer = process.StandardInput;
                if (!writer.BaseStream.CanWrite)
                {
                    return;
                }

                writer.WriteLine("git init");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }
    }
}