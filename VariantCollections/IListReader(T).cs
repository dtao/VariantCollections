using System.Collections.Generic;

namespace VariantCollections
{
    /// <summary>
    /// Represents a covariant reader of a collection of objects that can be
    /// individually accessed by index.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public interface IListReader<out T> : IEnumerable<T>
    {
        /// <summary>
        /// Gets the element at the specified index.
        /// </summary>
        /// 
        /// <param name="index">
        /// The zero-based index of the element to get.
        /// </param>
        /// 
        /// <returns>
        /// The element at the specified index.
        /// </returns>
        T this[int index] { get; }

        /// <summary>
        /// Gets the number of elements contained in the list.
        /// </summary>
        int Count { get; }
    }
}
