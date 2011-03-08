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
    }
}
