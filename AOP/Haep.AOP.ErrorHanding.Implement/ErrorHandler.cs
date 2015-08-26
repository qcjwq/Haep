using System;

namespace Haep.AOP.ErrorHanding.Implement
{
    public class ErrorHandler : IErrorHandler
    {
        public string ShowException(Exception exception)
        {
            return exception.ToString();
        }
    }
}