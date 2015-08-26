using System;

namespace Haep.AOP.ErrorHanding
{
    public interface IErrorHandler
    {
        string ShowException(Exception exception);
    }
}