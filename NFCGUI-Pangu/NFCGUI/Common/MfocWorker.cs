using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace NFCGui.Common
{
    class MfocWorker
    {
        public static void mfoc(FrmMain gui, int probes, int distance, string dumpName, string keys)
        {
            keys=keys.Length < 12 ? "-k b5ff67cba951 -k 44dd5a385aaf -k 21a600056cb0 -k b1aca33180a5 -k dd61eb6bce22 -k 1565a172770f -k 3e84d2612e2a -k f23442436765 -k 79674f96c771 -k 87df99d496cb -k c5132c8980bc -k a21680c27773 -k f26e21edcee2 -k 675557ecc92e -k f4396e468114 -k 6db17c16b35b -k 4186562a5bb2 -k 2feae851c199 -k db1a3338b2eb -k 157b10d84c6b -k a643f952ea57 -k df37dcb6afb3 -k 4c32baf326e0 -k 91ce16c07ac5 -k 3c5d1c2bcd18 -k c3f19ec592a2 -k f72a29005459 -k 185fa3438949 -k 321a695bd266 -k d327083a60a7 -k 45635ef66ef3 -k 5481986d2d62 -k cba6ae869ad5 -k 645a166b1eeb -k a7abbc77cc9e -k f792c4c76a5c -k bfb6796a11db" : keys;
            Common.CreateFiles();
            Process process=new Process
            {
                StartInfo={
                    WindowStyle=ProcessWindowStyle.Hidden,
                    CreateNoWindow=true,
                    UseShellExecute=false,
                    RedirectStandardOutput=true,
                    FileName=System.IO.Path.GetTempPath() + @"\\mfoc.exe",
                    Arguments=string.Concat(new object[]
                    {
                        "mfoc -O ",
                        dumpName,
                        " -P ",
                        probes,
                        " -T ",
                        distance,
                        " ",
                        keys
                    })
                }
            };
            //   process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            //  process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.StartInfo.WindowStyle=ProcessWindowStyle.Hidden;
            string val="";
            val=process.StandardOutput.ReadToEnd();
            if (val != null)
            {
                Log.WriteLog(LogFile.RunningTime, val);
                gui.updateLogBox(val);
                gui.updateLogBox("\n");
            }
            process.WaitForExit();
            TimeSpan span=DateTime.Now.Subtract(process.StartTime);
            if (val.Contains("Auth with all sectors succeeded, dumping keys to a file!"))
            {
                MessageBox.Show(string.Concat(new object[]
                {
                    "完成!\n总耗时:",
                    span.Hours,
                    "小时",
                    span.Minutes,
                    "分",
                    span.Seconds,
                    "秒 \n 日志已记录到文件: ",
                    dumpName
                }));
                gui.updateStatus(2);
            }
            else
            {
                //  gui.updateStatus(0);
                MessageBox.Show("操作失败,请重试!");
                gui.updateStatus(0);
            }
        }
    }
}