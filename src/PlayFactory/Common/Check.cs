using System;

namespace PlayFactory.Common
{
    /// <summary>
    /// Class with useful checking methods
    /// </summary>
    public static class Check
    {
        /// <summary>
        /// Checks whether the object passed by parameter is Null. Se for null será lançado uma <see cref="ArgumentException"/>.
        /// </summary>
        /// <typeparam name="T">Object type passed as parameter.</typeparam>
        /// <param name="value">Object to be verified.</param>
        /// <param name="parameterName"></param>
        /// <returns>Returns the object passed as parameter.</returns>
        public static T NotNull<T>(T value, string parameterName)
        {
            if (value == null)
                throw new ArgumentNullException(parameterName);
            return value;
        }
    }
}
