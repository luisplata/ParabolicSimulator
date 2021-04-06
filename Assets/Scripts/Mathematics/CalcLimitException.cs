using System;

namespace Mathematics
{
    public class CalcLimitException : Exception
    {
        public CalcLimitException(string message) : base(message)
        {
        }
    }
}