using System;

namespace PlayFactory.Extensions
{
    /// <summary>
    /// Método de extenção que ajuda no bloqueio (lock).
    /// </summary>
    public static class LockExtensions
    {
        /// <summary>
        /// Executa a action <paramref name="action"/> quando o objeto <paramref name="source"/> não estiver bloqueado.
        /// </summary>
        /// <param name="source">Objeto bloqueiado (locked).</param>
        /// <param name="action">Action que será executada.</param>
        public static void Locking(this object source, Action action)
        {
            lock (source)
            {
                action();
            }
        }

        /// <summary>
        /// Executa a action <paramref name="action"/> quando o objeto <paramref name="source"/> não estiver bloqueado.
        /// </summary>
        /// <typeparam name="T">Tipo do objeto bloqueado (locked)</typeparam>
        /// <param name="source">Objeto bloqueiado (lock).</param>
        /// <param name="action">Action que será executada.</param>
        public static void Locking<T>(this T source, Action<T> action) where T : class
        {
            lock (source)
            {
                action(source);
            }
        }

        /// <summary>
        /// Executa a função <paramref name="func"/> quando o objeto <paramref name="source"/> não estiver bloqueado.
        /// </summary>
        /// <typeparam name="TResult">Tipo do retorno.</typeparam>
        /// <param name="source">Objeto bloqueiado (lock).</param>
        /// <param name="func">Função que será executada.</param>
        /// <returns>Retorna o valor da Função <paramref name="func"/></returns>
        public static TResult Locking<TResult>(this object source, Func<TResult> func)
        {
            lock (source)
            {
                return func();
            }
        }

        /// <summary>
        /// Executa a função <paramref name="func"/> quando o objeto <paramref name="source"/> não estiver bloqueado.
        /// </summary>
        /// <typeparam name="T">Tipo do objeto bloqueado (locked)</typeparam>
        /// <typeparam name="TResult">Tipo do retorno.</typeparam>
        /// <param name="source">Objeto bloqueiado (lock).</param>
        /// <param name="func">Função que será executada.</param>
        /// <returns>Retorna o valor da Função <paramref name="func"/></returns>
        public static TResult Locking<T, TResult>(this T source, Func<T, TResult> func) where T : class
        {
            lock (source)
            {
                return func(source);
            }
        }
    }
}
