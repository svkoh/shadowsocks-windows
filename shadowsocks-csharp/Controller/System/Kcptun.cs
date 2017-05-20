using System;
using Shadowsocks.Model;
using Shadowsocks.Util.SystemProxy;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Shadowsocks.Controller
{
    public static class Kcptun
    {
        private static readonly string KcptunDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "kcptun");

        private static void ExecuteBatFile(String dir, String filename)
        {
            Process proc = null;
            try
            {
                proc = new Process();
                proc.StartInfo.WorkingDirectory = dir;
                proc.StartInfo.FileName = filename;
                proc.StartInfo.CreateNoWindow = false;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;  //this is for hiding the cmd window...so execution will happen in back ground.
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
            }
        }
        public static bool IsRunning()
        {
            Process[] processes = Process.GetProcessesByName("kcptun");
            return processes.Length > 0;
        }

        public static void Stop()
        {
            ExecuteBatFile(KcptunDir, "stop-kcptun.bat");
        }
        public static void Start()
        {
            ExecuteBatFile(KcptunDir, "start-kcptun.vbs");
        }
        public static void Restart()
        {
            ExecuteBatFile(KcptunDir, "restart-kcptun.bat");
        }
    }
}