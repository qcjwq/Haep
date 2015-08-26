using System;

namespace Haep.AOP.Logging
{
    public interface ILog
    {
        void Debug(string title, Exception exception);
        void Debug(string title, string message);
    }
}