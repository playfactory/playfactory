using System;

namespace PlayFactory.Extensions
{
    public static class ExceptionExtensions
    {
        public static void ReThrow(this Exception ex)
        {
            throw ex;
        }
    }
}
