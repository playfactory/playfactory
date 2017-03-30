using System;

namespace PlayFactory.Common
{
    /// <summary>
    /// This class is used to simulate a Disposable object that does nothing (Null Object Patterns).
    /// </summary>
    internal sealed class NullDisposable : IDisposable
    {
        /// <summary>
        /// Instância <see cref="NullDisposable"/>.
        /// </summary>
        public static NullDisposable Instance { get; } = new NullDisposable();

        private NullDisposable()
        {

        }

        public void Dispose()
        {

        }
    }
}
