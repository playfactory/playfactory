using System;
using System.Collections.Generic;

namespace PlayFactory.Collection
{
    /// <summary>
    /// Extension Methods for Collections.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Checks whether the Collection is null or empty.
        /// </summary>
        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            return source == null || source.Count <= 0;
        }

        /// <summary>
        /// Add an item to the collection if it does not already exist.
        /// </summary>
        /// <param name="source">Collection</param>
        /// <param name="item">IItem that will be checked and added.</param>
        /// <typeparam name="T">Type of collection items</typeparam>
        /// <returns>Returns true if added and false if not added.</returns>
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
