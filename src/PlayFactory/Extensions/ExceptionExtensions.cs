using System;

namespace PlayFactory.Extensions
{
    /// <summary>
    /// Class Help for <see cref="Exception"/>.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Throw exception.
        /// </summary>
        /// <param name="ex"></param>
        public static void ReThrow(this Exception ex)
        {
            throw ex;
        }
    }
}
