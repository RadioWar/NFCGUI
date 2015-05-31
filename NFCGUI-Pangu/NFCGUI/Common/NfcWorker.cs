using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace NFCGui.Common
{
    //enum NFCRun
    //{
    //    nfc-anticol,nfc-dep-initiator,nfc-dep-target
    //}
    class NfcWorker
    {
        public static String NfcCall(string nfcrun, string Args)
        {
            Common.CreateNFCFiles();
            Process process=new Process
            {
                StartInfo={
                    CreateNoWindow=true,
                    UseShellExecute=false,
                    RedirectStandardOutput=true,
                    FileName=System.IO.Path.GetTempPath() + @"\\" + nfcrun,
                    Arguments=Args
                }
            };
            process.Start();
            string output="";
            while (!process.HasExited)
            {
                output=process.StandardOutput.ReadToEnd();
            }
            process.WaitForExit();
            Log.WriteLog(output);
            //   process.Close();
            return output;
        }

        public static bool checkDevice()
        {
            string str="";
            if (!str.Contains("No device found"))
            {
                Process process=new Process
                {
                    StartInfo={
                        UseShellExecute=false,
                        RedirectStandardOutput=true,
                        CreateNoWindow=true,
                        FileName=Application.StartupPath + @"\nfc-list.exe"
                    }
                };
                process.Start();
                //  process.Start();
                string str2="";
                while (!process.HasExited)
                {
                    str2=process.StandardOutput.ReadToEnd();
                }
                process.WaitForExit();
                Log.WriteLog(str2);
            }
            return false;
        }
    }
}