using System;
using System.Collections.Generic;

namespace PlayFactory.Collection
{
    /// <summary>
    /// Métodos de extensões para Collections.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        ///Verifica se a Collection é null ou está vazia.
        /// </summary>
        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            return source == null || source.Count <= 0;
        }

        /// <summary>
        /// Adiciona um item na collection se ele ainda não existe.
        /// </summary>
        /// <param name="source">Collection</param>
        /// <param name="item">Item que será verificado e adicionado</param>
        /// <typeparam name="T">Tipo de itens da collection</typeparam>
        /// <returns>Retorna true se for adicionado e false se não for adicionado.</returns>
        public static bool AddIfNotContains<T>(this ICollection<T> source, T item)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (source.Contains(item))
            {
                return false;
            }

            source.Add(item);
            return true;
        }
    }
}
