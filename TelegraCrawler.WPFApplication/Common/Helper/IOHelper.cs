using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegraCrawler.WPFApplication.Common.Helper
{
    public class IOHelper
    {
        public static string GetNewDirName(string dirName,string parentDir = @"D:\Data\ImageSave")
        {
            if (string.IsNullOrEmpty(parentDir) || string.IsNullOrWhiteSpace(parentDir)) new Exception($"parameter:{parentDir} is null Or whiteSpace!");
            if (string.IsNullOrEmpty(dirName) || string.IsNullOrWhiteSpace(dirName)) new Exception($"parameter:{dirName} is null Or whiteSpace!");
            string path = @$"{parentDir}\{dirName}";
            try
            {
                
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    return path;
                }

                for (int i = 1; i < int.MaxValue; i++)
                {
                    path = @$"D:\Data\ImageSave\{dirName}{i}";
                    if (!Directory.Exists(path))
                    {
                        break;
                    }
                }
                Directory.CreateDirectory(path);
                return path;
            }
            catch (Exception)
            {
                throw new Exception($"DirPath :{path} is illegal!");
            }
        }

        public static void OpenFileDir(string fullName)
        {
            Process process = new Process();
            ProcessStartInfo psi = new("Explorer.exe");
            process.StartInfo = psi;
            psi.Arguments = "/e,/select," + fullName;
            StartProcess(process);
        }


        private static void StartProcess(Process process)
        {
            try
            {
                process.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
