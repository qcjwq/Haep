namespace Haep.AOP.ErrorHanding.ErrorHandInfo
{
    public class DivideZeroException : ExceptionArgs
    {
        private readonly int _divide;

        public DivideZeroException(int divide)
        {
            _divide = divide;
        }

        public override string ToString()
        {
            return $"{_divide}尝试除以0";
        }
    }
}