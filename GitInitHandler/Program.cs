using System;
using System.Diagnostics;
using System.IO;

namespace GitInitHandler
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                    return;
                var path = Path.GetDirectoryName(args[0]);
                var process = new Process();
                if (path == null) return;
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
                using (var sw = process.StandardInput)
                {
                    if (!sw.BaseStream.CanWrite) return;
                    sw.WriteLine("git init");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
        }
    }
}