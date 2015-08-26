using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Haep.AOP.ErrorHanding.ErrorHandInfo
{
    [Serializable]
    public sealed class Exception<T> : Exception, ISerializable
        where T : ExceptionArgs
    {
        private const string Args = "Args";

        public T ExceptionArgs { get; }

        public Exception(string message = null, Exception innerException = null)
            : this(null, message, innerException)
        {
        }

        public Exception(T exceptionArgs, string message = null, Exception innerException = null)
            : base(message, innerException)
        {
            ExceptionArgs = exceptionArgs;
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        private Exception(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ExceptionArgs = (T)info.GetValue(Args, typeof(T));
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(Args, ExceptionArgs);
            base.GetObjectData(info, context);
        }

        public override string Message
        {
            get
            {
                string baseMsg = base.Message;
                return (ExceptionArgs == null)
                    ? baseMsg
                    : baseMsg + " (" + ExceptionArgs.Message + ")";
            }
        }

        public override bool Equals(Object obj)
        {
            Exception<T> other = obj as Exception<T>;
            if (obj == null || other == null)
                return false;
            return Equals(ExceptionArgs, other.ExceptionArgs) && base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}