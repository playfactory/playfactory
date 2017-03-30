using System;

namespace PlayFactory.Extensions
{
    /// <summary>
    /// Extension method that helps in locking.
    /// </summary>
    public static class LockExtensions
    {
        /// <summary>
        /// Executes the action <paramref name = "action" /> when the <paramref name = "source" /> object is not locked.
        /// </summary>
        /// <param name="source">Locked object.</param>
        /// <param name="action">Action to be taken.</param>
        public static void Locking(this object source, Action action)
        {
            lock (source)
            {
                action();
            }
        }

        /// <summary>
        /// Executes the action <paramref name = "action" /> when the <paramref name = "source" /> object is not locked.
        /// </summary>
        /// <typeparam name = "T"> Type of locked object </ typeparam>
        /// <param name="source">Locked object.</param>
        /// <param name="action">Action to be taken.</param>
        public static void Locking<T>(this T source, Action<T> action) where T : class
        {
            lock (source)
            {
                action(source);
            }
        }

        /// <summary>
        /// Executes the action <paramref name = "action" /> when the <paramref name = "source" /> object is not locked.
        /// </summary>
        /// <typeparam name="TResult">Return type.</typeparam>
        /// <param name="source">Locked object.</param>
        /// <param name="func">Func to be taken.</param>
        /// <returns>Returns the value of the function <paramref name = "func" />.</returns>
        public static TResult Locking<TResult>(this object source, Func<TResult> func)
        {
            lock (source)
            {
                return func();
            }
        }

        /// <summary>
        /// Executes the action <paramref name = "func" /> when the <paramref name = "source" /> object is not locked.
        /// </summary>
        /// <typeparam name = "T"> Type of locked object </ typeparam>
        /// <typeparam name="TResult">Return type.</typeparam>
        /// <param name="source">Locked object.</param>
        /// <param name="func">Func to be taken.</param>
        /// <returns>Returns the value of the function <paramref name = "func" />.</returns>
        public static TResult Locking<T, TResult>(this T source, Func<T, TResult> func) where T : class
        {
            lock (source)
            {
                return func(source);
            }
        }
    }
}
