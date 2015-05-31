using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NFCGui.Common
{
    public static class Log
    {
        private static LogManager logManager;
        static Log()
        {
            logManager=new LogManager();
        }

        public static void WriteLog(LogFile logFile, string msg)
        {
            logManager.WriteLog(logFile, msg);
        }

        public static void WriteLog(string logFile, string msg)
        {
            logManager.WriteLog(logFile, msg);
        }

        public static void WriteLog(string msg)
        {
            logManager.WriteLog(msg);
        }
    }

    public class LogManager
    {
        private string logFileName=string.Empty;
        private string logPath="Log";
        private string logFileExtName="log";
        private bool writeLogTime=true;
        private bool logFileNameEndWithDate=true;
        private Encoding logFileEncoding=Encoding.UTF8;
        private object obj=new object();
        #region 构造函数
        public LogManager()
        {
            this.LogPath="Log";
            this.LogFileExtName="log";
            this.WriteLogTime=true;
            this.logFileNameEndWithDate=true;
            this.logFileEncoding=Encoding.UTF8;
        }

        public LogManager(string logPath, string logFileExtName, bool writeLogTime)
        {
            this.LogPath=logPath;
            this.LogFileExtName=logFileExtName;
            this.WriteLogTime=writeLogTime;
            this.logFileNameEndWithDate=true;
            this.logFileEncoding=Encoding.UTF8;
        }

        #endregion
        #region 属性
        /// <summary>
        /// Log 文件路径
        /// </summary>
        public string LogPath
        {
            get
            {
                if (this.logPath == null || this.logPath == string.Empty)
                {
                    //Application.StartupPath
                    this.logPath=AppDomain.CurrentDomain.BaseDirectory;
                }
                return this.logPath;
            }
            set
            {
                this.logPath=value;
                if (this.logPath == null || this.logPath == string.Empty)
                {
                    //Application.StartupPath
                    this.logPath=AppDomain.CurrentDomain.BaseDirectory;
                }
                else
                {
                    try
                    {
                        // 判断是否不是绝对路径（绝对路径里还有":"）
                        if (this.logPath.IndexOf(Path.VolumeSeparatorChar) >= 0)
                        {
                        /* 绝对路径 */ }
                        else
                        {
                            // 相对路径
                            this.logPath=AppDomain.CurrentDomain.BaseDirectory + this.logPath;
                        }
                        if (!Directory.Exists(this.logPath))
                            Directory.CreateDirectory(this.logPath);
                    }
                    catch
                    {
                        this.logPath=AppDomain.CurrentDomain.BaseDirectory;
                    }
                    if (!this.logPath.EndsWith(@"\"))
                        this.logPath+=@"\";
                }
            }
        }
        /// <summary>
        /// Log 文件扩展名
        /// </summary>
        public string LogFileExtName
        {
            get
            {
                return this.logFileExtName;
            }
            set
            {
                this.logFileExtName=value;
            }
        }
        /// <summary>
        /// 是否在每个Log行前面添加当前时间
        /// </summary>
        public bool WriteLogTime
        {
            get
            {
                return this.writeLogTime;
            }
            set
            {
                this.writeLogTime=value;
            }
        }
        /// <summary>
        /// 日志文件名是否带日期
        /// </summary>
        public bool LogFileNameEndWithDate
        {
            get
            {
                return logFileNameEndWithDate;
            }
            set
            {
                logFileNameEndWithDate=value;
            }
        }
        /// <summary>
        /// 日志文件的字符编码
        /// </summary>
        public Encoding LogFileEncoding
        {
            get
            {
                return logFileEncoding;
            }
            set
            {
                logFileEncoding=value;
            }
        }
        #endregion
        #region 公有方法
        public void WriteLog(string logFile, string msg)
        {
            lock (obj)
            {
                try
                {
                    string dateString=string.Empty;
                    if (this.logFileNameEndWithDate || logFile.Length == 0)
                    {
                        dateString=DateTime.Now.ToString("yyyyMMdd");
                    }
                    logFileName=string.Format("{0}{1}{2}.{3}",
                        this.LogPath,
                        logFile,
                        dateString,
                        this.logFileExtName);
                    using (StreamWriter sw=new StreamWriter(logFileName, true, logFileEncoding))
                    {
                        if (writeLogTime)
                        {
                            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":\t" + msg);
                        }
                        else
                        {
                            sw.WriteLine(msg);
                        }
                    }
                }
                catch
                {
                }
            }
        }

        public void WriteLog(LogFile logFile, string msg)
        {
            this.WriteLog(logFile.ToString(), msg);
        }

        public void WriteLog(string msg)
        {
            this.WriteLog(string.Empty, msg);
        }
        #endregion
    }

    public enum LogFile
    {
        Trace,
        Error,
        SQL,
        SQLError,
        RunningTime
    }
}