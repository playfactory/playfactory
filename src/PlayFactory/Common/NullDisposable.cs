using System;

namespace PlayFactory.Common
{
    /// <summary>
    /// Esta classe é utilizada para simular um objeto Disposable que não faz nada.
    /// </summary>
    internal sealed class NullDisposable : IDisposable
    {
        public static NullDisposable Instance { get; } = new NullDisposable();

        private NullDisposable()
        {

        }

        public void Dispose()
        {

        }
    }
}
