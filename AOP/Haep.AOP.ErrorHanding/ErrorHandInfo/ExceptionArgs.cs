using System;

namespace Haep.AOP.ErrorHanding.ErrorHandInfo
{
    [Serializable]
    public abstract class ExceptionArgs
    {
        public virtual String Message => string.Empty;
    }
}