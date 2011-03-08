using System.Collections.Generic;

namespace VariantCollections
{
    /// <summary>
    /// Provides an extension method to create variant readers for strongly-
    /// typed lists.
    /// </summary>
    public static class ListReader
    {
        /// <summary>
        /// Creates an <see cref="IListReader{T}"/> from an
        /// <seealso cref="IList{T}"/>.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of the elements of <paramref name="list"/>.
        /// </typeparam>
        /// 
        /// <param name="list">
        /// The <seealso cref="IList{T}"/> from which to create an
        /// <see cref="IListReader{T}"/>.
        /// </param>
        /// 
        /// <returns>
        /// An <see cref="IListReader{T}"/> capable of reading elements from
        /// the input list.
        /// </returns>
        public static IListReader<T> AsVariant<T>(this IList<T> list)
        {
            return new ListReader<T>(list);
        }

        /// <summary>
        /// Determines the index of a specific item in the list.
        /// </summary>
        /// 
        /// <typeparam name="T">
        /// The type of elements in the list.
        /// </typeparam>
        /// 
        /// <param name="reader">
        /// The reader with which to search for the specified value.
        /// </param>
        /// 
        /// <param name="value">
        /// The object to locate in the list.
        /// </param>
        /// 
        /// <returns>
        /// The index of <paramref name="value"/> if found in the list;
        /// otherwise, -1.
        /// </returns>
        public static int IndexOf<T>(this IListReader<T> reader, T value)
        {
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            for (int i = 0; i < reader.Count; i++)
            {
                if (comparer.Equals(reader[i], value))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
