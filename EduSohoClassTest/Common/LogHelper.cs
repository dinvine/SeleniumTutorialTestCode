using System;
using System.IO;
using System.Text;
using System.Configuration;

namespace EduSohoClassTest.Common
{
    /// <summary>
        /// 一个简单的log助手
        /// 使用步骤如下
        /// 1.在项目的配置文件的appSettings节点先添加一个节点，命名成LogLevel，例如
        ///  <add key="LogLevel" value="Debug" />
        /// 2.LogHelper.GetInstance，判断为true
        /// 3.调用Write***方法
        /// </summary>
    public sealed class LogHelper
    {
        enum LogLevel
        {
            Debug, Info, Warning, Error
        }


        private static LogLevel? _logLevel = null;
        private static LogHelper _logHelper;
        private static readonly object SyncObject = new object();
        private static StreamWriter _streamWriter;


        private LogHelper()
        {
        }


        /// <summary>
        /// 得到log助手
        /// </summary>
        /// <param name="logFilePath"></param>
        /// <returns></returns>
        public static LogHelper GetInstance(string logFilePath)
        {
            if (_logHelper == null)
            {
                lock (SyncObject)
                {
                    if (_logHelper == null)
                    {
                        if (InitWriteLogPathAndLevel(logFilePath))
                        {
                            _logHelper = new LogHelper();
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            return _logHelper;
        }


        /// <summary>
        /// 初始化日志文件路径和日志级别
        /// </summary>
        /// <param name="logFilePath"></param>
        /// <returns></returns>
        private static bool InitWriteLogPathAndLevel(string logFilePath)
        {
            try
            {
                //初始化日志路径
                if (!File.Exists(logFilePath))
                {
                    File.Create(logFilePath);
                }
                _streamWriter = new StreamWriter(logFilePath, true, Encoding.UTF8);
                //初始化日志级别
                string level = ConfigurationManager.AppSettings["LogLevel"];
                foreach (string name in Enum.GetNames(typeof(LogLevel)))
                {
                    if (level.ToLower() == name.ToLower())
                    {
                        _logLevel = (LogLevel)Enum.Parse(typeof(LogLevel), level, true);
                        break;
                    }
                }
                if (_streamWriter != null && _logLevel != null)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                if (_streamWriter != null)
                {
                    _streamWriter.Close();
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// 记录调试信息
        /// </summary>
        /// <param name="debug">自定义格式的调试信息，最好是时间-程序集-类-方法-调试信息的格式，方便定位信息的出处，可以进一步封装，这里就不带劳了</param>
        /// <returns></returns>
        public static bool WriteDebugLog(string debug)
        {
            if (Convert.ToInt32(_logLevel) <= Convert.ToInt32(LogLevel.Debug) && _streamWriter != null)
            {
                _streamWriter.WriteLine("******DebugInfo*****" + debug);
                _streamWriter.Flush();
                return true;
            }
            return false;
        }
        /// <summary>
        /// 记录一般信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static bool WriteInfoLog(string info)
        {
            if (Convert.ToInt32(_logLevel) <= Convert.ToInt32(LogLevel.Info) && _streamWriter != null)
            {
                _streamWriter.WriteLine("#####Info#####" + info);
                _streamWriter.Flush();
                return true;
            }
            return false;
        }
        /// <summary>
        /// 记录警告信息
        /// </summary>
        /// <param name="warning"></param>
        /// <returns></returns>
        public static bool WriteWarningLog(string warning)
        {
            if (Convert.ToInt32(_logLevel) <= Convert.ToInt32(LogLevel.Warning) && _streamWriter != null)
            {
                _streamWriter.WriteLine("?????WarningInfo?????" + warning);
                _streamWriter.Flush();
                return true;
            }
            return false;
        }
        /// <summary>
        /// 记录错误信息
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static bool WriteErrorLog(string error)
        {
            if (Convert.ToInt32(_logLevel) <= Convert.ToInt32(LogLevel.Info) && _streamWriter != null)
            {
                _streamWriter.WriteLine("!!!!!ErroInfo!!!!!" + error);
                _streamWriter.Flush();
                return true;
            }
            return false;
        }
    }
}
