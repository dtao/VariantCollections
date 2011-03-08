using System.Collections.Generic;

namespace VariantCollections
{
    /// <summary>
    /// Represents a variant reader of a generic collection of key/value pairs.
    /// </summary>
    /// 
    /// <typeparam name="TKey">
    /// The type of keys in the dictionary.
    /// </typeparam>
    /// 
    /// <typeparam name="TValue">
    /// The type of values in the dictionary.
    /// </typeparam>
    public interface IDictionaryReader<in TKey, out TValue>
    {
        /// <summary>
        /// Gets the element with the specified key.
        /// </summary>
        /// 
        /// <param name="key">
        /// The key of the element to get.
        /// </param>
        /// 
        /// <returns>
        /// The element with the specified key.
        /// </returns>
        TValue this[TKey key] { get; }

        /// <summary>
        /// Gets the number of elements contained in the dictionary.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Determines whether the dictionary contains an element with the
        /// specified key.
        /// </summary>
        /// 
        /// <param name="key">
        /// The key to locate in the dictionary.
        /// </param>
        /// 
        /// <returns>
        /// <c>true</c> if the dictionary contains an element with the key;
        /// otherwise, <c>false</c>.
        /// </returns>
        bool ContainsKey(TKey key);
    }
}
