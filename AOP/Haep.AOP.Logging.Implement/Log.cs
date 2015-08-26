using System;
using Haep.AOP.Logging.LogInfo;

namespace Haep.AOP.Logging.Implement
{
    public class Log : ILog
    {
        public void Debug(string title, Exception exception)
        {
            Debug(title, exception.ToString());
        }

        public void Debug(string title, string message)
        {
            WriteLog(LogLevel.Debug, title, message);
        }

        public void WriteLog(LogLevel logLevel, string title, string message)
        {
            Console.WriteLine($"{logLevel}--{title}：{message}");
        }
    }
}