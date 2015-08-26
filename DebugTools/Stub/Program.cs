using System;
using Haep.AOP.ErrorHanding;
using Haep.AOP.ErrorHanding.ErrorHandInfo;
using Haep.AOP.Logging;
using Haep.Core;

namespace Stub
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = HaepContainer.Get<ILog>();
            log.Debug("test", DateTime.Now.ToString("yyyy-MM-dd"));

            var error = HaepContainer.Get<IErrorHandler>();
            log.Debug("ArgumentException", error.ShowException(new ArgumentException("ArgumentException")));

            Console.ReadKey();
        }
    }
}
